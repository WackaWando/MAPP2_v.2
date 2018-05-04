using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

	void Start()
	{
		Debug.Log("LoadSceneA");
	}

	public void LoadA(string scenename)
	{
		Debug.Log("sceneName to load: " + scenename);
		SceneManager.LoadScene(scenename);
	}


	   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        Application.Quit();

    }


}

    