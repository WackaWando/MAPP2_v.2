using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 distanceFromPlayer;





	void Update () {

        transform.position = player.position + distanceFromPlayer;
	}
}
