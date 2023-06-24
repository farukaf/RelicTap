using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class EnemySkillLibrary
{

    public static string UseSkill(int skillId, int enemyId, Player player)
    {
        EnemyLibrary enemyLib = new EnemyLibrary();
        string skillname = "";
        int damage = 0;
        switch (skillId)
        {
            case 0:
                skillname = "tackle";
                damage = Assist.IntGenerator(0, 5);
                break;
            case 1:
                skillname = "bite";
                damage = Assist.IntGenerator(0, 8);
                break;
            case 2:
                skillname = "head-butt";
                damage = Assist.IntGenerator(0, 7);
                break;
            case 3:
                skillname = "punch";
                damage = Assist.IntGenerator(0, 5);
                break;
            case 4:
                skillname = "weird move";
                damage = Assist.IntGenerator(0, 5);
                break;
            case 5:
                skillname = "sonic wave";
                damage = Assist.IntGenerator(0, 5);
                break;

        }


        //Enemy wolf used skill. /n You lose 10 healthpoints.
        string r = "Enemy " + enemyLib.Enemies[enemyId].name + " used skill " + skillname + ".\n";
        if (damage > 0)
        {
            r += "You losed " + damage + " healthpoints.";
            player.healthAct -= damage;
        }
        else if (damage == 0)

        {
            r += "Enemy " + enemyLib.Enemies[enemyId].name + " missed you.";
        }
        else
        {
            r += "Something wrong is not right. DMG: " + damage;
        }
        return r;
    }


}

