using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour {

    public void ResetPrefs() {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetInt("totalStars", 0);
        for (int i = 1; i < 3; i++)
        {
            string levelName = "level" + i + "Stars";
            PlayerPrefs.SetInt(levelName, 0);
        }
        PlayerPrefs.SetInt("veg", 0);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
