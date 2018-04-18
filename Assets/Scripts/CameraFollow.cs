using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 distanceFromPlayer;  //default value x:0, y:1.5, z: -4   set in inspector.





	void Update () {

        transform.position = player.position + distanceFromPlayer;
	}
}
