using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour {

    public void ReloadScene () {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene("Test_Level");
}

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
