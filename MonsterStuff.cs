using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create an Empty Game Object and add this script.

public class MonsterStuff : MonoBehaviour {

    public string monsterName;
    public int monsterHP;
    public int minDamage;
    public int maxDamage;
    public string[] monsterText; 
    public string[] monsterDefenseText;  
    public string playerKillingText;
    public string monsterKillingText;
    public bool dead;

    public int MonsterAttack ()
    {
        int damage = Random.Range(minDamage, maxDamage); // inclusive and exclusive
        return damage;
    }

    public bool MonsterTakesDamage (int damageTaken)
    {
        monsterHP -= damageTaken;
        if (monsterHP <= 0)
        {
            dead = true;
            monsterHP = 0;
        }
        return dead;
    }

    public string MonsterAttackText ()
    {
        int i = Random.Range(0, monsterText.Length);
        return monsterText[i];
    }

    public string MonsterDefenseText()
    {
        int i = Random.Range(0, monsterDefenseText.Length);
        return monsterDefenseText[i];
    }
}
