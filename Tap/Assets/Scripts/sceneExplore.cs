//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using Assets.Scripts;
//using UnityEngine.SceneManagement;

//public class sceneExplore : MonoBehaviour
//{
//    private Player player;

//    public GameObject[] Scenary = new GameObject[3];
//    public int scenarySelect;

//    public GameObject CustomCanvas;
//    public GameObject OverlayCanvas;

//    public float maxHealth, actualHealth;
//    public int maxStamina, actualStamina;

//    public float damage;

//    public GameObject healthBar, staminaBar;
//    private float healthMaxSize, staminaMaxSize;
//    public Text healthBarTxt, staminaBarTxt;

//    private MapTile[] mapTile;
//    private int actualMapTile;
//    public GameObject[] MapTiles;
//    public Button btnMapPanel;

//    public GameObject lootOpeners;
//    public Text lootOpChestTxt, lootOpLootTxt, lootMsg, txtProfit;
//    public Button btnBackToBase, btnBag;
//    public int lootPanelHeightMove;

//    public Text lootBag, lootChest;
//    private int bag = 0, chest = 0, goldProft = 0, crystalProft = 0;

//    public float PanelHeightMove;
//    private float mapPanelPosTop, mapPanelPosBot, panelPos;
//    public GameObject mapPanel;
//    private bool allTilesComplete = false;

//    public int ExpSize;
//    public int actualExp;
//    public GameObject[] IconExp;
//    public GameObject IconExpPos;
//    private Vector3 ExpPosZero;

//    public Bubble[] bubble;
//    public int activeBubbles;

//    public Enemy[] enemy;


//    // Use this for initialization
//    void Start()
//    {
//        //subCanvas.transform.position = new Vector3(CustomCanvas.transform.position.x, CustomCanvas.transform.position.y + subMinPosY, CustomCanvas.transform.position.z);
//        //Debug.Log("Entrou no evento!");
//        //Debug.Log("MapPanelY: "+mapPanel.transform.position.y.ToString() + "\nCustCanvasPosY: " + CustomCanvas.transform.position.y.ToString() + "\nDif: "+ (CustomCanvas.transform.position.y - mapPanel.transform.position.y).ToString());
//        ExpPosZero = IconExpPos.transform.position;
//        //posiciona o painel do Mapa no topo
//        mapPanelPosTop = mapPanel.transform.position.y;
//        mapPanelPosBot = mapPanelPosTop - PanelHeightMove;
//        //mapPanel.transform.position = new Vector3(mapPanel.transform.position.x, OverlayCanvas.transform.position.y + mapPanelPosTop, mapPanel.transform.position.z);
//        panelPos = mapPanel.transform.position.y;

//        btnMapPanel.interactable = false;

//        player = new Player();
//        player.Load();

//        //player.NewGame(); player.Save();

//        maxHealth = player.hpMC;
//        maxStamina = player.staminaMax;
//        actualHealth = maxHealth;
//        actualStamina = maxStamina;

//        for (int i = 0; i < enemy.Length; i++)
//        {
//            enemy[i].Start(i < 3 ? 1 : 2, i < 3 ? Assist.IntGenerator(0, 10) : Assist.IntGenerator(0, 5));
//        }


//        for (int i = 0; i < bubble.Length; i++)
//        {
//            bubble[i].Start();
//        }
//        GenerateSmallTiles();
//        //GenerateTiles();
//        //Maps/WavesGenerates

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //PanelMove();
//        VerticalSmoothMove(mapPanel, panelPos);
//        lootBag.text = bag.ToString();
//        lootChest.text = chest.ToString();

//        for (int i = 0; i < enemy.Length; i++)
//        {
//            if (enemy[i].UpdateDead())
//            {
//                GenLoot();
//            }
//        }

//        for (int i = 0; i < activeBubbles; i++)
//        {
//            bubble[i].Update();
//        }
//        if (CheckEnemys()) LoadWave();

//        CheckStatus();

//        //check if btn can be clicked
//        btnMapPanel.interactable = !mapTile[actualMapTile].active;
//    }

//    #region Events

//    public void BtnEnemy(int enemyId)
//    {
//        //0- Mid | 1- Left | 2- Right | 3- Fly1 | 4- Fly2
//        enemy[enemyId].actualLife -= damage;
//    }

//    public void BtnTile(int TileSelect)
//    {
//        if (mapTile[TileSelect].active && mapTile[actualMapTile].active == false)
//        {
//            actualMapTile = TileSelect;
//            LoadTile();
//        }
//        else
//        {
//            Debug.Log("Tile Completo!");
//            //avisa que nao tem nada la
//        }

//        btnMapPanel.interactable = false;

//        panelPos = mapPanelPosTop;
//    }

//    public void BtnMapPanel()
//    {
//        if (mapPanel.transform.position.y == mapPanelPosBot)
//        {
//            panelPos = mapPanelPosTop;
//            return;
//        }

//        if (mapPanel.transform.position.y == mapPanelPosTop)
//        {
//            panelPos = mapPanelPosBot;
//            return;
//        }
//    }

//    public void BtnSkill1()
//    {
//    }

//    public void BtnSkill2()
//    {
//    }

//    public void BtnSkill3()
//    {

//    }

//    public void BtnSkill4()
//    {

//    }

//    public void BtnBag()
//    {
//        //click and generate loot from lootbags
//        if (bag > 0)
//        {
//            bag--;
//            int _gold, _crystal;

//            _gold = (int)(Random.value * 50);
//            _crystal = (int)(Random.value * 15);

//            player.gold += _gold;
//            player.magicCrystal += _crystal;

//            goldProft += _gold;
//            crystalProft += _crystal;
//        }


//    }

//    public void BtnBackToBase()
//    {
//        //click to save players stats and go back to base
//        Debug.Log("Chests: " + chest + " P.Chest: " + player.chestD);
//        player.chestD += chest;
//        player.Save();

//        Debug.Log("--");
//        Debug.Log("P.CHest: " + player.chestD);

//        player.Load();

//        SceneManager.LoadScene("sceneBase");
//    }

//    #endregion

//    #region Functions


//    private void Loot()
//    {

//        //smooth move panel
//        VerticalSmoothMove(lootOpeners, lootPanelHeightMove);

//        //disable btnlottbag when no more lootbags
//        //if no more lootbags enable back to base btn
//        if (bag <= 0)
//        {
//            btnBag.interactable = false;
//            btnBackToBase.interactable = true;
//            btnBackToBase.gameObject.SetActive(true);
//        }

//        //update texts with number of loots
//        lootMsg.text = bag.ToString();

//        txtProfit.text = "Gold: " + goldProft + "  -  Magic Crystal: " + crystalProft;

//        //Debug.Log("Loot()  -  G." + goldProft + " C." + crystalProft);
//    }

//    private void GenLoot()
//    {
//        bag += ((int)(Random.value * 5));

//        chest += ((int)(Random.value * 1.5));
//    }
//    private void SelectScenary()
//    {
//        for (int i = 0; i < Scenary.Length; i++)
//        {
//            Scenary[i].SetActive(i == scenarySelect);
//        }
//    }

//    private void CheckStatus()
//    {
//        float _healthP, _staminaP;

//        _healthP = actualHealth / maxHealth;
//        _staminaP = (float)actualStamina / (float)maxStamina;

//        healthBar.GetComponent<Image>().fillAmount = _healthP;
//        healthBarTxt.text = ((int)(_healthP * 100)).ToString() + "%";



//        staminaBar.GetComponent<Image>().fillAmount = _staminaP;
//        staminaBarTxt.text = actualStamina + "/" + maxStamina;
//    }

//    public void GenerateTiles()
//    {
//        //Gera os valores de wave
//        int _mapTileQtd = 1 + (int)(Random.value * 8);

//        mapTile = new MapTile[_mapTileQtd];

//        for (int i = 0; i < MapTiles.Length; i++)
//        {
//            if (i < _mapTileQtd)
//            {
//                mapTile[i] = new MapTile();
//                mapTile[i].Start();
//            }
//            else
//            {
//                MapTiles[i].SetActive(false);
//            }
//        }
//        LoadTile();
//    }

//    public void GenerateSmallTiles()
//    {
//        int _mapTileQtd = 2;

//        mapTile = new MapTile[_mapTileQtd];

//        for (int i = 0; i < MapTiles.Length; i++)
//        {
//            if (i < _mapTileQtd)
//            {
//                mapTile[i] = new MapTile();
//                mapTile[i].SmallStart();
//            }
//            else
//            {
//                MapTiles[i].SetActive(false);
//            }
//        }
//        LoadTile();
//    }

//    /// <summary>
//    /// Carrega o MapTile na scene
//    /// </summary>
//    private void LoadTile()
//    {
//        ExpSize = mapTile[actualMapTile].wave.Length;
//        //Recarregar o marcador de exploração
//        scenarySelect = mapTile[actualMapTile].backGround;
//        SelectScenary();
//        ExplorerProgressGen(ExpSize);
//        actualExp = -1;
//        LoadWave();
//    }

//    /// <summary>
//    /// Carrega a próxima Wave
//    /// </summary>
//    private void LoadWave()
//    {
//        //pega os valores de wave do Tile e joga nos enemys

//        if (actualExp < ExpSize - 1)
//        {
//            actualExp++;
//            IconExpPos.transform.position = IconExp[actualExp].transform.position;
//            for (int i = 0; i < enemy.Length; i++)
//            {

//                enemy[i].maxLife = mapTile[actualMapTile].wave[actualExp].HP[i];
//                enemy[i].attack = mapTile[actualMapTile].wave[actualExp].dmg[i];
//                enemy[i].Gen(i < 3 ? 1 : 2, i < 3 ? Assist.IntGenerator(0, 10) : Assist.IntGenerator(0, 5));
//                enemy[i].Update();
//            }
//        }
//        else
//        {
//            //coloca bandeira de pronto no tile
//            if (mapTile[actualMapTile].active)
//            {
//                Debug.Log("Tile " + actualMapTile + " Completo, Prossiga para o proximo Tile");
//                mapTile[actualMapTile].active = false;
//            }
//            else if (!allTilesComplete)
//            {
//                for (int i = 0; i < mapTile.Length; i++)
//                {
//                    if (mapTile[i].active) return;
//                }
//                allTilesComplete = true;

//                lootOpChestTxt.text = "Found " + chest + " chests.";
//                lootOpLootTxt.text = "Found " + bag + " bags.";


//                lootPanelHeightMove = (int)(lootOpeners.transform.position.y + lootPanelHeightMove);

//                btnBackToBase.gameObject.SetActive(false);
//            }
//            else
//            {
//                Loot();
//            }
//        }
//    }

//    /// <summary>
//    /// CHeck if all enemys are dead
//    /// </summary>
//    /// <returns></returns>
//    private bool CheckEnemys()
//    {
//        for (int i = 0; i < enemy.Length; i++)
//        {
//            if (enemy[i].Main.activeSelf == true) return false;
//        }
//        return true;
//    }

//    private void ExplorerProgressGen(int waveQtd)
//    {
//        for (int i = 0; i < IconExp.Length; i++)
//        {
//            IconExp[i].transform.position = ExpPosZero;
//        }

//        int[] _pos = new int[waveQtd];
//        int _space = 45; //espaçamento entre marcadores;
//        int _variant = 0; //modifica todos para um lado ou outro;
//        if (waveQtd % 2 == 0)
//        {
//            for (int i = 0; i < _pos.Length; i++)
//            {
//                if (i % 2 == 0)
//                {
//                    _pos[i] = (i / 2 * _space) + _space / 2 + _variant;
//                }
//                else
//                {
//                    _pos[i] = -(((i - 1) / 2 * _space) + _space / 2) + _variant;
//                }

//            }
//        }
//        else
//        {
//            for (int i = 0; i < _pos.Length; i++)
//            {
//                if (i % 2 == 0)
//                {
//                    _pos[i] = (i / 2 * _space) + _variant;
//                }
//                else
//                {
//                    _pos[i] = -(((i + 1) / 2 * _space)) + _variant;
//                }

//            }
//        }

//        System.Array.Sort(_pos);

//        for (int i = 0; i < IconExp.Length; i++)
//        {
//            if (i < waveQtd)
//            {
//                IconExp[i].transform.position = new Vector3(_pos[i] + IconExp[i].transform.position.x, IconExp[i].transform.position.y, IconExp[i].transform.position.z);
//                IconExp[i].SetActive(true);
//            }
//            else
//            {
//                IconExp[i].SetActive(false);
//            }

//        }
//        IconExpPos.transform.position = IconExp[0].transform.position;
//        actualExp = 0;

//    }

//    private void EnemyDamage(GameObject Enemy, GameObject EnemyHealthBar)
//    {

//    }

//    private void PanelMove()
//    {
//        int _min = 2; // Diferença minima para colocar no lugar
//        int _slideSpeed = 10; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)

//        if (panelPos != mapPanel.transform.position.y)
//        {
//            mapPanel.transform.Translate(0, mapPanel.transform.position.y - panelPos > _min ? -1 * (mapPanel.transform.position.y - panelPos) / _slideSpeed : // a diferença for maior que min pixels (descendo)
//                mapPanel.transform.position.y - panelPos < -_min ? -1 * (mapPanel.transform.position.y - panelPos) / _slideSpeed : // caso nao seja maior, testa para ver se nao é menor de -min pixels (subindo)
//                -1 * (mapPanel.transform.position.y - panelPos), 0);
//        }
//    }

//    private void VerticalSmoothMove(GameObject gameObj, float target)
//    {
//        int _min = 2; // Diferença minima para colocar no lugar
//        int _slideSpeed = 10; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)

//        if (target != gameObj.transform.position.y)
//        {
//            float _translate = gameObj.transform.position.y - target > _min || gameObj.transform.position.y - target < -_min ?
//                -(gameObj.transform.position.y - target) / _slideSpeed :
//                -(gameObj.transform.position.y - target);

//            gameObj.transform.Translate(0, _translate, 0);
//        }
//    }


//    #endregion
//}
