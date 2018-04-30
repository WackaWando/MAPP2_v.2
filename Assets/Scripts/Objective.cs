using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    
    public GameObject Paricle;
    // Use this for initialization
    void Start()
    {
     //       Paricle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3 spawn = transform.position;
            Paricle.transform.position = spawn;
            Paricle.SetActive(true);
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Highscore", 0) + 200);

        }

    }
}
