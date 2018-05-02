using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    private bool pauseGame = false;

    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (pauseGame)
        {
            if (!pausePanel.activeInHierarchy)
            {
                Debug.Log("pause");
                Pause();
            }
            if (pausePanel.activeInHierarchy)
            {
                Debug.Log("continue");
                ContinueGame();
            }
        }
    }
    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }

    public void SetPause(bool sett) {
        pauseGame = sett;
    }

}