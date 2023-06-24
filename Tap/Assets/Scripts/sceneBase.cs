using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class sceneBase : MonoBehaviour
{
    private Player player;

    /// <summary>
    /// list of items for comparasion
    /// </summary>
    private Items[] compareItems;

    //AvatarPanel TxtAvatarIptFName,
    public InputField AvatarIptFName;
    public Text TxtPlayerStatsAvatar, TxtPlayerResources;
    public GameObject AvatarPnl;
    private Vector3 AvatarPnlStartPos, AvatarPnlEndPos = new Vector3(360, 640, 0), AvatarPnlPos;

    //DropDownSetup
    #region DropDownSetup
    public GameObject ArmorsmithErminePnl;
    private Vector3 ArmorsmithErminePnlStartPos, ArmorsmithErminePnlEndPos = new Vector3(360, 640, 0), ArmorsmithErminePnlPos;
    public Craft Armorsmith;

    public GameObject SwordsmithErminePnl;
    private Vector3 SwordsmithErminePnlStartPos, SwordsmithErminePnlEndPos = new Vector3(360, 640, 0), SwordsmithErminePnlPos;
    public Craft Swordsmith;

    public GameObject TailorsmithErminePnl;
    private Vector3 TailorsmithErminePnlStartPos, TailorsmithErminePnlEndPos = new Vector3(360, 640, 0), TailorsmithErminePnlPos;
    public Craft Tailorsmith;

    public GameObject AlchemistErminePnl;
    private Vector3 AlchemistErminePnlStartPos, AlchemistErminePnlEndPos = new Vector3(360, 640, 0), AlchemistErminePnlPos;
    public Craft Alchemist;
    #endregion

    public GameObject HeadquarterErminePnl;
    private Vector3 HeadquarterErminePnlStartPos, HeadquarterErminePnlEndPos = new Vector3(360, 640, 0), HeadquarterErminePnlPos;

    public GameObject LocksmithErminePnl;
    private Vector3 LocksmithErminePnlStartPos, LocksmithErminePnlEndPos = new Vector3(360, 640, 0), LocksmithErminePnlPos;
    public Text LocksmithReportTxt, LocksmithChestA, LocksmithChestB, LocksmithChestC, LocksmithChestD;

    public GameObject OverlayCanvas;
    private Vector3 OverlayCanvasPos;

    public GameObject DressRoomPnl;
    private Vector3 DressRoomPnlPos, DressRoomPnlEndPos = new Vector3(360, 640, 0), DressRoomPnlStartPos;

    public GameObject EquipPnl, CustomizePnl;

    public DressRoomInventory dressRoomInventory;
    public GameObject ItemInfoImgSlot;
    public Text txtItemInfo;
    public Sprite voidSprite;
    private HoldItems Hold = new HoldItems();

    public GameObject[] HLInventoryGrid, HLEquipGrid;

    public Text txtGold, txtCrystal;

    Sprite XIcon;
    Sprite VIcon;

    // Use this for initialization
    void Start()
    {
        XIcon = Resources.LoadAll<Sprite>("XVIcons")[0];
        VIcon = Resources.LoadAll<Sprite>("XVIcons")[1];

        player = new Player();
        LoadAll(true);

        LoadPanelPositions();

        dressRoomInventory.Load(player);

        CompareItemsConstruct();

        LoadAvatarPanelValues();

        //DropDownSetup
        Armorsmith.type = 0;
        Armorsmith.Start(player);
        Swordsmith.type = 1;
        Swordsmith.Start(player);
        Tailorsmith.type = 2;
        Tailorsmith.Start(player);
        Alchemist.type = 3;
        Alchemist.Start(player);

    }



    // Update is called once per frame
    void Update()
    {
        UpdateInventorySprites();

        SmoothMovesPack();

        ChestUpdate();

        UpdateItemInfo();


        //DropDownSetup
        Armorsmith.Update(player);
        Swordsmith.Update(player);
        Tailorsmith.Update(player);
        Alchemist.Update(player);


        SaveAll();
    }


    #region Events

    public void AvatarInputFieldEnd(string field)
    {
        player.characterName = field;
        player.Save();
    }

    //DropDownSetup
    #region DropDownSetup
    public void ArmorsmithDropDown(int id)
    {
        Armorsmith.DynamicDropDown(id, player);
    }

    public void BtnArmorsmith()
    {
        Armorsmith.PopulateLists(player);
        ArmorsmithErminePnlPos = ArmorsmithErminePnlEndPos;
    }

    public void BtnArmorsmithCraft()
    {
        Armorsmith.BtnCraft();
    }

    public void BtnArmorsmithReturn()
    {
        ArmorsmithErminePnlPos = ArmorsmithErminePnlStartPos;
    }

    public void SwordsmithDropDown(int id)
    {
        Swordsmith.DynamicDropDown(id, player);
    }

    public void BtnSwordsmith()
    {
        Swordsmith.PopulateLists(player);
        SwordsmithErminePnlPos = SwordsmithErminePnlEndPos;
    }

    public void BtnSwordsmithCraft()
    {
        Swordsmith.BtnCraft();
    }

    public void BtnSwordsmithReturn()
    {
        SwordsmithErminePnlPos = SwordsmithErminePnlStartPos;
    }

    public void TailorsmithDropDown(int id)
    {
        Tailorsmith.DynamicDropDown(id, player);
    }

    public void BtnTailorsmith()
    {
        Tailorsmith.PopulateLists(player);
        TailorsmithErminePnlPos = TailorsmithErminePnlEndPos;
    }

    public void BtnTailorsmithCraft()
    {
        Tailorsmith.BtnCraft();
    }

    public void BtnTailorsmithReturn()
    {
        TailorsmithErminePnlPos = TailorsmithErminePnlStartPos;
    }

    public void AlchemistDropDown(int id)
    {
        Alchemist.DynamicDropDown(id, player);
    }

    public void BtnAlchemist()
    {
        Alchemist.PopulateLists(player);
        AlchemistErminePnlPos = AlchemistErminePnlEndPos;
    }

    public void BtnAlchemistCraft()
    {
        Alchemist.BtnCraft();
    }

    public void BtnAlchemistReturn()
    {
        AlchemistErminePnlPos = AlchemistErminePnlStartPos;
    }
    #endregion


    /// <summary>
    /// Realiza açoes dependendo do estado do botão
    /// </summary>
    /// <param name="n"></param>
    public void BtnInventorySlot(int n)
    {
        if (HLInventoryGrid[n].activeSelf)
        {
            if (Hold.HoldInventoryID != -1 && Hold.HoldEquipID == -1)
            {
                player.inventory.items[Hold.HoldInventoryID].id = player.inventory.items[n].id;
                player.inventory.items[n].id = Hold.HoldItemID;
            }
            else if (Hold.HoldInventoryID == -1 && Hold.HoldEquipID != -1)
            {
                player.inventory.equips[Hold.HoldEquipID].id = player.inventory.items[n].id;
                player.inventory.items[n].id = Hold.HoldItemID;
            }
            else
            {
                Debug.Log("Erro ao definir IDs Hold.\nHoldInvID: " + Hold.HoldInventoryID + " HoldEqID: " + Hold.HoldEquipID);
                Debug.Break();
            }
            UnHLInventory();
        }
        else if (CheckHLInventory())
        {
            UnHLInventory();
        }
        else if (player.inventory.items[n].id != -1)
        {
            Hold.HoldItemID = player.inventory.items[n].id;
            Hold.HoldInventoryID = n;

            HLInventory();
        }

    }

    /// <summary>
    /// Realiza açoes dependendo do estado do botão
    /// </summary>
    /// <param name="n"></param>
    public void BtnEquipsSlot(int n)
    {
        if (HLEquipGrid[n].activeSelf)
        {
            if (Hold.HoldInventoryID != -1 && Hold.HoldEquipID == -1)
            {
                player.inventory.items[Hold.HoldInventoryID].id = player.inventory.equips[n].id;
                player.inventory.equips[n].id = Hold.HoldItemID;
            }
            else if (Hold.HoldInventoryID == -1 && Hold.HoldEquipID != -1)
            {
                player.inventory.equips[Hold.HoldEquipID].id = player.inventory.equips[n].id;
                player.inventory.equips[n].id = Hold.HoldItemID;
            }
            else
            {
                Debug.Log("Erro ao definir IDs Hold.");
                Debug.Break();
            }
            UnHLInventory();
        }
        else if (CheckHLInventory())
        {
            UnHLInventory();
        }
        else if (player.inventory.equips[n].id != -1)
        {
            Hold.HoldItemID = player.inventory.equips[n].id;
            Hold.HoldEquipID = n;

            HLInventory();
        }
    }

    public void BtnUnSelectObjects()
    {
        UnHLInventory();

    }

    public void BtnDressRoomEquip()
    {
        CustomizePnl.SetActive(false);
        EquipPnl.SetActive(true);
    }

    public void BtnDressRoomCustomize()
    {
        CustomizePnl.SetActive(true);
        EquipPnl.SetActive(false);
    }

    public void BtnAvatar()
    {
        LoadAvatarPanelValues();

        if (AvatarPnlPos == AvatarPnlStartPos)
            AvatarPnlPos = AvatarPnlEndPos;
        else
            AvatarPnlPos = AvatarPnlStartPos;
    }

    public void BtnAvatarReturn()
    {
        AvatarPnlPos = AvatarPnlStartPos;
    }

    public void BtnDressRoom()
    {
        BtnDressRoomEquip();

        if (DressRoomPnlPos == DressRoomPnlStartPos)
        {
            DressRoomPnlPos = DressRoomPnlEndPos;
        }
    }

    public void BtnDressRoomReturn()
    {
        if (DressRoomPnlPos == DressRoomPnlEndPos)
        {
            DressRoomPnlPos = DressRoomPnlStartPos;
        }
    }

    public void BtnLocksmith()
    {
        LocksmithErminePnlPos = LocksmithErminePnlEndPos;
    }

    public void BtnLocksmithReturn()
    {
        LocksmithErminePnlPos = LocksmithErminePnlStartPos;
    }

    public void BtnHeadQuarter()
    {
        HeadquarterErminePnlPos = HeadquarterErminePnlEndPos;
    }

    public void BtnHeadQuarterHunt()
    {
        SaveAll();
        SceneManager.LoadScene("sceneHunt");
    }

    public void BtnHeadQuarterReturn()
    {
        HeadquarterErminePnlPos = HeadquarterErminePnlStartPos;
    }

    public void BtnSave()
    {
        SaveAll();
    }

    public void Clear()
    {
        Debug.ClearDeveloperConsole();
    }

    public void CMD(string str)
    {
        str.ToLower();
        Debug.Log(str);
        if (str != null)
        {
            try
            {


                switch (str)
                {
                    case "new game":
                    case "newgame":
                    case "ng":

                        player.NewGame();
                        player.Load();
                        dressRoomInventory.Load(player);
                        break;
                    case "playerstats":
                        player.Stats();
                        break;
                    //default:
                    //    Debug.Log("Command " + str + " not found.");
                    //    break;

                    case "chest+":
                    case "morechests":
                        player.chestA += 10;
                        player.chestB += 10;
                        player.chestC += 10;
                        player.chestD += 10;

                        player.gold += 9000;
                        break;
                    case "clearinventory":
                    case "inventoryclear":
                        for (int i = 0; i < player.inventory.items.Length; i++)
                        {
                            player.inventory.RemoveItem(i);
                        }
                        break;

                    case "greedisgood":
                    case "moreresources":
                        player.gold += 999;
                        player.magicCrystal += 999;
                        player.spiritCrystal += 999;
                        player.spiritOre += 999;
                        player.spiritEssence += 999;
                        player.demonicEssence += 999;
                        player.crystalGlass += 999;
                        player.coal += 999;
                        player.relic += 999;
                        player.herbRed += 999;
                        player.herbGreen += 999;
                        player.herbBlue += 999;
                        player.herbWhite += 999;
                        player.herbBlack += 999;
                        break;
                }
            }
            catch
            {
                Debug.Log("CMD Fail! " + str + " is not a valid string command.");
            }

        }

    }

    #endregion


    #region Functions

    private void LoadPanelPositions()
    {
        DressRoomPnlPos = DressRoomPnl.transform.position;
        DressRoomPnlStartPos = DressRoomPnl.transform.position;
        OverlayCanvasPos = OverlayCanvas.transform.position;

        HeadquarterErminePnlPos = HeadquarterErminePnl.transform.position;
        HeadquarterErminePnlStartPos = HeadquarterErminePnl.transform.position;

        LocksmithErminePnlPos = LocksmithErminePnl.transform.position;
        LocksmithErminePnlStartPos = LocksmithErminePnl.transform.position;

        AvatarPnlPos = AvatarPnl.transform.position;
        AvatarPnlStartPos = AvatarPnl.transform.position;


        //DropDownSetup Panels
        ArmorsmithErminePnlPos = ArmorsmithErminePnl.transform.position;
        ArmorsmithErminePnlStartPos = ArmorsmithErminePnl.transform.position;

        SwordsmithErminePnlPos = SwordsmithErminePnl.transform.position;
        SwordsmithErminePnlStartPos = SwordsmithErminePnl.transform.position;

        TailorsmithErminePnlPos = TailorsmithErminePnl.transform.position;
        TailorsmithErminePnlStartPos = TailorsmithErminePnl.transform.position;

        AlchemistErminePnlPos = AlchemistErminePnl.transform.position;
        AlchemistErminePnlStartPos = AlchemistErminePnl.transform.position;

    }

    private void SaveAll()
    {
        player.Save();
        //DropDownSetup
        Armorsmith.SaveState();
        Swordsmith.SaveState();
        Tailorsmith.SaveState();
        Alchemist.SaveState();
    }

    private void LoadAll(bool stats)
    {
        player.Load(stats);
        //DropDownSetup
        Armorsmith.LoadState();
        Swordsmith.LoadState();
        Tailorsmith.LoadState();
        Alchemist.LoadState();
    }

    private void LoadAvatarPanelValues()
    {
        AvatarIptFName.text = player.characterName;
        TxtPlayerResources.text = player.allResources;
    }

    private void UpdateInventorySprites()
    {
        SaveAll();
        player.Load();
        dressRoomInventory.Load(player);
    }

    /// <summary>
    /// Desativa os HighLight de todos os botões inventory/equip
    /// </summary>
    private void UnHLInventory()
    {
        Hold.UnHold();
        for (int i = 0; i < HLEquipGrid.Length; i++)
        {
            HLEquipGrid[i].SetActive(false);
        }

        for (int i = 0; i < HLInventoryGrid.Length; i++)
        {
            HLInventoryGrid[i].SetActive(false);
        }
    }

    /// <summary>
    /// Ativa os HighLight de todos os botões inventory/equip dependendo do estado de hold.holditemid
    /// </summary>
    private void HLInventory()
    {
        //string report = "";

        //try
        //{
        //    report += "HoldItemID: " + Hold.HoldItemID + " type: " + compareItems[Hold.HoldItemID].type + "\n ";
        //}
        //catch (Exception)
        //{
        //}

        //try
        //{
        //    report += "HoldEqID: " + Hold.HoldEquipID + " type: " + compareItems[Hold.HoldEquipID].type + "\n ";
        //}
        //catch (Exception)
        //{
        //}

        //try
        //{
        //    report += "HoldInvID" + Hold.HoldInventoryID + " type: " + compareItems[Hold.HoldInventoryID].type + "\n ";
        //}
        //catch (Exception)
        //{
        //}


        for (int i = 0; i < dressRoomInventory.slots.Length; i++)
        {
            if (Hold.HoldInventoryID != -1)
            {
                if (Hold.HoldInventoryID != i)
                {
                    HLInventoryGrid[i].SetActive(true);
                }
            }
            else if (Hold.HoldEquipID != -1)
            {
                int type = compareItems[Hold.HoldItemID].type;

                if (player.inventory.items[i].id == -1 || player.inventory.items[i].type == type)
                {
                    HLInventoryGrid[i].SetActive(true);
                }
            }
            
        }

        switch (compareItems[Hold.HoldItemID].type)
        {
            case 0:
                HLEquipGrid[0].SetActive(true);
                break;
            case 1:
                HLEquipGrid[3].SetActive(true);
                break;
            case 2:
                HLEquipGrid[1].SetActive(true);
                HLEquipGrid[2].SetActive(true);
                HLEquipGrid[4].SetActive(true);
                HLEquipGrid[5].SetActive(true);
                break;

        }
        //Debug.Log(report);
    }

    private bool CheckHLInventory()
    {
        for (int i = 0; i < HLEquipGrid.Length; i++)
        {
            if (HLEquipGrid[i].activeSelf)
            {
                return true;
            }
        }

        for (int i = 0; i < HLInventoryGrid.Length; i++)
        {
            if (HLInventoryGrid[i].activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    private void UpdateItemInfo()
    {
        if (Hold.HoldItemID != -1)
        {
            Items i = new Items() { id = Hold.HoldItemID };
            i.Load();
            ItemInfoImgSlot.GetComponent<Image>().sprite = i.sprite;
            txtItemInfo.text = i.itemName + "\n\n" + i.description;
        }
        else
        {
            ItemInfoImgSlot.GetComponent<Image>().sprite = voidSprite;
            txtItemInfo.text = "--";

        }
    }

    private void ChestUpdate()
    {
        LocksmithChestA.text = player.chestA.ToString();
        LocksmithChestB.text = player.chestB.ToString();
        LocksmithChestC.text = player.chestC.ToString();
        LocksmithChestD.text = player.chestD.ToString();
    }

    /// <summary>
    /// Open Chest and Generate loot;
    /// </summary>
    /// <param name="n">0-A, 1-B ...</param>
    public void OpenChest(int n)
    {
        switch (n)
        {
            //A
            case 0:
                if (player.chestA > 0)
                {
                    player.chestA--;
                    //Generate loot for chestA

                    LocksmithReportTxt.text += "\n" + ChestLootGen(n);
                }

                break;
            //B
            case 1:
                if (player.chestB > 0)
                {
                    player.chestB--;
                    //Generate loot for chestB
                    LocksmithReportTxt.text += "\n" + ChestLootGen(n);
                }
                break;
            //C
            case 2:
                if (player.chestC > 0)
                {
                    player.chestC--;
                    //Generate loot for chestC
                    LocksmithReportTxt.text += "\n" + ChestLootGen(n);
                }
                break;
            //D
            case 3:
                if (player.chestD > 0)
                {
                    player.chestD--;
                    //Generate loot for chestD
                    LocksmithReportTxt.text += "\n" + ChestLootGen(n);
                }
                break;
        }


    }

    private string ChestLootGen(int n)
    {
        string str = "";
        int aux;
        switch (n)
        {
            //A
            case 0:
                aux = Assist.IntGenerator(0, 120);
                player.gold += aux;
                if (aux > 0)
                {
                    str += "Gold:" + aux;
                }

                aux = Assist.IntGenerator(0, 38);
                player.magicCrystal += aux;
                if (aux > 0)
                {
                    str += ", Magic Crystal:" + aux;
                }

                aux = Assist.IntGenerator(0, 3);
                player.spiritEssence += aux;
                if (aux > 0)
                {
                    str += ", Spirit Essence:" + aux;
                }

                aux = Assist.IntGenerator(0, 3);
                player.demonicEssence += aux;
                if (aux > 0)
                {
                    str += ", Demonic Essence:" + aux;
                }

                aux = Assist.IntGenerator(0, 1);
                player.herbBlack += aux;
                if (aux > 0)
                {
                    str += ", Black Herb:" + aux + "!";
                }

                aux = Assist.IntGenerator(0, 1);
                player.relic += aux;
                if (aux > 0)
                {
                    str += ", Relic:" + aux + "!!!!";
                }
                break;
            //B
            case 1:
                aux = Assist.IntGenerator(0, 80);
                player.gold += aux;
                if (aux > 0)
                {
                    str += "Gold:" + aux;
                }
                aux = Assist.IntGenerator(0, 18);
                player.magicCrystal += aux;
                if (aux > 0)
                {
                    str += ", Magic Crystal:" + aux;
                }
                aux = Assist.IntGenerator(0, 6);
                player.spiritOre += aux;
                if (aux > 0)
                {
                    str += ", Spirit Ore:" + aux;
                }
                aux = Assist.IntGenerator(0, 8);
                player.crystalGlass += aux;
                if (aux > 0)
                {
                    str += ", Crystal Glass:" + aux;
                }
                aux = Assist.IntGenerator(0, 10);
                player.spiritCrystal += aux;
                if (aux > 0)
                {
                    str += ", Spirit Crystal :" + aux;
                }
                aux = Assist.IntGenerator(0, 9);
                player.herbGreen += aux;
                if (aux > 0)
                {
                    str += ", Green Herb:" + aux;
                }
                aux = Assist.IntGenerator(0, 7);
                player.herbBlue += aux;
                if (aux > 0)
                {
                    str += ", Blue Herb:" + aux;
                }
                aux = Assist.IntGenerator(0, 2);
                player.herbWhite += aux;
                if (aux > 0)
                {
                    str += ", White Herb:" + aux + "!";
                }
                break;


            //C
            case 2:
                aux = Assist.IntGenerator(0, 80);
                player.gold += aux;
                if (aux > 0)
                {
                    str += "Gold:" + aux;
                }
                aux = Assist.IntGenerator(0, 18);
                player.magicCrystal += aux;
                if (aux > 0)
                {
                    str += ", Magic Crystal:" + aux;
                }
                aux = Assist.IntGenerator(0, 8);
                player.crystalGlass += aux;
                if (aux > 0)
                {
                    str += ", Crystal Glass:" + aux;
                }
                aux = Assist.IntGenerator(0, 13);
                player.coal += aux;
                if (aux > 0)
                {
                    str += ", Coal:" + aux;
                }
                aux = Assist.IntGenerator(0, 8);
                player.herbRed += aux;
                if (aux > 0)
                {
                    str += ", Red Herb:" + aux;
                }
                aux = Assist.IntGenerator(0, 2);
                player.herbBlue += aux;
                if (aux > 0)
                {
                    str += ", Blue Herb:" + aux;
                }
                break;
            //D
            case 3:
                aux = Assist.IntGenerator(0, 30);
                player.gold += aux;
                if (aux > 0)
                {
                    str += "Gold:" + aux;
                }

                aux = Assist.IntGenerator(0, 12);
                player.magicCrystal += aux;
                if (aux > 0)
                {
                    str += ", Magic Crystal:" + aux;
                }

                aux = Assist.IntGenerator(0, 3);
                player.spiritOre += aux;
                if (aux > 0)
                {
                    str += ", Spirit Ore:" + aux;
                }

                aux = Assist.IntGenerator(0, 4);
                player.coal += aux;
                if (aux > 0)
                {
                    str += ", Coal:" + aux;
                }

                aux = Assist.IntGenerator(0, 2);
                player.spiritCrystal += aux;
                if (aux > 0)
                {
                    str += ", Spirit Crystal:" + aux;
                }

                aux = Assist.IntGenerator(0, 3);
                player.herbRed += aux;
                if (aux > 0)
                {
                    str += ", Red Herb:" + aux;
                }
                break;
        }

        return str;
    }

    private void SmoothMovesPack()
    {
        SmoothMove(DressRoomPnl, DressRoomPnlPos);
        SmoothMove(HeadquarterErminePnl, HeadquarterErminePnlPos);
        SmoothMove(LocksmithErminePnl, LocksmithErminePnlPos);
        SmoothMove(AvatarPnl, AvatarPnlPos);

        //DropDownSetup Pnl
        SmoothMove(ArmorsmithErminePnl, ArmorsmithErminePnlPos);
        SmoothMove(SwordsmithErminePnl, SwordsmithErminePnlPos);
        SmoothMove(TailorsmithErminePnl, TailorsmithErminePnlPos);
        SmoothMove(AlchemistErminePnl, AlchemistErminePnlPos);


    }

    private void VerticalSmoothMove(GameObject gameObj, float target)
    {
        int _min = 2; // Diferença minima para colocar no lugar
        int _slideSpeed = 10; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)

        if (target != gameObj.transform.position.y)
        {
            float _translate = gameObj.transform.position.y - target > _min || gameObj.transform.position.y - target < -_min ?
                -(gameObj.transform.position.y - target) / _slideSpeed :
                -(gameObj.transform.position.y - target);

            gameObj.transform.Translate(0, _translate, 0);
        }
    }

    private void HorizontalSmoothMove(GameObject gameObj, float target)
    {
        int _min = 2; // Diferença minima para colocar no lugar
        int _slideSpeed = 10; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)

        if (target != gameObj.transform.position.x)
        {
            float _translate = gameObj.transform.position.x - target > _min || gameObj.transform.position.x - target < -_min ?
                -(gameObj.transform.position.x - target) / _slideSpeed :
                -(gameObj.transform.position.x - target);

            gameObj.transform.Translate(_translate, 0, 0);
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

    private void SmoothMove(GameObject gameObj, Vector2 target)
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
    }

    private void CompareItemsConstruct()
    {
        compareItems = new Items[1];
        compareItems[0] = new Items() { id = 0 };
        compareItems[0].Load();
        int _n = compareItems[0]._size;

        compareItems = new Items[_n];

        for (int i = 0; i < compareItems.Length; i++)
        {
            compareItems[i] = new Items() { id = i };
            compareItems[i].Load();
        }
    }



    #endregion


}