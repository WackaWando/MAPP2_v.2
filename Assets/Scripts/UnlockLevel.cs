using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour {
    public int starsRequired, levelNumber;
	public Color fadeLevel;
    private Color level;
    private Image ima;
    private string sceneName;
    // Use this for initialization
    void Start () {
        sceneName = "level" + levelNumber;

      //  GetComponentInChildren<Text>().text = "Level " + levelNumber;
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("totalStars", 0) < starsRequired || !Application.CanStreamedLevelBeLoaded(sceneName))
        {
            ima = GetComponent<Image>();
            level = ima.color;
            level.a = 0.3f;
            ima.color = level;
        }
    }
    public void LevelClicked()
    {

        if (PlayerPrefs.GetInt("totalStars",0) >= starsRequired)
        {
            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                //SceneManager.LoadScene(sceneName);
				Initiate.Fade(sceneName, fadeLevel, 1.0f);
            }
            else
            {
                Debug.Log("This level is not ready yet");
            }
        }
        else
        {
            Debug.Log("not enough stars");

        }
    }

}
