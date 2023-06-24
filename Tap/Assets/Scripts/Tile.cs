using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
public class Tile
{
    public Wave[] wave = new Wave[10];
    public bool active = false;

    public int ScenaryID;
    // Use this for initialization
    public void Start()
    {
        for (int i = 0; i < wave.Length; i++)
        {
            wave[i] = new Wave();
            wave[i].Start();
        }
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void Gen()
    {
        active = true;

    }

    public void Gen(bool small)
    {
        active = true;
        if (small)
        {
            int sz = Assist.IntGenerator(2, 3);
            for (int i = 0; i < sz; i++)
            {
                wave[i].Gen(true);
            }
        }
        else
        {

        }
    }

    public bool CheckTile()
    {

        for (int i = 0; i < wave.Length; i++)
        {
            if (wave[i].active) return false;
        }

        active = false;
        return true;
    }
}

