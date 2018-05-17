using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScr : MonoBehaviour {


    public AudioClip clip;
    private AudioSource source;
    public float volume = 0.1f;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        source.volume = volume;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {   
            source.PlayOneShot(clip);
        }


       
		
	}
}
