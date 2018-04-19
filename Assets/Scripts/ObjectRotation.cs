using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

    public int z;
    public int x;
    public int y;
  
  
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }


}
