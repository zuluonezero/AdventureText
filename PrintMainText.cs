using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class PrintMainText : MonoBehaviour
{
    public static PrintMainText text_control;
    public float letterPause = 0.2f;
    //public AudioClip sound;
    public Text headingText;
    public Text mainText;
    public Text hpText;
    public Text monsterHPText;
    public Text vsText;

    //public Text mainTextShadow;
    public string message;
    private IEnumerator coroutine;
    public bool coroutineRunning;

    void Awake()
    {     // Do before anything else
        if (text_control == null) // if there is nothing called "control" make this class control
        {
            DontDestroyOnLoad(gameObject);  //persistence
            text_control = this;
        }
        else if (text_control != this)  // If there is an instance of  "control" and this isn't it then destroy this.
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        //PrintMe("Adventure Text", 0.2f);
    }

    // Use this for initialization
    public void PrintMe (string passed_string, float pause_time)
    {
        message = passed_string;
        letterPause = pause_time;
        coroutine = TypeText();
        StartCoroutine(coroutine);
    }

    IEnumerator TypeText()
    {
        coroutineRunning = true;
        foreach (char letter in message.ToCharArray())
        {
            mainText.text += letter;
            //mainTextShadow.text += letter;
            //if (sound)
            //audio.PlayOneShot(sound);
            yield return 0;
            yield return new WaitForSeconds(letterPause);

        }
        Debug.Log("EOM");
        coroutineRunning = false;
    }

    public void ClearText ()
    {
        if (coroutineRunning)
        {
            StopCoroutine(coroutine);
        }
        mainText.text = "";
    }

    public void PrintHeadingText(string heading)
    {
        headingText.text = heading;
    }

    public void PrintHPText(string hp)
    {
        hpText.text = hp;
    }

    public void PrintMonsterHPText(string m_hp)
    {
        monsterHPText.text = m_hp;
    }

    public void PrintVSText(string vs)
    {
        vsText.text = vs;
    }
}
