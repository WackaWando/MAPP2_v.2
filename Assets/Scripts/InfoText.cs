using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {
    public Text text;
    Animator anim;
    
	void Start () {
        anim = GetComponentInParent<Animator>();
	}

    public void MoreStars() {
        text.text = "YOU NEED MORE STARS TO UNLOCK THIS LEVEL";
        StartCoroutine(Animation());
    }

    public void NotReady() {
        text.text = "THIS IS A DEMO" + "\n" + "MORE LEVELS TO COME";
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("InfoText"))
        {
            anim.SetTrigger("Open");
            yield return new WaitForSeconds(5f);
            anim.SetTrigger("Close");
        }

    }



}
