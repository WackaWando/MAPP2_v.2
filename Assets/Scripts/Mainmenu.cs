using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject levels, mainMenu, options;
    private Animator animatorMenu, animatorLevels, animatorOptions;
    private bool levelsOn, optionsOn;

    private void Start()
    {
        animatorMenu = mainMenu.GetComponent<Animator>();
        animatorLevels = levels.GetComponent<Animator>();
        animatorOptions = options.GetComponent<Animator>();
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
        else if (optionsOn && Input.GetKeyDown("escape"))
        {
            animatorOptions.SetTrigger("closeLevels");
            optionsOn = false;
            StartCoroutine(NextAnimation(animatorMenu, "openMenu"));
        }
    }

    public void PlayGame()
    {
        animatorMenu.SetTrigger("closeMenu");
        levelsOn = true;
        StartCoroutine(NextAnimation(animatorLevels, "openLevels"));
    }
    public void Options()
    {
        animatorMenu.SetTrigger("closeMenu");
        optionsOn = true;
        StartCoroutine(NextAnimation(animatorOptions, "openLevels"));
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

    public void GoBackL()
    {     
            animatorLevels.SetTrigger("closeLevels");
            levelsOn = false;
            StartCoroutine(NextAnimation(animatorMenu, "openMenu"));
    }
    public void GoBackO() {

            animatorOptions.SetTrigger("closeLevels");
            optionsOn = false;
            StartCoroutine(NextAnimation(animatorMenu, "openMenu"));

    }

    public void Veg() {
        if (PlayerPrefs.GetInt("veg", 0) == 0)
        {
            PlayerPrefs.SetInt("veg", 1);
        }
        else if (PlayerPrefs.GetInt("veg", 0) == 1)
        {
            PlayerPrefs.SetInt("veg", 0);
        }

    }

}

