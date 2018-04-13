using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public Rigidbody player;
    public float forwardForce = 2000f;               //Reglerar hur fort man springer    
    public float sidewaysForce = 100f;               // Reglerar hur snabbt man svänger  

    private Vector3 forwardMovement;            
    private Vector3 sidewayMovement;



    void Start () {

        forwardMovement.z = forwardForce;
        sidewayMovement.x = sidewaysForce;
    }

    //Tydligen bättre för fysikmotorn än Update() 
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
        
       
	}
}
