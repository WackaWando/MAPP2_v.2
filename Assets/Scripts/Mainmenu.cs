using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject levels;
    private Animator animatorMenu, animatorLevels;
    private bool levelsOn;

    private void Start()
    {
        animatorMenu = GetComponent<Animator>();
        animatorLevels = levels.GetComponent<Animator>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (levelsOn && Input.GetKeyDown("escape"))
        {
            animatorLevels.SetTrigger("closeLevels");
            levelsOn = false;
            StartCoroutine(NextAnimation(animatorMenu, "openMenu"));
        }
    }

    public void PlayGame()
    {
        animatorMenu.SetTrigger("closeMenu");
        levelsOn = true;
        StartCoroutine(NextAnimation(animatorLevels, "openLevels"));
    }


    public void QuitGame()
    {
        Application.Quit();

    }

    public IEnumerator NextAnimation(Animator anim, string trigger)
    {

        yield return new WaitForSeconds(0.8f);
        anim.SetTrigger(trigger);

    }

}

