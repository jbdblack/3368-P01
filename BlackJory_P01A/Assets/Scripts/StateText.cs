using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateText : MonoBehaviour
{
    public static StateText instance = null;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().enabled = false; //Hide the text when the game starts
            
    }

    public void DisplayLoseText()
    {
        GetComponent<Text>().enabled = true;
        GetComponent<Text>().text = "You lose";
    }
}
