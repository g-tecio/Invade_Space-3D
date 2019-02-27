using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour
{
    public static float  cont;
    public float high_Score;
    public Text CountText;
    

    // Start is called before the first frame update
    void Start()
    {

        CountText = GameObject.Find("CountText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        cont = (cont + .3f);
       

        CountText.text =  cont.ToString("000000");
        PlayerPrefs.SetFloat("Score", cont);

    }

    void SetText()
    {
        //Fetch the health from the PlayerPrefs (set these Playerprefs elsewhere). If no float of this name exists, the default is 0
        high_Score = PlayerPrefs.GetFloat("Score");
    }

    
}
