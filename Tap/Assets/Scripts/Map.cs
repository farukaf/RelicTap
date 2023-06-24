using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

[System.Serializable]
public class Map
{

    public string Seed = "";
    //change to private later
    public Tile[] tile = new Tile[9];

    public GameObject[] Enemies;
    public int[] EnemiesType;
    public Image[] EnemiesHealthBar;
    public Image[] EnemiesCoolDown;
    public Text[] EnemiesName;

    public Button BtnMap;
    public Button[] BtnMapTile;

    public GameObject[] WaveMarks;
    public GameObject WavePosition;

    public GameObject CustomCanvas;

    public GameObject MapCanvas;
    private Vector3 MapCanvasPos, MapCanvasEndPos = new Vector3(360, 795, -10), MapCanvasStartPos;

    public int actTile = 0, actWave = 0;

    public bool mapComplete = false;

    public FlyingScript[] flying;
    public RectTransform[] rectLimit;

    // Use this for initialization
    public void Start()
    {


        flying = new FlyingScript[Enemies.Length];
        for (int i = 0; i < flying.Length; i++)
        {
            flying[i] = new FlyingScript(Enemies[i], rectLimit[i]);
        }

        for (int i = 0; i < tile.Length; i++)
        {
            tile[i] = new Tile();
            tile[i].Start();
        }

        if (Seed != "") GenMap(Seed);
        else GenMap(true);

        BtnMap.interactable = false;

        for (int i = 0; i < tile.Length; i++)
        {
            BtnMapTile[i].gameObject.SetActive(tile[i].active);
        }

        MapCanvasStartPos = MapCanvas.transform.position;
        MapCanvasPos = MapCanvasStartPos;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!mapComplete)
        {
            tile[actTile].Update();
            tile[actTile].wave[actWave].Update();

            UpdateEnemies();
            UpdateWaveIndicator();
            UpdateSmoothMove();

            if (tile[actTile].CheckTile() || !tile[actTile].active)
            {
                BtnMap.interactable = true;
                for (int i = 0; i < tile.Length; i++)
                {
                    if (BtnMapTile[i].gameObject.activeSelf)
                    {
                        if (!tile[i].active)
                        {
                            if (BtnMapTile[i].interactable)
                            {
                                BtnMapTile[i].interactable = false;
                                MapCanvasPos = MapCanvasEndPos;
                            }
                        }
                    }
                }
            }

            if (tile[actTile].wave[actWave].CheckWave())
            {
                if (tile[actTile].wave[actWave + 1].active)
                {
                    actWave++;
                }
            }
        }
        else
        {
            MapCanvasPos = MapCanvasStartPos;
            Debug.Log("Map Complete!");

        }
        

        mapComplete = CheckMap();
    }

    public bool EnemyTap(int n)
    {
        Debug.Log("actTile: " + actTile + " actWave: " + actWave + " n: " + n);
        return (tile[actTile].wave[actWave].enemy[n].Tap());

    }

    public void DamageEnemy (int n)
    {

    }

    private void GenMap(bool small)
    {
        if (small)
        {
            for (int i = 0; i < 3; i++)
            {
                tile[i].Gen(true);
            }
        }
        else
        {

        }
    }

    private void GenMap(string seed)
    {
        switch (seed)
        {
            case "test":

                tile[0].Gen();
                tile[0].wave[0].Gen();
                tile[0].wave[0].enemy[0] = NewEnemy(0);
                tile[0].wave[0].enemy[1] = NewEnemy(0);

                tile[0].wave[1].Gen();
                tile[0].wave[1].enemy[0] = NewEnemy(1);
                tile[0].wave[1].enemy[1] = NewEnemy(1);


                tile[0].wave[2].Gen();
                tile[0].wave[2].enemy[0] = NewEnemy(20);
                tile[0].wave[2].enemy[1] = NewEnemy(20);

                tile[1].Gen(true);

                break;
        }
    }

    private void UpdateEnemies()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            tile[actTile].wave[actWave].enemy[i].Update();

            Enemies[i].SetActive(tile[actTile].wave[actWave].enemy[i].alive);

            if (tile[actTile].wave[actWave].enemy[i].alive)
            {
                Enemies[i].GetComponent<Image>().sprite = tile[actTile].wave[actWave].enemy[i].sprite;

                EnemiesHealthBar[i].fillAmount = ((float)tile[actTile].wave[actWave].enemy[i].actHp / (float)tile[actTile].wave[actWave].enemy[i].maxHp);

                EnemiesCoolDown[i].fillAmount = tile[actTile].wave[actWave].enemy[i].actCoolDown / tile[actTile].wave[actWave].enemy[i].maxCoolDown;

                EnemiesName[i].text = tile[actTile].wave[actWave].enemy[i].name;
            }
            if (tile[actTile].wave[actWave].enemy[i].flying)
            {
                flying[i].Update();
            }

        }
    }

    private void UpdateWaveIndicator()
    {
        int n = 0;
        for (int i = 0; i < tile[actTile].wave.Length; i++)
        {
            if (tile[actTile].wave[i].build)
            {
                n++;
                WaveMarks[i].SetActive(true);
            }
            else
            {
                WaveMarks[i].SetActive(false);
            }
        }

        int[] _pos = new int[n];
        int _space = 45; //espaçamento entre marcadores;
        int _variant = 0; //modifica todos para um lado ou outro;
        if (n % 2 == 0)
        {
            //par
            for (int i = 0; i < _pos.Length; i++)
            {
                if (i % 2 == 0)
                {
                    _pos[i] = (i / 2 * _space) + _space / 2 + _variant;
                }
                else
                {
                    _pos[i] = -(((i - 1) / 2 * _space) + _space / 2) + _variant;
                }
            }
        }
        else
        {
            //impar
            for (int i = 0; i < _pos.Length; i++)
            {
                if (i % 2 == 0)
                {
                    _pos[i] = (i / 2 * _space) + _variant;
                }
                else
                {
                    _pos[i] = -(((i + 1) / 2 * _space)) + _variant;
                }
            }
        }

        System.Array.Sort(_pos);

        for (int i = 0; i < _pos.Length; i++)
        {
            WaveMarks[i].transform.position = new Vector3(CustomCanvas.transform.position.x + _pos[i], WaveMarks[i].transform.position.y, WaveMarks[i].transform.position.z);

        }

        WavePosition.transform.position = WaveMarks[actWave].transform.position;
    }

    public void ButtonMap()
    {
        if (MapCanvasPos == MapCanvasStartPos)
        {
            MapCanvasPos = MapCanvasEndPos;
        }
        else
        {
            MapCanvasPos = MapCanvasStartPos;
        }
    }

    private void SmoothMove(GameObject gameObj, Vector3 target)
    {
        int _min = 2; // Diferença minima para colocar no lugar
        int _slideSpeed = 10; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)

        if (target.x != gameObj.transform.position.x)
        {
            float _translate = gameObj.transform.position.x - target.x > _min || gameObj.transform.position.x - target.x < -_min ?
                -(gameObj.transform.position.x - target.x) / _slideSpeed :
                -(gameObj.transform.position.x - target.x);

            gameObj.transform.Translate(_translate, 0, 0);
        }

        if (target.y != gameObj.transform.position.y)
        {
            float _translate = gameObj.transform.position.y - target.y > _min || gameObj.transform.position.y - target.y < -_min ?
                -(gameObj.transform.position.y - target.y) / _slideSpeed :
                -(gameObj.transform.position.y - target.y);

            gameObj.transform.Translate(0, _translate, 0);
        }

        if (target.z != gameObj.transform.position.z)
        {
            float _translate = gameObj.transform.position.z - target.z > _min || gameObj.transform.position.z - target.z < -_min ?
                -(gameObj.transform.position.z - target.z) / _slideSpeed :
                -(gameObj.transform.position.z - target.z);

            gameObj.transform.Translate(0, 0, _translate);
        }
    }

    private void UpdateSmoothMove()
    {
        SmoothMove(MapCanvas, MapCanvasPos);
    }

    public void ButtonMapTile(int n)
    {
        actTile = n;
        actWave = 0;
        MapCanvasPos = MapCanvasStartPos;
        BtnMap.interactable = false;
    }

    private bool CheckMap()
    {
        for (int i = 0; i < tile.Length; i++)
        {
            if (tile[i].active) return false;
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type">0-Ground, 1-Flying</param>
    /// <param name="id"></param>
    /// <returns></returns>
    private Enemy NewEnemy(int id)
    {
        EnemyLibrary EnemyLibrary = new EnemyLibrary();

        Enemy _e = new Enemy();


        _e = EnemyLibrary.Enemies[id];


        return _e;
    }

}
