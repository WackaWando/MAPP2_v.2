using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStars : MonoBehaviour {
    public Text text;
    private int stars;


    void Update () {
        stars = PlayerPrefs.GetInt("totalStars", 0);
        text.text = ""+ stars;
	}
}
