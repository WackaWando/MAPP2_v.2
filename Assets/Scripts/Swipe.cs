using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight, swipeUp, clickOnCharacter = false, swipeDown,  swiped = false,  countTime = false, touchingScreen = false;
    private Vector2 startTouch, swipeDelta, endTouch;
    private Vector3 screenPoint;
    private float swipeTime, ratioHeight;
    public Text text;
    private int height = Screen.height;
    private DragPlayer controls;

    public void SetClickOnCharacter(bool sett) {
        clickOnCharacter = sett;
    }

    private void Update() {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
    



        if (Input.GetMouseButtonDown(0) )
        {
            swipeDelta = Vector2.zero;
            tap = true;
            startTouch = Input.mousePosition;
            swipeTime = 0;
            countTime = true;
            touchingScreen = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {

            countTime = false;
            touchingScreen = false; 
            endTouch = Input.mousePosition;
            swipeDelta.y = endTouch.y - startTouch.y;
            swiped = true;
            ratioHeight = Mathf.Abs(swipeDelta.y) / height;
        }
        if (countTime)
        {
            swipeTime += Time.deltaTime;

        }

        if (clickOnCharacter)
        {
            swipeTime = 0;
        }

        if (ratioHeight > 0.1 && !touchingScreen && swipeTime < 0.5 && swiped)
        {
 
            swiped = false;
            float y = swipeDelta.y;
          //  text.text = "" + y;
         /*   if (Mathf.Abs(x)>Mathf.Abs(y))
            {
                if (x<0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }

            }
            else
            {*/

                if (y<0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;

                }

            //}


            Reset();
        }
    }

    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
    }

    public Vector2 GetSwipeDelta
    {
        get { return swipeDelta; }
    }
    public void SetSwipeUp(bool sett) {
        swipeUp = sett;
    }
    public bool GetSwipeLeft {
        get { return swipeLeft; }
    }
    public bool GetSwipeRight
    {
        get { return swipeRight; }
    }
    public bool GetSwipeUp
    {
        get { return swipeUp; }
    }
    public bool GetSwipeDown
    {
        get { return swipeDown; }
    }
    public bool GetTap {
    get { return tap; }
    }
}
