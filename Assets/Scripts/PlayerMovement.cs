using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public Rigidbody player;
    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float sidewaysForce = 100f;               // Reglerar hur snabbt man svänger  

    public float jumpHeight = 50f;
    //public float jumpLenght = 100f;

    private Vector3 forwardMovement;            
    private Vector3 sidewayMovement;
    private Vector3 jumpingMovement;



    void Start () {

        sidewayMovement.x = sidewaysForce;
       
        jumpingMovement.y = jumpHeight;

        //jumpingMovement.z = jumpLenght;
        forwardMovement.z = forwardForce;

        
    }

    
    void FixedUpdate() {

        player.AddForce(forwardMovement * Time.deltaTime);              //Flyttar spelaren framåt

        //Flyttar spelare höger och vänster (behöver ändras till swipemovement)
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            player.AddForce(sidewayMovement * Time.deltaTime, ForceMode.VelocityChange);         
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            player.AddForce(-sidewayMovement * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
    
    void Update () {

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            player.AddForce(jumpingMovement * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
