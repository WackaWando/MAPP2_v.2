using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public Transform PlayerTranform;
    private Vector3 _cameraOffset;
    [Range(0.01f,1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;
	// Use this for initialization
	void Start () {
        _cameraOffset = transform.position - PlayerTranform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Vector3 newPos = PlayerTranform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPos,SmoothFactor);
        if (LookAtPlayer) {
            transform.LookAt(PlayerTranform);
        }
    }
}
