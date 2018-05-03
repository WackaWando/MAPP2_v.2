using UnityEngine;

public class CollisionManager : MonoBehaviour {

    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float rampSpeed = 1500f;                     //Reglerar hur långt man flyger efter man åkt på en ramp
    private bool isGrounded;
    private Rigidbody player;
    private Vector3 rampMovement;
    Animator animator;

    void Start ()
    {    
        player = GetComponent<Rigidbody>();
        rampMovement.z = forwardForce/6.6f;
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
            StartCoroutine(player.GetComponent<DragPlayer>().Die());
        }
    }

    void OnCollisionEnter(Collision collisionInfo)               //Kollar om man är i kontakt med något
    {   

        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Not ground", false);
            animator.SetTrigger("Grounded");
        }
        
        if (collisionInfo.collider.tag == "Ramp")
        {
            isGrounded = false;
            player.AddForce(rampMovement * Time.deltaTime, ForceMode.VelocityChange);
            animator.SetTrigger("SwipeUp");
        }
        else if (collisionInfo.collider.tag == "Obstacle")
        {
            StartCoroutine(player.GetComponent<DragPlayer>().Obstacle());
        }

    }

}
