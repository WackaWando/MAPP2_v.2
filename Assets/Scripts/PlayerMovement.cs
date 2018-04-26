using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    

    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float sidewaysForce = 100f;               // Reglerar hur snabbt man svänger  
    public float jumpHeight = 1000f;                   //Reglerar hur högt man hoppar
    public float rampSpeed = 1500f;                     //Reglerar hur långt man flyger efter man åkt på en ramp
    public PlayerMovement movement;


    
    private bool isGrounded;
    private Rigidbody player;
    private Vector3 forwardMovement;            
    private Vector3 sidewayMovement;
    private Vector3 jumpingMovement;
    private Vector3 rampMovement;

    Animator animator;


    void Start ()
    {    
        player = GetComponent<Rigidbody>();
        sidewayMovement.x = sidewaysForce;
        jumpingMovement.y = jumpHeight;
        forwardMovement.z = forwardForce;
        rampMovement.z = forwardForce;
        rampMovement.y = rampSpeed;
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {

        
    }

    private void OnCollisionExit(Collision collision)           //Kollar om man inte längre är i kontakt med något
    {
        if (collision.collider.tag == "Ground")
        {
            Debug.Log("not in contact with ground");
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)               //Kollar om man är i kontakt med något
    {   

        if (collisionInfo.collider.tag == "Ground")
        {
            Debug.Log("in contact with ground");
            isGrounded = true;
            animator.SetBool("Not ground", false);
        }
        
        if (collisionInfo.collider.tag == "Ramp")
        {
            isGrounded = false;
            player.AddForce(rampMovement * Time.deltaTime, ForceMode.VelocityChange);
            
        }

        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            player.constraints = RigidbodyConstraints.None;

            animator.SetTrigger("Die");
        }
    }

    void Update () {        
       
        player.AddForce(forwardMovement * Time.deltaTime);              //Flyttar spelaren framåt

        //Höger (behöver ändras till swipemovement)
        if (Input.GetKey("d"))
        {   
            player.AddForce(sidewayMovement * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Vänster
        if (Input.GetKey("a"))
        {
            player.AddForce(-sidewayMovement * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Hoppa
        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            player.AddForce(jumpingMovement * Time.deltaTime, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("Not ground",true);
        }
        //Falla snabbt
        if (isGrounded == false && Input.GetKeyDown(KeyCode.S))
        {
            player.AddForce(-jumpingMovement * Time.deltaTime, ForceMode.Impulse);
            animator.SetTrigger("PressDown");
        }
    }
}
