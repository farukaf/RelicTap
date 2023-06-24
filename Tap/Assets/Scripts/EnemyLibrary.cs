using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;


public class EnemyLibrary
{
    public Sprite[] EnemiesSprite;


    public Enemy[] Enemies;

    public int LibraryEnemysSize;

    public EnemyLibrary()
    {
        EnemiesSprite = Resources.LoadAll<Sprite>("Monsters300x300");


        //Fill all fields with the necessary information
        Enemies = new Enemy[]
        {
            new Enemy() {ID = 0, name = "Wolf", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[0] },
            new Enemy() {ID = 1, name = "Angry Boar", skillID = 2, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[1] },
            new Enemy() {ID = 2, name = "Snake", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[2] },
            new Enemy() {ID = 3, name = "Foxy", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[3] },
            new Enemy() {ID = 4, name = "Spider", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[4] },
            new Enemy() {ID = 5, name = "Ape Sapiens", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[5] },
            new Enemy() {ID = 6, name = "Gorilla", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[6] },
            new Enemy() {ID = 7, name = "Ape", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[7] },
            new Enemy() {ID = 8, name = "Fat Ogre", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[8] },
            new Enemy() {ID = 9, name = "Mini Orc", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[9] },
            new Enemy() {ID = 10, name = "Funny Goblin", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[10] },
            new Enemy() {ID = 11, name = "Big Orc", skillID = 3, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[11] },
            new Enemy() {ID = 12, name = "Dino", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[12] },
            new Enemy() {ID = 13, name = "Alien", skillID = 4, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[13] },
            new Enemy() {ID = 14, name = "Big Rat", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[14] },
            new Enemy() {ID = 15, name = "Rotworm", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[15] },
            new Enemy() {ID = 16, name = "Anfibius", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[16] },
            new Enemy() {ID = 17, name = "Iet", skillID = 3, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[17] },
            new Enemy() {ID = 18, name = "Pigorc", skillID = 3, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[18] },
            new Enemy() {ID = 19, name = "Wasp", skillID = 1, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, flying = true, sprite = EnemiesSprite[19] },
            new Enemy() {ID = 20, name = "BigBat", skillID = 5, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, flying = true, sprite = EnemiesSprite[20] },
            new Enemy() {ID = 21, name = "Behold", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, flying = true, sprite = EnemiesSprite[21] },
            new Enemy() {ID = 22, name = "Ghustly", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, flying = true, sprite = EnemiesSprite[22] },
            new Enemy() {ID = 23, name = "Big Eye", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, flying = true, sprite = EnemiesSprite[23] },
            new Enemy() {ID = 24, name = "Tama", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, flying = true, sprite = EnemiesSprite[24] },
            new Enemy() {ID = 25, name = "SadicApe", skillID = 0, maxCoolDown = 8, actCoolDown = 0, maxHp = 100, actHp = 100, alive = true, sprite = EnemiesSprite[25] }
        };


        LibraryEnemysSize = Enemies.Length;


    }





}

