using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    private float timer = 3f;
    
    public Transform player;
    public GameObject red, yellow, green;
    public Animator anim;
    public AudioClip trafficBeep;
    public AudioClip trafficLastBeep;
    private AudioSource source;
    private bool yelPlayed = false, grePlayed = false;
    

    void Start () {
        player.GetComponent<DragPlayer>().SetForwardForce(false);
        source = GetComponent<AudioSource>();
    }
	
	void Update () {
        timer -= Time.deltaTime;    
        if (timer<0)
        {
            
            player.GetComponent<DragPlayer>().SetForwardForce(true);
            yellow.SetActive(false);
            green.SetActive(true);
            red.SetActive(false);
            if (!grePlayed)
            { 
                source.PlayOneShot(trafficLastBeep);
                grePlayed = true;
            }
            StartCoroutine(SoundIsPlaying());

            
        }
        else if (timer < 1.5)
        {
            anim.SetTrigger("Start");
            yellow.SetActive(true);
            if (!source.isPlaying && !yelPlayed)
            {
                source.PlayOneShot(trafficBeep);
                yelPlayed = true;
            }

        }
    }

    IEnumerator SoundIsPlaying()
    {
        yield return new WaitWhile(() => source.isPlaying);
        gameObject.SetActive(false);
    }

}
