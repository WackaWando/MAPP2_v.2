using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAnimation : MonoBehaviour {

    public Rigidbody rigBod;

    // Use this for initialization
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FreezePoop() /*Function used in Animation Event where all constraints for the Rigidbody2D are frozen.*/
    {
        rigBod.constraints = RigidbodyConstraints.FreezePosition;
    }

    void UnfreezePoop() /*Function used in Animation Event where all constraints for the Rigidbody2D are unfrozen.*/
    {
        rigBod.constraints = RigidbodyConstraints.None;
    }
}
