using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControl : MonoBehaviour {

    public GameObject currentWayPoint;
    public GameObject fightClub;
    public Canvas map_canvas;
    public Button backButton;
    public Button leftButton;
    public Button rightButton;
    public Button actionButton;
    public Button mapButton;
    public GameObject[] mapWayPoints;
    public GameObject map_location;

    public bool first_run;
    public bool monsterAlive;

    public GameObject Monster;

    void Start ()
    {
        first_run = true;
    }

    public void Button_Forward ()
    {
        Debug.Log("Forward Button Pressed");


        if (first_run)
        {
            var WayPoint_dataStart = currentWayPoint.GetComponent<WayPoint>();  // get the data of the current WayPoint and find the name of the next WayPoint
            PrintMainText.text_control.ClearText();
            PrintMainText.text_control.PrintMe(WayPoint_dataStart.wayPoint_text, WayPoint_dataStart.write_rate);
            WayPoint_dataStart.wayPointVisited = true;
            backButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;
            actionButton.interactable = true;
            mapButton.interactable = true;
            first_run = false;
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Monster") != null)
            {
                monsterAlive = true;
            }
            else
            {
                monsterAlive = false;
            }

            if (monsterAlive)
            {
                PrintMainText.text_control.ClearText();
                PrintMainText.text_control.PrintMe("You cannot run a monster is attacking", 0.01f);
            }
            else
            {
                var WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data of the current WayPoint and find the name of the next WayPoint
                
                // Special Block for end of game
                if (WayPoint_data.name == "31_Freedom")
                {
                    Debug.Log("RESET");
                    var resetScript = GameObject.FindGameObjectWithTag("InputControl").GetComponent<ResetGame>();
                    resetScript.ResetTheGame();
                }
                // End special block

                if (WayPoint_data.wayPoint_forward == "NULL")
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe("You cannot go that way", 0.01f);

                }
                else
                {
                    currentWayPoint = GameObject.Find(WayPoint_data.wayPoint_forward);  // assign it
                    WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data from the Next WayPoint
                    if (WayPoint_data.wayPointVisited)  // If you have been there already
                    {
                        PrintMainText.text_control.ClearText();
                        PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_visitedText, WayPoint_data.write_rate);

                    }
                    else  // Print the next waypoint text
                    {
                        PrintMainText.text_control.ClearText();
                        PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_text, WayPoint_data.write_rate);
                        WayPoint_data.wayPointVisited = true;
                    }

                }

                if (WayPoint_data.monster)
                {
                    Debug.Log("There is a Monster here..." + WayPoint_data.wayPoint_name);
                    WayPoint_data.GenerateMonster();
                    monsterAlive = true;
                    WayPoint_data.monster = false;
                }

                // Custom actions below here

            }

        }

    }


    public void Button_Back ()
    {
        Debug.Log("Back Button Pressed");

        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            monsterAlive = true;
        }
        else
        {
            monsterAlive = false;
        }

        if (monsterAlive)
        {
            PrintMainText.text_control.ClearText();
            PrintMainText.text_control.PrintMe("You cannot run a monster is attacking", 0.01f);
        }
        else
        {
            var WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data of the current WayPoint and find the name of the next WayPoint
            if (WayPoint_data.wayPoint_backwards == "NULL")
            {
                PrintMainText.text_control.ClearText();
                PrintMainText.text_control.PrintMe("You cannot go that way", 0.01f);

            }
            else
            {
                currentWayPoint = GameObject.Find(WayPoint_data.wayPoint_backwards);  // assign it
                WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data from the Next WayPoint
                if (WayPoint_data.wayPointVisited)  // If you have been there already
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_visitedText, WayPoint_data.write_rate);

                }
                else  // Print the next waypoint text
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_text, WayPoint_data.write_rate);
                    WayPoint_data.wayPointVisited = true;
                }

            }

            if (WayPoint_data.monster)
            {
                Debug.Log("There is a Monster here..." + WayPoint_data.wayPoint_name);
                WayPoint_data.GenerateMonster();
                monsterAlive = true;
                WayPoint_data.monster = false;
            }

        }
    }

    public void Button_Left ()
    {
        Debug.Log("Left Button Pressed");

        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            monsterAlive = true;
        } else
        {
            monsterAlive = false;
        }

        if (monsterAlive)
        {
            PrintMainText.text_control.ClearText();
            PrintMainText.text_control.PrintMe("You cannot run a monster is attacking", 0.01f);
        }
        else
        {
            var WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data of the current WayPoint and find the name of the next WayPoint
            if (WayPoint_data.wayPoint_left == "NULL")
            {
                PrintMainText.text_control.ClearText();
                PrintMainText.text_control.PrintMe("You cannot go that way", 0.01f);

            }
            else 
            {
                currentWayPoint = GameObject.Find(WayPoint_data.wayPoint_left);  // assign it
                WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data from the Next WayPoint
                if (WayPoint_data.wayPointVisited)  // If you have been there already
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_visitedText, WayPoint_data.write_rate);

                }
                else  // Print the next waypoint text
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_text, WayPoint_data.write_rate);
                    WayPoint_data.wayPointVisited = true;
                }

            }

            if (WayPoint_data.monster)
            {
                Debug.Log("There is a Monster here..." + WayPoint_data.wayPoint_name);
                WayPoint_data.GenerateMonster();
                monsterAlive = true;
                WayPoint_data.monster = false;
            }
            // Custom actions below here
            if (WayPoint_data.name == "12_DeadEnd")
            {
                Debug.Log("You got a Sword..." + WayPoint_data.wayPoint_name);
                var combatScript = GameObject.FindGameObjectWithTag("FightClub").GetComponent<FightClub>();
                combatScript.weaponBonus = 1;
            }

            if (WayPoint_data.name == "31_Freedom")
            {
                Debug.Log("You won!" + WayPoint_data.wayPoint_name);
                backButton.interactable = false;
                leftButton.interactable = false;
                rightButton.interactable = false;
                actionButton.interactable = false;
                mapButton.interactable = false;
            }

        }
    }

    public void Button_Right ()
    {
        Debug.Log("Right Button Pressed");

        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            monsterAlive = true;
        }
        else
        {
            monsterAlive = false;
        }

        if (monsterAlive)
        {
            PrintMainText.text_control.ClearText();
            PrintMainText.text_control.PrintMe("You cannot run a monster is attacking", 0.01f);
        }
        else
        {
            var WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data of the current WayPoint and find the name of the next WayPoint
            if (WayPoint_data.wayPoint_right == "NULL")
            {
                PrintMainText.text_control.ClearText();
                PrintMainText.text_control.PrintMe("You cannot go that way", 0.01f);

            }
            else
            {
                currentWayPoint = GameObject.Find(WayPoint_data.wayPoint_right);  // assign it
                WayPoint_data = currentWayPoint.GetComponent<WayPoint>();  // get the data from the Next WayPoint
                if (WayPoint_data.wayPointVisited)  // If you have been there already
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_visitedText, WayPoint_data.write_rate);

                }
                else  // Print the next waypoint text
                {
                    PrintMainText.text_control.ClearText();
                    PrintMainText.text_control.PrintMe(WayPoint_data.wayPoint_text, WayPoint_data.write_rate);
                    WayPoint_data.wayPointVisited = true;
                }

            }
            if (WayPoint_data.monster)
            {
                Debug.Log("There is a Monster here..." + WayPoint_data.wayPoint_name);
                WayPoint_data.GenerateMonster();
                monsterAlive = true;
                WayPoint_data.monster = false;
            }

            // Custom actions below here
            if (WayPoint_data.name == "04_CliffFall")
            {
                Debug.Log("You are Dead..." + WayPoint_data.wayPoint_name);
                var resetScript = GameObject.FindGameObjectWithTag("InputControl").GetComponent<ResetGame>();
                resetScript.youAreDead = true;
            }

            // Custom actions below here
            if (WayPoint_data.name == "34_PoolRoom")
            {
                Debug.Log("You got a Sword..." + WayPoint_data.wayPoint_name);
                var combatScript = GameObject.FindGameObjectWithTag("FightClub").GetComponent<FightClub>();
                combatScript.weaponBonus = 2;
            }
        }
    }

    public void Button_Map ()
    {
        Debug.Log("Map Button Pressed");

        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            monsterAlive = true;
        }
        else
        {
            monsterAlive = false;
        }

        if (monsterAlive)
        {
            PrintMainText.text_control.ClearText();
            PrintMainText.text_control.PrintMe("There is a monster is attacking this is no time to be looking at the map!", 0.01f);
        }
        else
        {
            var cg = map_canvas.GetComponent<CanvasGroup>();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;

            mapWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

            for (int i = 0; i < mapWayPoints.Length; i++)
            {
                print("Expose Map  " + mapWayPoints[i].name);
                var script = mapWayPoints[i].GetComponent<WayPoint>();
                if (script.wayPointVisited)
                {
                    string my_name = mapWayPoints[i].name;  // image name is shared with component
                    map_location = GameObject.FindGameObjectWithTag(my_name);
                    if (map_location)
                    {
                        map_location.GetComponent<Image>().enabled = false;
                    }
                }
            }

        }
    }


    public void Button_Action ()
    {
        Debug.Log("Action Button Pressed");
        var fightScript = fightClub.GetComponent<FightClub>();
        fightScript.PlayerAttack();
    }
}
