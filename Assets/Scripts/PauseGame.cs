using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    private bool pauseGame = false;
    public Transform player;

    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pauseGame = true;
        }
        if (pauseGame)
        {
            if (!pausePanel.activeInHierarchy)
            {
                Pause();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
            pauseGame = false;
        }
    }
    private void Pause()
    {
        player.GetComponent<DragPlayer>().SetTimeScale(0);
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0

    }
    private void ContinueGame()
    {

        player.GetComponent<DragPlayer>().SetTimeScale(1);
        pausePanel.SetActive(false);
        //enable the scripts again
    }

    public void SetPause(bool sett) {
        pauseGame = sett;
    }

}