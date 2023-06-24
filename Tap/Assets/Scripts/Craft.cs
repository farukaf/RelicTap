using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Craft
{
    public Dropdown dd;
    public Text txtRequeriments, txtItemOptions, txtCraftBar;
    public GameObject imgItem, CraftBar;
    public Button btnCraft;

    private int CraftingItemID = -1;
    private int CraftingBPID;
    private string CraftingItemName = "";
    List<Dropdown.OptionData> dropDownList;

    /// <summary>
    /// Filter Based on Location
    /// 0- Armorsmith, 1- Swordsmith, 2-Tailorsmith, 3-Alchemist
    /// </summary>
    public int type = -1;

    Sprite XIcon;
    Sprite VIcon;
    Sprite voidSprite;

    /// <summary>
    /// When Crafting Started
    /// </summary>
    DateTime startCraft;

    /// <summary>
    /// When Crafting will finish
    /// </summary>
    DateTime endCraft;


    /// <summary>
    /// Delay for craft ends;
    /// </summary>
    public TimeSpan delayCraft = new TimeSpan(0, 0, 30);


    private bool CraftingProgress = false;

    public void Start(Player player)
    {
        if (type == -1)
        {
            Debug.Log("Type not set.");
            Debug.Break();
        }
        XIcon = Resources.LoadAll<Sprite>("XVIcons")[0];
        VIcon = Resources.LoadAll<Sprite>("XVIcons")[1];
        voidSprite = Resources.Load<Sprite>("void");

        PopulateLists(player);
    }

    public void Update(Player player)
    {

        if (CraftingProgress && CraftingItemID != -1)
        {
            ProgressCraft();

            imgItem.GetComponent<Image>().sprite = Assist.AllItemSprites[CraftingItemID];

            if (DateTime.Now > endCraft)
            {
                player.inventory.AddItem(CraftingItemID);
                CraftingItemID = -1;
                CraftingProgress = false;
                CraftBar.SetActive(false);
                dd.interactable = true;
                imgItem.GetComponent<Image>().sprite = voidSprite;
                btnCraft.interactable = false;

                //remove resources from player
                player.gold -= player.bluePrints[CraftingBPID].requeriment.gold;
                player.magicCrystal -= player.bluePrints[CraftingBPID].requeriment.magicCrystal;
                player.spiritCrystal -= player.bluePrints[CraftingBPID].requeriment.spiritCrystal;
                player.spiritOre -= player.bluePrints[CraftingBPID].requeriment.spiritOre;
                player.spiritEssence -= player.bluePrints[CraftingBPID].requeriment.spiritEssence;
                player.demonicEssence -= player.bluePrints[CraftingBPID].requeriment.demonicEssence;
                player.crystalGlass -= player.bluePrints[CraftingBPID].requeriment.crystalGlass;
                player.coal -= player.bluePrints[CraftingBPID].requeriment.coal;
                player.relic -= player.bluePrints[CraftingBPID].requeriment.relic;
                player.herbRed -= player.bluePrints[CraftingBPID].requeriment.herbRed;
                player.herbGreen -= player.bluePrints[CraftingBPID].requeriment.herbGreen;
                player.herbBlue -= player.bluePrints[CraftingBPID].requeriment.herbBlue;
                player.herbWhite -= player.bluePrints[CraftingBPID].requeriment.herbWhite;
                player.herbBlack -= player.bluePrints[CraftingBPID].requeriment.herbBlack;

                PopulateLists(player);


            }
        }


    }

    public void BtnCraft()
    {
        startCraft = DateTime.Now;
        endCraft = DateTime.Now.Add(delayCraft);

        CraftingProgress = true;
        dd.interactable = false;
        CraftBar.SetActive(true);
        btnCraft.interactable = false;
    }

    public void DynamicDropDown(int id, Player player)
    {
        if (id == 0)
        {
            txtRequeriments.text = "";
            imgItem.GetComponent<Image>().sprite = voidSprite;
            btnCraft.interactable = false;
        }
        else
        {
            for (int i = 0; i < player.bluePrints.Length; i++)
            {
                if (player.bluePrints[i].name == dd.options[id].text)
                {
                    txtRequeriments.text = player.bluePrints[i].ItemRequeriments(player);
                    btnCraft.interactable = player.bluePrints[i].CheckRequeriments(player);
                    CraftingItemID = player.bluePrints[i].itemId;
                    CraftingBPID = player.bluePrints[i].id;
                    CraftingItemName = player.bluePrints[i].name;
                    imgItem.GetComponent<Image>().sprite = Assist.AllItemSprites[CraftingItemID];
                }
            }


        }
    }

    public void PopulateLists(Player player)
    {
        if (!CraftingProgress)
        {
            dd.interactable = true;
            dropDownList = new List<Dropdown.OptionData>();
            CraftBar.SetActive(false);

            dropDownList.Add(new Dropdown.OptionData("Select an avaliable BluePrint", voidSprite));
            for (int i = 0; i < player.bluePrints.Length; i++)
            {
                if (player.bluePrints[i].avaliable && player.bluePrints[i].type == type)
                {
                    Dropdown.OptionData _od;

                    if (player.bluePrints[i].CheckRequeriments(player))
                    {
                        _od = new Dropdown.OptionData(player.bluePrints[i].name, VIcon);
                    }
                    else
                    {
                        _od = new Dropdown.OptionData(player.bluePrints[i].name, XIcon);
                    }
                    dropDownList.Add(_od);
                }
            }

            if (dropDownList.Count <= 1)
            {
                dropDownList[0] = new Dropdown.OptionData("NO BLUEPRINTS AVALIABLE");
            }

            dd.ClearOptions();
            dd.AddOptions(dropDownList);
        }
        else
        {
            dd.interactable = false;

            CraftBar.SetActive(true);

        }


    }

    public void ProgressCraft()
    {
        DateTime _end = endCraft;
        TimeSpan t = _end.Subtract(DateTime.Now);

        float fill = (float)((delayCraft.TotalSeconds - t.TotalSeconds) / delayCraft.TotalSeconds);
        CraftBar.GetComponent<Image>().fillAmount = fill;

        if (t < new TimeSpan(1, 00, 00))
            txtCraftBar.text = CraftingItemName + " Crafting " + t.ToString().Substring(3, 5);
        else
            txtCraftBar.text = CraftingItemName + " Crafting " + t.ToString();


        txtRequeriments.text = "";



    }

    /// <summary>
    /// Save actual state of craft
    /// </summary>
    public void SaveState()
    {
        if (!CraftingProgress)
        {
            PlayerPrefs.SetInt(dd.name + "CraftingProgress", 0);
        }
        else
        {
            PlayerPrefs.SetInt(dd.name + "CraftingProgress", 1);
            PlayerPrefs.SetString(dd.name + "StartCraft", startCraft.ToString());
            PlayerPrefs.SetString(dd.name + "EndCraft", endCraft.ToString());
            PlayerPrefs.SetString(dd.name + "Delay", delayCraft.ToString());
            PlayerPrefs.SetInt(dd.name + "CraftingItemID", CraftingItemID);
            PlayerPrefs.SetInt(dd.name + "CraftingBPID", CraftingBPID);
            PlayerPrefs.SetString(dd.name + "CraftingItemName", CraftingItemName);
        }

    }

    /// <summary>
    /// Load if there is a crafting and load it
    /// </summary>
    public void LoadState()
    {
        CraftingProgress = PlayerPrefs.GetInt(dd.name + "CraftingProgress") == 1;

        if (CraftingProgress)
        {
            startCraft = DateTime.Parse(PlayerPrefs.GetString(dd.name + "StartCraft"));
            endCraft = DateTime.Parse(PlayerPrefs.GetString(dd.name + "EndCraft"));
            delayCraft = TimeSpan.Parse(PlayerPrefs.GetString(dd.name + "Delay"));
            CraftingItemID = PlayerPrefs.GetInt(dd.name + "CraftingItemID");
            CraftingBPID = PlayerPrefs.GetInt(dd.name + "CraftingBPID");
            CraftingItemName = PlayerPrefs.GetString(dd.name + "CraftingItemName");
        }
    }
}
