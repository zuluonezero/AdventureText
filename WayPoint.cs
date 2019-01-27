using UnityEngine;

//[System.Serializable]
//[CreateAssetMenu(menuName = "WayPointEditor", fileName = "WayPoint.asset")]
//public class WayPointEditor : ScriptableObject

public class WayPoint : MonoBehaviour
{
    public bool wayPointVisited;
    public string wayPoint_name = "Name here";
    
    public int wayPoint_uid = 0001;
	public string wayPoint_description = "description";

    public float write_rate  = 0.5f;
    public float text_size = 32f;
    //public float text_color = 255;  // or whatever we use for color
    [TextArea(5, 10)]
    public string wayPoint_text = "Something";
    [TextArea(5, 10)]
    public string wayPoint_visitedText = "Something";

    public string wayPoint_forward = "next waypoint forward";
    public string wayPoint_left = "waypoint left";
    public string wayPoint_right = "waypoint right";
    public string wayPoint_backwards = "waypoint behind";

    public bool monster;
    public bool hereBeMonsters;
    public GameObject monsterPrefab;
    public string monsterName;
    public int hp;
    public int minDamage;
    public int maxDamage;
    [TextArea(2, 10)]
    public string[] monsterText;
    [TextArea(2, 10)]
    public string[] monsterDefenseText; 
    public string playerKillingText;
    public string monsterKillingText;


    public void GenerateMonster ()
    {
        if (monster)
        {
            GameObject my_monster = Instantiate(monsterPrefab);
            var monster_data = my_monster.GetComponent<MonsterStuff>();
            monster_data.name = monsterName;
            monster_data.monsterName = monsterName;
            monster_data.monsterHP = hp;
            monster_data.minDamage = minDamage;
            monster_data.maxDamage = maxDamage;
            monster_data.playerKillingText = playerKillingText;
            monster_data.monsterKillingText = monsterKillingText;

            //Debug.Log("monsterText array length  = " + monsterText.Length);
            monster_data.monsterText = new string[monsterText.Length];
            //Debug.Log("DATA.monsterText array length  = " + monster_data.monsterText.Length);
            monster_data.monsterDefenseText = new string[monsterDefenseText.Length];
            for (int i = 0; i < monsterText.Length; i++)
            {
                monster_data.monsterText[i] = monsterText[i];
            }

            for (int i = 0; i < monsterDefenseText.Length; i++)
            {
                monster_data.monsterDefenseText[i] = monsterDefenseText[i];
            }

            PrintMainText.text_control.PrintVSText("0 vs 0");
            PrintMainText.text_control.PrintMonsterHPText("Monster: " + hp.ToString());
        }
    }
}

