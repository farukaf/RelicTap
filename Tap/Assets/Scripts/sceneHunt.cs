using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class sceneHunt : MonoBehaviour
{

    public Player player = new Player();
    public Image playerHPBar, playerStamBar;
    public Text txtplayerHPBar, txtplayerStamBar;

    public Enemy[] enemy;

    public Map map;

    /// <summary>
    /// Qtd indicator on screen
    /// </summary>
    public Text txtTotalLootBag, txtTotalChest;

    /// <summary>
    /// Texts from openPnl
    /// </summary>
    public Text txtLootBagMsg, txtChestMsg, txtEndPnlReport, txtLootBagLeft;



    public GameObject OpenLootPnl;
    private Vector3 OpenLootPnlPos, OpenLootPnlStartPos, OpenLootPnlEndPos = new Vector3(360, 640, 0);

    private int totalLootBag = 0, totalChest = 0;
    private int lootBagLeft;

    public Button ButtonBackToBase, ButtonOpenLootBag;

    public Image[] CDEffectSkill;
    float deltaSkill = 0;

    bool introduction = false;

    void Start()
    {
        player.Load();
        player.healthAct = player.healthMax;
        player.staminaAct = player.staminaMax;
        StatsUpdate();

        ButtonBackToBase.gameObject.SetActive(false);

        map.Start();

        OpenLootPnlPos = OpenLootPnl.transform.position;
        OpenLootPnlStartPos = OpenLootPnl.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        player.HuntUpdate();
        StatsUpdate();


        if (introduction)
        {

        }
        else
        {

            enemy = map.tile[map.actTile].wave[map.actWave].enemy;



            txtTotalLootBag.text = totalLootBag.ToString();
            txtTotalChest.text = totalChest.ToString();

            txtLootBagMsg.text = "Total of " + totalLootBag + " loot bags found";
            txtChestMsg.text = "Total of " + totalChest + " chests found";

            if (!map.mapComplete)
            {
                map.Update();
                EnemySkillQuery();
                if (map.mapComplete)
                {
                    lootBagLeft = totalLootBag;
                }
            }
            else
            {
                SmoothMove(OpenLootPnl, OpenLootPnlEndPos);
                txtLootBagLeft.text = lootBagLeft.ToString();

                if (lootBagLeft <= 0)
                {
                    ButtonOpenLootBag.interactable = false;
                    ButtonOpenLootBag.interactable = false;
                    ButtonBackToBase.gameObject.SetActive(true);

                    txtEndPnlReport.text = "No more loot to gain.\nClick to go back to base;";
                }

            }

        }

    }

    #region Functions

    private void EnemySkillQuery()
    {
        deltaSkill += Time.deltaTime;
        if (deltaSkill >= 0.5)
        {
            deltaSkill = 0;
            if (Assist.skillQuery != null && Assist.skillQuery.Length > 0)
            {
                string[] temp = Assist.skillQuery[0].Split('|');
                string enemyid = temp[0];
                string skillid = temp[1];

                temp = Assist.skillQuery;

                if (Assist.skillQuery.Length > 1)
                {
                    Assist.skillQuery = new string[temp.Length - 1];
                    for (int i = 0; i < Assist.skillQuery.Length; i++)
                    {
                        Assist.skillQuery[i] = temp[i + 1];
                    }
                }
                else
                {
                    Assist.skillQuery = null;
                }




                Debug.Log(EnemySkillLibrary.UseSkill(int.Parse(skillid), int.Parse(enemyid), player));
            }
        }
    }

    private void StatsUpdate()
    {
        for (int i = 0; i < CDEffectSkill.Length; i++)
        {
            CDEffectSkill[i].fillAmount = (float)player.SkillCDAct[i] / (float)player.SkillCDMax[i];
            //Debug.Log("i: " + i + " Act: " + (float)player.SkillCDAct[i] + " Max: " + (float)player.SkillCDMax[i] + " r: " + ((float)player.SkillCDAct[i] / (float)player.SkillCDMax[i]));
        }

        playerHPBar.fillAmount = (float)player.healthAct / (float)player.healthMax;
        int lifePercentage = (int)(((float)player.healthAct / (float)player.healthMax) * 100);

        txtplayerHPBar.text = (lifePercentage > 0 ? lifePercentage : 1) + " %";

        //Debug.Log("HPAct: " + player.healthAct + " / HPMax: " + player.healthMax + "  -  r: " + ((float)player.healthAct / (float)player.healthMax));
        playerStamBar.fillAmount = (float)player.staminaAct / (float)player.staminaMax;
        txtplayerStamBar.text = player.staminaAct + " / " + player.staminaMax;
    }

    private void GenerateLoot()
    {
        //loot gen by the enemy's dead
        totalLootBag += Assist.IntGenerator(0, 20) > 10 ? 1 : 0;

        int aux = Assist.IntGenerator(0, 20);
        aux = aux > 20 ? 2 : aux > 10 ? 1 : 0;
        player.chestD += aux;
        totalChest += aux;
        if (aux > 0) return;

        aux = Assist.IntGenerator(0, 20) > 12 ? 1 : 0;
        player.chestC += aux;
        totalChest += aux;
        if (aux > 0) return;

        aux = Assist.IntGenerator(0, 20) > 14 ? 1 : 0;
        player.chestB += aux;
        totalChest += aux;
        if (aux > 0) return;

        aux = Assist.IntGenerator(0, 20) > 16 ? 1 : 0;
        player.chestA += aux;
        totalChest += aux;
        if (aux > 0) return;

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

    #endregion

    #region Events

    public void BtnScreen()
    {

    }
    public void BtnSkill1()
    {
        if (CDEffectSkill[0].fillAmount >= 1)
        {
            player.SkillCDAct[0] = 0;
            if (player.staminaAct >= 1)
            {
                player.staminaAct -= 1;
                player.healthAct += Assist.IntGenerator(10, 15);
            }
        }
    }

    public void BtnSkill2()
    {
        //map.tile[map.actTile].wave[map.actWave].enemy[n].actHp > 0
        for (int i = 0; i < map.tile[map.actTile].wave[map.actWave].enemy.Length; i++)
        {
            if (map.tile[map.actTile].wave[map.actWave].enemy[i].actHp > 0)
            {
                EnemyTap(i);
                return;
            }
        }
    }

    public void BtnSkill3()
    {
        if (CDEffectSkill[2].fillAmount >= 1)
        {

            if (player.staminaAct >= 3)
            {
                player.SkillCDAct[2] = 0;
                player.staminaAct -= 3;
                int r = Assist.IntGenerator(2, 3);
                int[] arr = new int[] { 0, 1, 2, 3, 4 };
                Assist.Randomize(arr);

                int a = 0;
                while (r > 0)
                {
                    if (map.tile[map.actTile].wave[map.actWave].enemy[arr[a]].actHp > 0)
                    {
                        if (map.tile[map.actTile].wave[map.actWave].enemy[arr[a]].Tap())
                        {
                            GenerateLoot();
                        }
                        else
                        {
                            r--;
                            a++;
                        }
                    }
                    else
                    {
                        a++;
                        if (a >= 5)
                        {
                            return;
                        }
                    }
                }
            }

        }
    }

    public void BtnSkill4()
    {

    }

    public void BtnOpenLootBag()
    {
        if (lootBagLeft > 0)
        {
            lootBagLeft--;
            txtLootBagLeft.text = lootBagLeft.ToString();

            int _crst = Assist.IntGenerator(0, 15), _gld = Assist.IntGenerator(1, 25);

            player.magicCrystal += _crst;
            player.gold += _gld;

            txtEndPnlReport.text = "Just got " + _gld + " gold coins and " + _crst + " magic crystals!";
        }


    }

    public void EnemyTap(int n)
    {
        if (CDEffectSkill[1].fillAmount >= 1)
        {

            if (player.staminaAct > 1)
            {
                player.SkillCDAct[1] = 0;
                player.staminaAct--;

                if (map.EnemyTap(n))
                {
                    GenerateLoot();
                }
            }
        }


    }

    public void BtnMap()
    {
        map.ButtonMap();
    }

    public void BtnMapTile(int n)
    {
        map.ButtonMapTile(n);
    }

    public void BtnBackToBase()
    {
        player.Save();
        SceneManager.LoadScene("sceneBase");
    }

    #endregion
}
