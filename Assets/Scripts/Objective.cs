using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

    public int scoreToGive;
    public GameObject Paricle;
    public bool special = false;

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
        if (special)
        {
            PlayerPrefs.SetInt("Special", PlayerPrefs.GetInt("Special", 0) + 1);
        }

    }
     void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Vector3 spawn = transform.position;
            // Paricle.transform.position = spawn;
            Paricle.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Highscore", 0) + scoreToGive);
            StartCoroutine(RemoveParticle());

        }
    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    
    IEnumerator RemoveParticle()
    {
        yield return new WaitForSeconds(2);
        Paricle.SetActive(false);
    }
}
