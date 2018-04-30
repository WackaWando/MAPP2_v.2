using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighscoreLabel : MonoBehaviour {
    public Text text;
    private int scoreShown;

	// Use this for initialization
	void Start () {
        scoreShown = PlayerPrefs.GetInt("Highscore", 0);

    }
	
	// Update is called once per frame
	void Update () {
        if (scoreShown < PlayerPrefs.GetInt("Highscore", 0)) 
        {
            scoreShown += 5;
            text.text = "" +scoreShown;
        }
	}
}
