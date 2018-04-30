using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

    public int scoreToGive;
    public GameObject Paricle;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3 spawn = transform.position;
           // Paricle.transform.position = spawn;
            Paricle.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Highscore", 0) + scoreToGive);
            StartCoroutine(Remove());
        }

    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
