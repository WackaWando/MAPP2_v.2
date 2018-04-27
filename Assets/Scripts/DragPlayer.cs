using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayer : MonoBehaviour {
    public Transform player;
    private Rigidbody rbd;
    public Camera cam;
    private Vector3 screenPoint, offset, jumpingMovement;
    private Swipe swipeControls;


    void Start () {
        swipeControls = player.GetComponent<Swipe>();
        rbd = player.GetComponent<Rigidbody>();
        jumpingMovement.y = 1000;
    }
	
 

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(rbd.velocity.z);
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
        }
        if (Input.GetMouseButton(0) && player.GetComponent<PlayerMovement>().GetIsGrounded)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z); // hardcode the y and z for your use

            Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint);
            //transform.position = curPosition;
            Vector3 vel = rbd.velocity;
            vel.x = (curPosition.x - player.transform.position.x) * 15;
            rbd.velocity = vel;

        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 vel = rbd.velocity;
            vel.x = 0f;
            rbd.velocity = vel;
        }
        if (swipeControls.GetSwipeUp && player.GetComponent<PlayerMovement>().GetIsGrounded)
        {
            player.GetComponent<PlayerMovement>().SetIsGrounded(false);
            Vector3 curScreenPoint = new Vector3(screenPoint.x, screenPoint.y, screenPoint.z); // hardcode the y and z for your use
            Vector3 jumpDestination = new Vector3(player.position.x, player.position.y + 5f, player.position.z);
            Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint);
            Vector3 vel = rbd.velocity;
            vel = (jumpDestination - curPosition) * 3;
            rbd.velocity = vel;
            swipeControls.SetSwipeUp(false);
            
            //  player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, step);
        }
        if (swipeControls.GetSwipeDown)
        {
            rbd.AddForce(-jumpingMovement * Time.deltaTime, ForceMode.Impulse);
        }



        }
    }

