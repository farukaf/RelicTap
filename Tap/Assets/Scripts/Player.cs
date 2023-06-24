using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player
{

    //all variables are changed after loading
    //must load before changing
    public string characterName;
    public string playerName;

    //outfit values
    public int idCape, idBody, idCloths, idWeapon, idHair, idFace, idHat;

    public int rank;

    public int level;
    int levelMax;
    public int exp;
    int expNextLevel; //verificar troca para calculo com tabela de leveis

    //Resources
    public int gold, magicCrystal, spiritCrystal, spiritOre, spiritEssence, demonicEssence,
        crystalGlass, coal, relic, herbRed, herbGreen, herbBlue, herbWhite, herbBlack;

    public BluePrints[] bluePrints;


    public int chestA, chestB, chestC, chestD, chestE;

    public float[] SkillCDMax = new float[] { 30, 4, 15 };
    public float[] SkillCDAct = new float[] { 0, 0, 0 };

    //combat values
    /// <summary>
    /// Max Health Points Main Character
    /// </summary>
    public int healthMax;
    public int healthAct;
    public int hpH1, hpH2;

    public int staminaMax;
    public int staminaAct;//max
    public int powerBase;

    public Inventory inventory = new Inventory();

    public string allResources = "Not Loaded Yet.!! Fix it !!!!";

    /// <summary>
    /// Load all player values
    /// </summary>
    public void Load()
    {
        //inventory.NewGame();

        characterName = PlayerPrefs.GetString("characterName");
        playerName = PlayerPrefs.GetString("playerName");

        idCape = PlayerPrefs.GetInt("idCape");
        idBody = PlayerPrefs.GetInt("idBody");
        idCloths = PlayerPrefs.GetInt("idCloths");
        idWeapon = PlayerPrefs.GetInt("idWeapon");
        idHair = PlayerPrefs.GetInt("idHair");
        idFace = PlayerPrefs.GetInt("idFace");
        idHat = PlayerPrefs.GetInt("idHat");

        rank = PlayerPrefs.GetInt("rank");
        exp = PlayerPrefs.GetInt("exp");

        healthMax = PlayerPrefs.GetInt("hpMC");
        staminaMax = PlayerPrefs.GetInt("staminaMax");
        powerBase = PlayerPrefs.GetInt("powerBase");

        chestA = PlayerPrefs.GetInt("chestA");
        chestB = PlayerPrefs.GetInt("chestB");
        chestC = PlayerPrefs.GetInt("chestC");
        chestD = PlayerPrefs.GetInt("chestD");
        chestE = PlayerPrefs.GetInt("chestE");

        //Resources
        gold = PlayerPrefs.GetInt("gold");
        magicCrystal = PlayerPrefs.GetInt("magicCrystal");
        spiritCrystal = PlayerPrefs.GetInt("spiritCrystal");
        spiritOre = PlayerPrefs.GetInt("spiritOre");
        spiritEssence = PlayerPrefs.GetInt("spiritEssence");
        demonicEssence = PlayerPrefs.GetInt("demonicEssence");
        crystalGlass = PlayerPrefs.GetInt("crystalGlass");
        coal = PlayerPrefs.GetInt("coal");
        relic = PlayerPrefs.GetInt("relic");
        herbRed = PlayerPrefs.GetInt("herbRed");
        herbGreen = PlayerPrefs.GetInt("herbGreen");
        herbBlue = PlayerPrefs.GetInt("herbBlue");
        herbWhite = PlayerPrefs.GetInt("herbWhite");
        herbBlack = PlayerPrefs.GetInt("herbBlack");

        LoadResources();

        BluePrints _bps = new BluePrints();

        bluePrints = new BluePrints[_bps._avaliableBPS];

        for (int i = 0; i < bluePrints.Length; i++)
        {
            bluePrints[i] = new BluePrints() { id = i, avaliable = PlayerPrefs.GetInt("bluePrint" + i) == 1 };
            bluePrints[i].Load();
        }

        inventory.Load();

    }


    /// <summary>
    /// Load all player values
    /// </summary>
    public void Load(bool showStatus)
    {
        Load();

        if (showStatus) FullStats();

    }

    public void Stats()
    {
        string stats = "";

        stats += " CharName: " + characterName + "\n";
        stats += " PlayerName: " + playerName + "\n";
        stats += " IDLenght: " + idCape + "." + idBody + "." + idCloths + "." + idWeapon + "." + idHair + "." + idFace + "." + idHat + "\n";
        stats += " Rank: " + rank + "\n";
        stats += " Exp: " + exp + "\n";
        stats += " Gold: " + gold + "\n";
        stats += " Crystal: " + magicCrystal + "\n";
        stats += " HPMax: " + healthMax + "\n";
        stats += " StMax: " + staminaMax + "\n";
        //stats += " PowerB: " + powerBase + "\n";
        stats += " ChestA: " + chestA + "\n";
        stats += " ChestB: " + chestB + "\n";
        stats += " ChestC: " + chestC + "\n";
        stats += " ChestD: " + chestD + "\n";

        //stats += "Inventory:\n";
        //for (int i = 0; i < inventory.items.Length; i++)
        //{
        //    stats += "   (" + (i + 1) + "): ID: " + inventory.items[i].id + " Name: " + inventory.items[i].itemName + "\n";
        //}

        //stats += "Equips:\n";
        //for (int i = 0; i < inventory.equips.Length; i++)
        //{
        //    stats += "   (" + (i + 1) + "): ID: " + inventory.equips[i].id + " Name: " + inventory.equips[i].itemName + "\n";
        //}

        Debug.Log(stats);
    }

    public void FullStats()
    {
        string stats = "";

        stats += " CharName: " + characterName + "\n";
        stats += " PlayerName: " + playerName + "\n";
        stats += " IDLenght: " + idCape + "." + idBody + "." + idCloths + "." + idWeapon + "." + idHair + "." + idFace + "." + idHat + "\n";
        stats += " Rank: " + rank + "\n";
        stats += " Exp: " + exp + "\n";
        stats += " HPMax: " + healthMax + "\n";
        stats += " StMax: " + staminaMax + "\n";
        stats += " PowerB: " + powerBase + "\n";
        stats += " ChestA: " + chestA + "\n";
        stats += " ChestB: " + chestB + "\n";
        stats += " ChestC: " + chestC + "\n";
        stats += " ChestD: " + chestD + "\n";
        stats += "\n";

        //Resources
        stats += " Gold: " + gold + "\n";
        stats += " MagicCrystal: " + magicCrystal + "\n";
        stats += " SpiritCrystal: " + spiritCrystal + "\n";
        stats += " SpiritOre: " + spiritOre + "\n";
        stats += " SpiritEssence: " + spiritEssence + "\n";
        stats += " DemonicEssence: " + demonicEssence + "\n";
        stats += " CrystalGlass: " + crystalGlass + "\n";
        stats += " Coal: " + coal + "\n";
        stats += " Relic: " + relic + "\n";
        stats += " HerbRed: " + herbRed + "\n";
        stats += " HerbGreen: " + herbGreen + "\n";
        stats += " HerbBlue: " + herbBlue + "\n";
        stats += " HerbWhite: " + herbWhite + "\n";
        stats += " HerbBlack: " + herbBlack + "\n";
        stats += "\n";

        stats += "Inventory:\n";
        for (int i = 0; i < inventory.items.Length; i++)
        {
            stats += "   (" + (i + 1) + "): ID: " + inventory.items[i].id + " Name: " + inventory.items[i].itemName + "\n";
        }
        stats += "\n";

        stats += "Equips:\n";
        for (int i = 0; i < inventory.equips.Length; i++)
        {
            stats += "   (" + (i + 1) + "): ID: " + inventory.equips[i].id + " Name: " + inventory.equips[i].itemName + "\n";
        }

        Debug.Log(stats);
    }

    private void LoadResources()
    {
        allResources = "";
        allResources += " Gold: " + gold + "\n";
        allResources += " MagicCrystal: " + magicCrystal + "\n";
        allResources += " SpiritCrystal: " + spiritCrystal + "\n";
        allResources += " SpiritOre: " + spiritOre + "\n";
        allResources += " SpiritEssence: " + spiritEssence + "\n";
        allResources += " DemonicEssence: " + demonicEssence + "\n";
        allResources += " CrystalGlass: " + crystalGlass + "\n";
        allResources += " Coal: " + coal + "\n";
        allResources += " Relic: " + relic + "\n";
        allResources += " HerbRed: " + herbRed + "\n";
        allResources += " HerbGreen: " + herbGreen + "\n";
        allResources += " HerbBlue: " + herbBlue + "\n";
        allResources += " HerbWhite: " + herbWhite + "\n";
        allResources += " HerbBlack: " + herbBlack;
    }

    public void HuntUpdate()
    {
        for (int i = 0; i < SkillCDAct.Length; i++)
        {
            SkillCDAct[i] += Time.deltaTime;
        }
        
       

    }



    /// <summary>
    /// Save all player values
    /// </summary>
    public void Save()
    {
        PlayerPrefs.SetInt("newGame", 1);

        PlayerPrefs.SetString("characterName", characterName);
        PlayerPrefs.SetString("playerName", playerName);

        PlayerPrefs.SetInt("rank", rank);
        PlayerPrefs.SetInt("exp", exp);

        PlayerPrefs.SetInt("hpMC", healthMax);
        PlayerPrefs.SetInt("staminaMax", staminaMax);
        PlayerPrefs.SetInt("powerBase", powerBase);

        PlayerPrefs.SetInt("chestA", chestA);
        PlayerPrefs.SetInt("chestB", chestB);
        PlayerPrefs.SetInt("chestC", chestC);
        PlayerPrefs.SetInt("chestD", chestD);
        PlayerPrefs.SetInt("chestE", chestE);

        //Resources
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("magicCrystal", magicCrystal);
        PlayerPrefs.SetInt("spiritCrystal", spiritCrystal);
        PlayerPrefs.SetInt("spiritOre", spiritOre);
        PlayerPrefs.SetInt("spiritEssence", spiritEssence);
        PlayerPrefs.SetInt("demonicEssence", demonicEssence);
        PlayerPrefs.SetInt("crystalGlass", crystalGlass);
        PlayerPrefs.SetInt("coal", coal);
        PlayerPrefs.SetInt("relic", relic);
        PlayerPrefs.SetInt("herbRed", herbRed);
        PlayerPrefs.SetInt("herbGreen", herbGreen);
        PlayerPrefs.SetInt("herbBlue", herbBlue);
        PlayerPrefs.SetInt("herbWhite", herbWhite);
        PlayerPrefs.SetInt("herbBlack", herbBlack);

        for (int i = 0; i < bluePrints.Length; i++)
        {
            PlayerPrefs.SetInt("bluePrint" + i, bluePrints[i].avaliable ? 1 : 0);
        }

        inventory.Save();
        Debug.Log("Player Saved!");
    }

    public void SaveOutfit()
    {
        PlayerPrefs.SetInt("idCape", idCape);
        PlayerPrefs.SetInt("idBody", idBody);
        PlayerPrefs.SetInt("idCloths", idCloths);
        PlayerPrefs.SetInt("idWeapon", idWeapon);
        PlayerPrefs.SetInt("idHair", idHair);
        PlayerPrefs.SetInt("idFace", idFace);
        PlayerPrefs.SetInt("idHat", idHat);
    }

    /// <summary>
    /// Load NewGame values  
    /// </summary>
    public void NewGame()
    {
        Debug.Log("Loaded New Game!");
        PlayerPrefs.DeleteAll();

        characterName = "Armin";
        playerName = "Horace";

        idCape = 0;
        idBody = 0;
        idCloths = 0;
        idWeapon = 0;
        idHair = 0;
        idFace = 0;
        idHat = 0;

        rank = 0;
        exp = 0;

        healthMax = 1000;
        staminaMax = 25;
        powerBase = 10;

        //resources
        gold = 0;
        magicCrystal = 0;
        spiritCrystal = 0;
        spiritOre = 0;
        spiritEssence = 0;
        demonicEssence = 0;
        crystalGlass = 0;
        coal = 0;
        relic = 0;
        herbRed = 0;
        herbGreen = 0;
        herbBlue = 0;
        herbWhite = 0;
        herbBlack = 0;


        chestA = 0;
        chestB = 0;
        chestC = 0;
        chestD = 0;
        chestE = 0;

        BluePrints _bps = new BluePrints();

        bluePrints = new BluePrints[_bps._avaliableBPS];

        for (int i = 0; i < bluePrints.Length; i++)
        {
            bluePrints[i] = new BluePrints() { id = i };
            bluePrints[i].Load();
        }

        inventory.NewGame();

        Save();
        LoadResources();

    }


}


