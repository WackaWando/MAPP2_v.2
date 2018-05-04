using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

    public Text starsText;
    public int noOfSpecial;
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
            string level = SceneManager.GetActiveScene().name;
            starsText.gameObject.SetActive(true);
            starsText.text = "Congratulations, you got " + stars + " star" + ((stars > 1) ?"s":"") ;
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

        }
        Debug.Log("" + PlayerPrefs.GetInt(level + "Stars"));
    }

    IEnumerator NextLevel()
    {
        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);

    }

}
