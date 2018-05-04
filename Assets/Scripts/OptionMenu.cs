using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour {

    public void ResetPrefs() {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetInt("totalStars", 0);
        PlayerPrefs.SetInt("level1Stars", 0);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
