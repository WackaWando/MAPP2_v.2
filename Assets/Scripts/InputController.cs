using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SwipeManager))]
public class InputController : MonoBehaviour
{ 

 //   public Player OurPlayer; // Perhaps your playerscript?

    void Start()
    {
        SwipeManager swipeManager = GetComponent<SwipeManager>();
        swipeManager.onSwipe += HandleSwipe;
        swipeManager.onLongPress += HandleLongPress;
    }

    void HandleSwipe(SwipeAction swipeAction)
    {
        //Debug.LogFormat("HandleSwipe: {0}", swipeAction);
        if (swipeAction.direction == SwipeDirection.Up || swipeAction.direction == SwipeDirection.UpRight)
        {
            // move up
            //       if (OurPlayer != null)
            //         OurPlayer.MovePlayerUp();
            Debug.Log("up");

        }
        else 
        if (swipeAction.direction == SwipeDirection.Right || swipeAction.direction == SwipeDirection.DownRight)
        {
            float step = 0;
            // move right
            //         if (OurPlayer != null)
            //           OurPlayer.MovePlayerRight();
            /*          while (step<5f)
                      {
                          transform.position += new Vector3(0.2f, 0f, 0.0f);
                          step += 0.2f;
                      }
                      step = 0;*/

          //  MoveFromTo(transform, transform.position, (transform.position + new Vector3(5,0,0)), 5f);
            Debug.Log("right");
        }
        else if (swipeAction.direction == SwipeDirection.Down || swipeAction.direction == SwipeDirection.DownLeft)
        {
            // move down
            //        if (OurPlayer != null)
            //          OurPlayer.MovePlayerDown();
            Debug.Log("down");
        }
        else if (swipeAction.direction == SwipeDirection.Left || swipeAction.direction == SwipeDirection.UpLeft)
        {
            // move left
            //    if (OurPlayer != null)
            //       OurPlayer.MovePlayerLeft();
            Debug.Log("left");
            transform.position += new Vector3(-5f, 0f, 0.0f);

        }
    }
    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        objectToMove.position = b;
    }
    void HandleLongPress(SwipeAction swipeAction)
    {
        //Debug.LogFormat("HandleLongPress: {0}", swipeAction);
    }
}