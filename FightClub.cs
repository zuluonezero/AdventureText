using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightClub : MonoBehaviour {

    public int playerHP;
    public int playerMinDamage;
    public int playerMaxDamage;
    public int weaponBonus = 0;
    public GameObject Monster;

    public void PlayerAttack ()
    {
        if (GameObject.FindGameObjectWithTag("Monster") == null)
        {
            PrintMainText.text_control.ClearText();
            PrintMainText.text_control.PrintMe("There is nothing to interact with here...", 0.1f);
        }
        else
        {
            Monster = GameObject.FindGameObjectWithTag("Monster");

            int playerAttackDamage = Random.Range(playerMinDamage, playerMaxDamage); // inclusive & exclusive 
            playerAttackDamage += weaponBonus;
            
            var monsterScript = Monster.GetComponent<MonsterStuff>();
            int monsterAttackDamage = monsterScript.MonsterAttack();

            PrintMainText.text_control.PrintHPText("HP: " + playerHP.ToString());
            PrintMainText.text_control.PrintVSText(playerAttackDamage.ToString() + " vs " + monsterAttackDamage.ToString());
            PrintMainText.text_control.PrintMonsterHPText("Monster: " + monsterScript.monsterHP.ToString());

            if (playerAttackDamage < monsterAttackDamage)
            {
                playerHP -= monsterAttackDamage;
                PrintMainText.text_control.PrintHPText("HP: " + playerHP.ToString());
                PrintMainText.text_control.ClearText();
                PrintMainText.text_control.PrintMe(monsterScript.MonsterAttackText(), 0.02f);

                if (playerHP <= 0)
                {
                    // You are Dead.
                    playerHP = 0;
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(monsterScript.playerKillingText, 0.01f);

                    var resetScript = GameObject.FindGameObjectWithTag("InputControl").GetComponent<ResetGame>();
                    resetScript.youAreDead = true;
                }
            }
            else
            {
                monsterScript.MonsterTakesDamage(playerAttackDamage);
                PrintMainText.text_control.ClearText();
                PrintMainText.text_control.PrintMe(monsterScript.MonsterDefenseText(), 0.02f);

                PrintMainText.text_control.PrintMonsterHPText("Monster: " + monsterScript.monsterHP.ToString());

                if (monsterScript.dead)
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(monsterScript.monsterKillingText, 0.02f);
                    Destroy(Monster);
                    PrintMainText.text_control.PrintVSText("");
                    PrintMainText.text_control.PrintMonsterHPText("");

                }
            }
        }

        

    }



}
