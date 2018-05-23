using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veg : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetInt("veg", 0); // to be deleted, option to be added in main menu
        if (PlayerPrefs.GetInt("veg", 0) == 0)
        {
            GameObject.Destroy(transform.GetChild(2).gameObject);
        }
        else if(PlayerPrefs.GetInt("veg", 0) == 1)
        {
            GameObject.Destroy(transform.GetChild(1).gameObject);
        }

    }
	
}
