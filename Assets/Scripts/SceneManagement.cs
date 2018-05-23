using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour {


    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel() {
        if (!Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1))
        {
            ToMainMenu();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
