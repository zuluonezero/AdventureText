using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour {

    public bool youAreDead;
    public bool youWon;

    [TextArea(5, 10)]
    public string resetText;

    public Canvas map_canvas;
    public GameObject[] theWayPoints;
    public GameObject[] mapWayPoints;
    public GameObject map_location;

    private IEnumerator coroutine_wait;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (youAreDead || youWon)
        {
            coroutine_wait = WaitHere();
            StartCoroutine(coroutine_wait);

        }
    }

    IEnumerator WaitHere()
    {

        yield return new WaitForSeconds(5f);
        ResetTheGame();
    }

    public void ResetTheGame()
    {
        // Reset the game to starting position.

        // Reset the Combat system
        var CBScript = GameObject.FindWithTag("FightClub").GetComponent<FightClub>();
        CBScript.playerHP = 50;
        CBScript.playerMinDamage = 2;
        CBScript.playerMaxDamage = 11;
        CBScript.weaponBonus = 0;

        // If there is monster - destroy it
        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Monster"));
        }

        // Make sure the map is shut
        var cg = map_canvas.GetComponent<CanvasGroup>();
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        // Update the map pieces
        mapWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

        for (int i = 0; i < mapWayPoints.Length; i++)
        {
            var script = mapWayPoints[i].GetComponent<WayPoint>();
            if (script.wayPointVisited)
            {
                string my_name = mapWayPoints[i].name;  // image name is shared with component
                map_location = GameObject.FindGameObjectWithTag(my_name);
                if (map_location)
                {
                    map_location.GetComponent<Image>().enabled = true;
                }
            }
        }

        // Set the UI into default starting mode with a custom text
        // Set FirstRun to true
        var inputScript = GameObject.FindGameObjectWithTag("InputControl").GetComponent<InputControl>();
        inputScript.first_run = true;
        inputScript.currentWayPoint = GameObject.FindWithTag("01_StartingPoint");
        inputScript.backButton.interactable = false;
        inputScript.leftButton.interactable = false;
        inputScript.rightButton.interactable = false;
        inputScript.actionButton.interactable = false;
        inputScript.mapButton.interactable = false;

        var SPScript = GameObject.FindWithTag("01_StartingPoint").GetComponent<WayPoint>() ;
        SPScript.wayPointVisited = false;

        // Set all Waypoints to not visited and repopulate the monsters
        theWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

        for (int i = 0; i < theWayPoints.Length; i++)
        {
            var WPscript = theWayPoints[i].GetComponent<WayPoint>();
            if (WPscript.wayPointVisited)
            {
                WPscript.wayPointVisited = false;
            }
            if (WPscript.hereBeMonsters)
            {
                WPscript.monster = true;
            }
            
        }

        PrintMainText.text_control.PrintHPText("HP: 50");
        PrintMainText.text_control.PrintVSText("");
        PrintMainText.text_control.PrintMonsterHPText("");
       // PrintMainText.text_control.ClearText();
        if (youAreDead)
        {

                PrintMainText.text_control.PrintMe(resetText, 0.02f);
        }
        
        youAreDead = false;

    }
}
