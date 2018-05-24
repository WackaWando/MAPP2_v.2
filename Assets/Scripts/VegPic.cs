using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegPic : MonoBehaviour {
    public Sprite vegOn, vegOff;
    private Image sprite;

    private void Start()
    {
        sprite = GetComponentInParent<Image>();
    }

    void Update () {
        if (PlayerPrefs.GetInt("veg", 0) == 0) {
            sprite.sprite = vegOn;
        }
        else if (PlayerPrefs.GetInt("veg", 0) == 1)
        {
            sprite.sprite = vegOff;
        }

    }
}
