using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 distanceFromPlayer;  //default value x:0, y:1.5, z: -4   set in inspector.


    private bool passedFinishLine;
    private float playerPositionZ;

    void Start()
    {
        passedFinishLine = false;
    }

    private void FixedUpdate()
    {
        playerPositionZ = player.position.z;
        if (playerPositionZ > 849)
        {
            passedFinishLine = true;
        }

        if (passedFinishLine == false)
        {
            transform.position = player.position + distanceFromPlayer;
        }
    }
    void Update () {

       
            
        
        
    }

    
}
