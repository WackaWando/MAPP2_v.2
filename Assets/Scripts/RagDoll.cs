using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour {
     CapsuleCollider[] rigColliders;
     Rigidbody[] rigRigidbodies;
    public  Animator anim;
    public bool ragdollActive = false ;


    void Start()
    {
        rigColliders = GetComponentsInChildren<CapsuleCollider>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();
       // anim = GetComponent<Animator>();
        SetKinematic(true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            ragdollActive = true;
            SetKinematic(false);
            anim.enabled = false;
        }

        /*
          
         
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
*/
    }
    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
         foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    public void RagdollActive()
    {
		SetKinematic(false);
		anim.enabled = false;
    }
}



