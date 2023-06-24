using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[System.Serializable]
public class Wave
{
    public Enemy[] enemy = new Enemy[5];
    public bool active = false;
    public bool build = false;
    // Use this for initialization
    public void Start()
    {

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = new Enemy();
            enemy[i].alive = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void Gen()
    {
        active = true;
        build = true;
    }



    public void Gen(bool small)
    {
        active = true;
        build = true;

        if (small)
        {
            int sz = Assist.IntGenerator(1, 3);

            do
            {
                for (int i = 0; i < enemy.Length; i++)
                {

                    if (sz <= 0) break;


                    if (Assist.IntGenerator(0, 10) > 4 && !enemy[i].alive)
                    {

                        int idS = 5;

                        EnemyLibrary eL = new EnemyLibrary();



                        enemy[i] = NewEnemy(Assist.IntGenerator(0, idS - 1));
                        sz--;
                    }
                }

            } while (sz > 0);

        }
        else
        {

        }

    }


    /// <summary>
    /// Check if the wave is dead. True = dead;
    /// </summary>
    /// <returns></returns>
    public bool CheckWave()
    {

        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].alive) return false;
        }

        active = false;
        return true;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="type">0-Ground, 1-Flying</param>
    /// <param name="id"></param>
    /// <returns></returns>
    private Enemy NewEnemy( int id)
    {
        EnemyLibrary EnemyLibrary = new EnemyLibrary();

        Enemy _e = new Enemy();

        //Debug.Log("New Enemy ID: " + id + " type: " + type);

       
            _e = EnemyLibrary.Enemies[id];
        

        return _e;
    }


}

