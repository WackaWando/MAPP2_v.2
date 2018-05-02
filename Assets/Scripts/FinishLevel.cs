using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

    public Text starsText;

    private int stars = 1;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("Special", 0) == 1)
            {
                stars++;
            }
            if (PlayerPrefs.GetInt("Died", 0) == 0)
            {
                stars++;
            }
            starsText.gameObject.SetActive(true);
            starsText.text = "Congratulations, you got " + stars + " star" + ((stars > 1) ?"s":"") ;
            StartCoroutine(NextLevel());
        }
        

    }
     IEnumerator NextLevel()
    {

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);

    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
