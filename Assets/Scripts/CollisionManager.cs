using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float rampSpeed = 1500f;                     //Reglerar hur långt man flyger efter man åkt på en ramp
    private bool isGrounded;
    private Rigidbody player;
    private Vector3 rampMovement;
    Animator animator;
	public GameObject runngTrail;
	public GameObject hitParticle;

    private AudioSource source;
    public AudioClip jump;
    public AudioClip land_sound;
	public AudioClip dead_sound;

	public RagDoll rag;


    void Start ()
    {    
        player = GetComponent<Rigidbody>();
        rampMovement.z = forwardForce/6.6f;
        rampMovement.y = rampSpeed;
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
		hitParticle.SetActive (false);

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
			runngTrail.SetActive (false);
			isGrounded = false;
            source.PlayOneShot(jump);
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
            source.PlayOneShot(land_sound);
            isGrounded = true;
            animator.SetBool("Not ground", false);
            animator.SetTrigger("Grounded");
			runngTrail.SetActive (true);
           
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
			hitParticle.SetActive (true);
			source.PlayOneShot(dead_sound);
			rag.RagdollActive ();
			StartCoroutine(delay());
		}

    }


	 IEnumerator delay()
	{
		yield return new WaitForSeconds(0.5f);
		Debug.Log ("stop particle");
		hitParticle.SetActive (false);

	}
}
