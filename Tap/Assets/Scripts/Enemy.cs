using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using System;

[System.Serializable]
public class Enemy
{
    public int skillID;

    public int ID;

    public bool alive = false;

    public string name;
    public int maxHp, actHp;
    public float maxCoolDown, actCoolDown;

    public Sprite sprite;
    //skills

    public bool flying = false;

    public string comment;

    public Vector3 pos, startPos;

    public void Update()
    {
        alive = actHp > 0;

        actCoolDown += Time.deltaTime;
        if (actCoolDown >= maxCoolDown && alive)
        {
            actCoolDown = 0;
            
            //Add EnemySkill to the query
            if (Assist.skillQuery == null)
            {
                Assist.skillQuery = new string[] { (ID + "|" + skillID) };

            }
            else
            {
                string[] temp = Assist.skillQuery;
                Assist.skillQuery = new string[temp.Length + 1];
                for (int j = 0; j < temp.Length; j++)
                {
                    Assist.skillQuery[j] = temp[j];
                }
                Assist.skillQuery[Assist.skillQuery.Length - 1] = ID + "|" + skillID;
            }

        }

    }
    public bool Tap()
    {
        actHp -= Assist.IntGenerator(20, 80);

        return actHp <= 0;

    }

}

