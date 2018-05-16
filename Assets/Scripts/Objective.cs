using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

    public int scoreToGive;
    public GameObject Paricle;
    public bool special = false;
    public AudioClip clip;
    private AudioSource source;
    public float volume =0.1f ;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume= volume ;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3 spawn = transform.position;
           // Paricle.transform.position = spawn;
            Paricle.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Highscore", 0) + scoreToGive);
            source.PlayOneShot(clip);

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
            
            Paricle.SetActive(true);
            source.PlayOneShot(clip);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Highscore", 0) + scoreToGive);
			StartCoroutine(Disactive());

        }
    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    
    IEnumerator Disactive()
    {
        yield return new WaitForSeconds(2);
        Paricle.SetActive(false);
    }
}
