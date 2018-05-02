using UnityEngine;

public class CollisionManager : MonoBehaviour {


    

    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float sidewaysForce = 100f;               // Reglerar hur snabbt man svänger  
    public float jumpHeight = 1000f;                   //Reglerar hur högt man hoppar
    public float rampSpeed = 1500f;                     //Reglerar hur långt man flyger efter man åkt på en ramp


    
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
        rampMovement.z = forwardForce/15;
        rampMovement.y = rampSpeed;
        animator = GetComponent<Animator>();

    }

    public bool GetIsGrounded {
        get {
            return isGrounded;
        }
    }

    public void SetIsGrounded (bool sett){
    isGrounded = sett; 
    }


    private void OnCollisionExit(Collision collision)           //Kollar om man inte längre är i kontakt med något
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deathzone")
        {
            Debug.Log("Die");
        }
    }

    void OnCollisionEnter(Collision collisionInfo)               //Kollar om man är i kontakt med något
    {   

        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Not ground", false);
            // Vector3 vel = player.velocity;
            //vel.y = 0;
            //player.velocity = vel;
            animator.SetTrigger("Grounded");
        }
        
        if (collisionInfo.collider.tag == "Ramp")
        {
            isGrounded = false;
            player.AddForce(rampMovement * Time.deltaTime, ForceMode.VelocityChange);

            animator.SetBool("SwipeUp", true);
            animator.SetTrigger("SwipeUp");
        }

      /*  if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            player.constraints = RigidbodyConstraints.None;

            animator.SetTrigger("Die");
        }*/
    }

}
