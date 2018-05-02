using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    private float timer = 4f;
    public Text text;
    public Transform player;

    void Start () {
        player.GetComponent<DragPlayer>().SetForwardForce(false);
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        text.text = "" + (int)timer;
        if (timer<0)
        {
            text.enabled = false;
            player.GetComponent<DragPlayer>().SetForwardForce(true);
        }

	}
}
