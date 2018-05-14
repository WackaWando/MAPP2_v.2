using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour {
     CapsuleCollider[] rigColliders;
     Rigidbody[] rigRigidbodies;
    public bool ragdollActive = false ;


    void Start()
    {
        rigColliders = GetComponentsInChildren<CapsuleCollider>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    void fixedUpdate()
    {
        foreach (CapsuleCollider col in rigColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rb in rigRigidbodies)
        {
            rb.isKinematic = false;
        }

        if (ragdollActive) {

           foreach (CapsuleCollider col in rigColliders)
            {
                col.enabled = true;
            }
        }

    }

    public void OnDeath()
    {
        //wait 2-3 seconds.
        foreach (CapsuleCollider col in rigColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rb in rigRigidbodies)
        {
            rb.isKinematic = true;
        }
    }
}
