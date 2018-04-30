﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight, swipeUp, clickOnCharacter = false, swipeDown, isDraging, swiped = false, isDragable = true, countTime = false, touchingScreen = false;
    private Vector2 startTouch, swipeDelta, endTouch;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float swipeTime, ratioHeight;
    public Text text;
    private int height = Screen.height;
    private DragPlayer controls;

    public void SetClickOnCharacter(bool sett) {
        clickOnCharacter = sett;
    }

    private void Update() {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
    
        if (Input.GetMouseButton(0))
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
 
        }


        if (Input.GetMouseButtonDown(0) )
        {
            swipeDelta = Vector2.zero;
            tap = true;
            startTouch = Input.mousePosition;
            swipeTime = 0;
            countTime = true;
            touchingScreen = true;
            //text.text = "started " + startTouch + " " + swipeDelta.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
          //  Reset();
            countTime = false;
            touchingScreen = false; 
            endTouch = Input.mousePosition;
            swipeDelta.y = endTouch.y - startTouch.y;
            Debug.Log(swipeDelta.y);
            swiped = true;
            ratioHeight = Mathf.Abs(swipeDelta.y) / height;
           // text.text = "ended " + endTouch + " " + swipeDelta.y;
        }
        if (countTime)
        {
            swipeTime += Time.deltaTime;

        }

        if (clickOnCharacter)
        {
            swipeTime = 0;
        }

        /*#region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

             if (Input.touches.Length >0)
             {
                 swipeDelta = Input.touches[0].position - startTouch;
             }
             else if (Input.GetMouseButton(0))
             {
                 swipeDelta = (Vector2)Input.mousePosition - startTouch;
             }
             */
    //    text.text = "" + PlayerPrefs.GetInt("Highscore", 0);
        if (ratioHeight > 0.15 && !touchingScreen && swipeTime < 0.5 && swiped)
        {
 
            swiped = false;
            float x = swipeDelta.x, y = swipeDelta.y;
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
        isDraging = false;
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
