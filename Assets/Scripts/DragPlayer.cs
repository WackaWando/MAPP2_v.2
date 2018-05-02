using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayer : MonoBehaviour {
    public Transform player;
    private Rigidbody rbd;
    public Camera cam;
    private Vector3 screenPoint, offset, jumpingMovement;
    private Swipe swipeControls;
    private bool clickOnCharacter = false;
    Animator animator;




    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float sidewaysForce = 100f;               // Reglerar hur snabbt man svänger  
    public float jumpHeight = 1000f;                   //Reglerar hur högt man hoppar
    public float rampSpeed = 1500f;                     //Reglerar hur långt man flyger efter man åkt på en ramp




    private bool isGrounded;
    private Vector3 forwardMovement;
    private Vector3 sidewayMovement;
    private Vector3 rampMovement;

    void Start () {
        swipeControls = player.GetComponent<Swipe>();
        rbd = player.GetComponent<Rigidbody>();
        jumpingMovement.y = 30000;
        animator = GetComponent<Animator>();
        sidewayMovement.x = sidewaysForce;
        forwardMovement.z = forwardForce;
        rampMovement.z = forwardForce / 15;
        rampMovement.y = rampSpeed;
    }

    public void SetClickOnCharacter(bool sett)
    {
        clickOnCharacter = sett;
        swipeControls.SetClickOnCharacter(true);
    }


    void Update () {
        rbd.AddForce(forwardMovement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
        }
        if (Input.GetMouseButton(0) /*&& player.GetComponent<PlayerMovement>().GetIsGrounded*/ && clickOnCharacter)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z); // hardcode the y and z for your use

            Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint);
            //transform.position = curPosition;
            Vector3 vel = rbd.velocity;
            vel.x = (curPosition.x - player.transform.position.x) * 15;
            if (Mathf.Abs(vel.x) > 50)
            {
                vel.x = (vel.x > 0) ? 50 : -50;
            }
            rbd.velocity = vel;

        }
        if (!clickOnCharacter)
        {
            Vector3 vel = rbd.velocity;
            vel.x = 0f;
            rbd.velocity = vel;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 vel = rbd.velocity;
            vel.x = 0f;
            rbd.velocity = vel;
            clickOnCharacter = false;
            swipeControls.SetClickOnCharacter(false);
        }
        if (swipeControls.GetSwipeUp && player.GetComponent<CollisionManager>().GetIsGrounded)
        {
            player.GetComponent<CollisionManager>().SetIsGrounded(false);
            Vector3 curScreenPoint = new Vector3(screenPoint.x, screenPoint.y, screenPoint.z); // hardcode the y and z for your use
            Vector3 jumpDestination = new Vector3(player.position.x, player.position.y + 5f, player.position.z);
            Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint);
            Vector3 vel = rbd.velocity;
            vel = (jumpDestination - curPosition) * 3;
            vel.x = 0;
            rbd.velocity = vel;
            swipeControls.SetSwipeUp(false);
            animator.SetBool("Not ground", true);
            animator.SetBool("SwipeUp", true);


            //  player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, step);
        }
        if (swipeControls.GetSwipeDown && !player.GetComponent<CollisionManager>().GetIsGrounded)
        {
            rbd.AddForce(-jumpingMovement * Time.deltaTime, ForceMode.Impulse);
            //  animator.SetBool("SwipeDown", true);

        }
        else if (swipeControls.GetSwipeDown && player.GetComponent<CollisionManager>().GetIsGrounded)
        {
            animator.SetTrigger("SwipeDown");
        }


    }

    public void SetTimeScale(int sett) {
        Time.timeScale = sett;
    }
    }

