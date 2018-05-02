using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    private float timer = 3f;
    
    public Transform player;
    public GameObject red, yellow, green;
    

    void Start () {
        player.GetComponent<DragPlayer>().SetForwardForce(false);

    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
       
        if (timer<0)
        {
            
            player.GetComponent<DragPlayer>().SetForwardForce(true);
            yellow.SetActive(false);
            green.SetActive(true);
            red.SetActive(false);
        }
        else if (timer < 1.5)
        {
           
            yellow.SetActive(true);
        }


	}
}
