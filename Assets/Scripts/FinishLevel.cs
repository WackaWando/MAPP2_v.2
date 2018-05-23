using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

    public Text starsText;
    public int noOfSpecial;
    public GameObject scoreScreen, endPanel;

    private Animator starAnimator;
    private int stars=1;

   


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("Special", 0) == noOfSpecial)
            {
                stars++;
            }
            if (PlayerPrefs.GetInt("Died", 0) == 0)
            {
                stars++;
            }
            scoreScreen.gameObject.SetActive(true);
            starAnimator = endPanel.GetComponent<Animator>();
            starAnimator.SetInteger("Stars", stars);
            Debug.Log("special " + PlayerPrefs.GetInt("Special", 0));
            string level = SceneManager.GetActiveScene().name;
            //starsText.text = "Congratulations, you got " + stars + " star" + ((stars > 1) ?"s":"") ;
            increaseStars(level, stars);
            StartCoroutine(NextLevel());
        }
        

    }
    private void increaseStars(string level, int stars)
    {
        int starsGained = PlayerPrefs.GetInt(level+ "Stars",0);
        if (stars > starsGained)
        {
            PlayerPrefs.SetInt((level + "Stars"), stars);
            PlayerPrefs.SetInt(("totalStars"), PlayerPrefs.GetInt("totalStars") + stars - starsGained);

        }
        Debug.Log("" + PlayerPrefs.GetInt(level + "Stars"));
    }

    

    IEnumerator NextLevel()
    {
        
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
