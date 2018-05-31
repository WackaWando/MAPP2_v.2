using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarSound: MonoBehaviour
{

    public AudioClip starSound;
    private AudioSource source;



    void Start()
    {
        source = GetComponent<AudioSource>();
    }



    public void PlaySound()
    {
     //   Debug.Log("test");
        source.PlayOneShot(starSound);
    }



}
