using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomat : MonoBehaviour {

    public int scoreToGive;
    public GameObject Paricle;
    public GameObject tomato;
    public AudioClip clip;
    private AudioSource source;
    public float volume = 0.1f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = volume;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3 spawn = transform.position;
           Paricle.transform.position = spawn;
            Paricle.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Highscore", 0) + scoreToGive);
            source.PlayOneShot(clip);
            tomato.SetActive(false);
            StartCoroutine(Remove());
        }


    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
