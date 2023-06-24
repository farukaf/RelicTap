using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class DressRoomInventory
{
    public GameObject[] slots;
    public GameObject[] equipSlots;
    public Sprite[] equipImgs;

    


    public void Load(Player player)
    {
        player.Load();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Image>().sprite = player.inventory.items[i].sprite;
        }

        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (player.inventory.equips[i].id != -1)
            {
                equipSlots[i].GetComponent<Image>().sprite = player.inventory.equips[i].sprite;
            }
            else
            {
                equipSlots[i].GetComponent<Image>().sprite = equipImgs[i];
            }
            
        }
    }

    public void Update(Player player)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Image>().sprite = player.inventory.items[i].sprite;
        }

        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (player.inventory.equips[i].id != -1)
            {
                equipSlots[i].GetComponent<Image>().sprite = player.inventory.equips[i].sprite;
            }
            else
            {
                equipSlots[i].GetComponent<Image>().sprite = equipImgs[i];
            }

        }
    }


}
