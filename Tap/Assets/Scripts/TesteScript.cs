using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TesteScript : MonoBehaviour
{

    public float RndTeste;
    public int rpt;
    public float dif;
    Inventory inventory;
    public GameObject Img;
    public int ImgId;
    public Texture2D RandomItems;
    Sprite[] Items;
    public Text txtId, txtName, txtDescription;

    public Button[] Buttons;
    public Text[] txtButtons;

    // Use this for initialization
    void Start()
    {
        Items = Resources.LoadAll<Sprite>(RandomItems.name);
        //Debug.Log(Items.Length);

        inventory = new Inventory();
        inventory.Load();



    }

    // Update is called once per frame
    void Update()
    {
        Img.GetComponent<Image>().sprite = Items[ImgId];
        Items _item = new Items { id = ImgId };
        _item.Load();

        txtId.text = _item.id.ToString();
        txtName.text = _item.itemName;
        txtDescription.text = _item.description;
    }


    public void HideButtons(string field)
    {
        //Filter
        for (int i = 0; i < Buttons.Length; i++)
        {
            for (int t = 0; i < field.Length; t++)
            {
                string a = txtButtons[i].text;
                Debug.Log(a + " " + field);
                //if (a[t] != field[t])
                //{
                //    Buttons[i].gameObject.SetActive(false);
                //}
            }
        }

        Debug.Log(field);
    }
    public void BtnIdChange(bool plus)
    {
        if (plus)
        {
            ImgId = ImgId < Items.Length - 1 ? ImgId + 1 : 0;
        }
        else
        {
            ImgId = ImgId > 0 ? ImgId - 1 : Items.Length - 1;
        }

    }

    public void BtnTesteRandom()
    {
        float _temp = Random.value * RndTeste;
        int _tempp = (int)_temp;
       // Debug.Log(_temp + " / " + _tempp);
    }

    public void BtnTesteRandomRpt()
    {
        int[] list = new int[100];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = 0;
        }

        for (int i = 0; i < rpt; i++)
        {
            //int _tempp = (int)(Random.value * RndTeste + dif);
            int _tempp = (int)(Random.Range(dif, RndTeste));
            list[_tempp]++;
        }

        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] != 0)
            {
               // Debug.Log("N " + i + ": " + list[i]);
            }
        }


    }

    public void BtnTestAssistGen(string str)
    {
        string[] n = str.Split('|');
        int min = System.Convert.ToInt32(n[0]);
        int max = System.Convert.ToInt32(n[1]);

        BtnTestAssistGen(min, max);
    }

    public void BtnTestAssistGen(int min, int max)
    {

        int[] list = new int[max - min + 1];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = 0;
        }

        for (int i = 0; i < rpt; i++)
        {
            int _tempp = Assets.Scripts.Assist.IntGenerator(0, max - min);

            list[_tempp]++;
        }
        string result = "";
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] != 0)
            {
                if (i != 0)
                {
                    result += "\nN " + (i + min) + ": " + list[i];
                }
                else
                {
                    result = "N " + (i + min) + ": " + list[i];
                }

            }
        }

        //Debug.Log(result);
    }
}
