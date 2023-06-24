using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class BluePrints
{
    /// <summary>
    /// Have to be the amount of BLueprints made
    /// </summary>
    public int _avaliableBPS = 15;

    public Sprite sprite;
    public string name;
    /// <summary>
    /// 0- Armorsmith, 1- Swordsmith, 2-Tailorsmith, 3-Alchemist
    /// </summary>
    public int type;
    public int id;
    public int itemId;
    public bool avaliable = false;
    public Requeriment requeriment;


    public void Load()
    {
        switch (id)
        {
            case 0:
                type = 0;
                itemId = 41;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 100, magicCrystal = 20, spiritOre = 10, coal = 5 };
                avaliable = true;
                break;
            case 1:
                type = 0;
                itemId = 43;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 1000, magicCrystal = 20, spiritOre = 10, coal = 5 };
                avaliable = true;
                break;
            case 2:
                type = 0;
                itemId = 42;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 200, magicCrystal = 20, crystalGlass = 10 };
                avaliable = true;
                break;
            case 3:
                type = 0;
                itemId = 67;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, demonicEssence = 10 };
                avaliable = true;
                break;
            case 4:
                type = 1;
                itemId = 4;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 250, spiritOre = 15, coal = 12, demonicEssence = 20 };
                avaliable = true;
                break;
            case 5:
                type = 1;
                itemId = 36;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, relic = 1 };
                avaliable = true;
                break;
            case 6:
                type = 1;
                itemId = 63;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, relic = 1 };
                avaliable = true;
                break;
            case 7:
                type = 1;
                itemId = 81;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, relic = 1 };
                avaliable = true;
                break;
            case 8:
                type = 2;
                itemId = 68;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, relic = 1 };
                avaliable = true;
                break;
            case 9:
                type = 2;
                itemId = 66;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, relic = 1 };
                avaliable = true;
                break;
            case 10:
                type = 2;
                itemId = 69;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 500, spiritOre = 10, coal = 5, relic = 1 };
                avaliable = true;
                break;
            case 11:
                type = 3;
                itemId = 131;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 1000, crystalGlass = 10, spiritCrystal = 5, herbWhite = 5 };
                avaliable = true;
                break;
            case 12:
                type = 3;
                itemId = 175;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 1000, crystalGlass = 10, spiritCrystal = 5, herbBlue = 10 };
                avaliable = true;
                break;
            case 13:
                type = 3;
                itemId = 186;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 1000, crystalGlass = 10, spiritCrystal = 5, herbBlue = 10, herbWhite = 2 };
                avaliable = true;
                break;
            case 14:
                type = 3;
                itemId = 213;
                name = Assist.AllItems(itemId).itemName;
                requeriment = new Requeriment() { gold = 200, herbBlue = 2, herbRed = 5, herbGreen = 5 };
                avaliable = true;
                break;

        }
    }

    public bool CheckRequeriments(Player player)
    {
        if (itemId == -1) return false;

        if (player.gold < requeriment.gold) return false;
        if (player.magicCrystal < requeriment.magicCrystal) return false;
        if (player.spiritCrystal < requeriment.spiritCrystal) return false;
        if (player.spiritOre < requeriment.spiritOre) return false;
        if (player.spiritEssence < requeriment.spiritEssence) return false;
        if (player.demonicEssence < requeriment.demonicEssence) return false;
        if (player.crystalGlass < requeriment.crystalGlass) return false;
        if (player.coal < requeriment.coal) return false;
        if (player.relic < requeriment.relic) return false;
        if (player.herbRed < requeriment.herbRed) return false;
        if (player.herbGreen < requeriment.herbGreen) return false;
        if (player.herbBlue < requeriment.herbBlue) return false;
        if (player.herbWhite < requeriment.herbWhite) return false;
        if (player.herbBlack < requeriment.herbBlack) return false;


        //for (int i = 0; i < player.inventory.items.Length; i++)
        //    if (player.inventory.items[i].id == itemId) return true;


        return true;
    }

    public string ItemRequeriments(Player player)
    {
        string str = "Items needed:\n";

        if (requeriment.gold > 0) str += requeriment.gold + "x Gold\n";
        if (requeriment.magicCrystal > 0) str += requeriment.magicCrystal + "x Magic Crystal\n";
        if (requeriment.spiritCrystal > 0) str += requeriment.spiritCrystal + "x Spirit Crystal\n";
        if (requeriment.spiritOre > 0) str += requeriment.spiritOre + "x Spirit Ore\n";
        if (requeriment.spiritEssence > 0) str += requeriment.spiritEssence + "x Spirit Essence\n";
        if (requeriment.demonicEssence > 0) str += requeriment.demonicEssence + "x Demonic Essence\n";
        if (requeriment.crystalGlass > 0) str += requeriment.crystalGlass + "x Crystal Glass\n";
        if (requeriment.coal > 0) str += requeriment.coal + "x Coal\n";
        if (requeriment.relic > 0) str += requeriment.relic + "x Relic\n";
        if (requeriment.herbRed > 0) str += requeriment.herbRed + "x Red Herb\n";
        if (requeriment.herbGreen > 0) str += requeriment.herbGreen + "x Green Herb\n";
        if (requeriment.herbBlue > 0) str += requeriment.herbBlue + "x Blue Herb\n";
        if (requeriment.herbWhite > 0) str += requeriment.herbWhite + "x White Herb\n";
        if (requeriment.herbBlack > 0) str += requeriment.herbBlack + "x Black Herb\n";

        if (CheckRequeriments(player))
        {
            str += "\nTHIS ITEM CAN BE CRAFTED!\nCLICK THE CRAFT BUTTON TO START CRAFTING";
        }
        else
        {
            str += "\nTHIS ITEM CAN'T BE CRAFTED!";
        }

        return str;
    }

}


public class Requeriment
{
    public int gold = 0;
    public int magicCrystal = 0;
    public int spiritCrystal = 0;
    public int spiritOre = 0;
    public int spiritEssence = 0;
    public int demonicEssence = 0;
    public int crystalGlass = 0;
    public int coal = 0;
    public int relic = 0;
    public int herbRed = 0;
    public int herbGreen = 0;
    public int herbBlue = 0;
    public int herbWhite = 0;
    public int herbBlack = 0;

    public int itemId = -1;
}