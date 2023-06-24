using UnityEngine;
using System.Collections;

public class Inventory
{

    public Items[] items = new Items[24];

    public Items[] equips = new Items[6];
    public void NewGame()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Items() { id = -1 };
        }

        for (int i = 0; i < equips.Length; i++)
        {
            equips[i] = new Items() { id = -1 };
        }

        TestItems();

        Save();

    }
    public void Load()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Items() { id = PlayerPrefs.GetInt("inventorySlot" + i) };
            items[i].Load();
        }

        for (int i = 0; i < equips.Length; i++)
        {
            equips[i] = new Items() { id = PlayerPrefs.GetInt("equipSlot" + i) };
            equips[i].Load();
        }
    }


    public void Save()
    {
        for (int i = 0; i < items.Length; i++)
        {
            PlayerPrefs.SetInt("inventorySlot" + i, items[i].id);
        }

        for (int i = 0; i < equips.Length; i++)
        {
            PlayerPrefs.SetInt("equipSlot" + i, equips[i].id);
        }
    }

    private void TestItems()
    {
        items[0] = new Items() { id = 0 };
        items[1] = new Items() { id = 1 };
        items[2] = new Items() { id = 7 };
        items[3] = new Items() { id = 10 };
        items[4] = new Items() { id = 21 };
        items[5] = new Items() { id = 25 };
        items[6] = new Items() { id = 34 };

    }

    public void AddItem(int itemId)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].id == -1)
            {
                items[i].id = itemId;
                return;
            }
        }

        Debug.Log("No space on inventary");
    }

    public void RemoveItem(int slotId)
    {
        items[slotId].id = -1;
    }

}
