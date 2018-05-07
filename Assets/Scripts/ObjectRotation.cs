using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

    public int z;
    public int x;
    public int y;
  public bool bounce;
    public int bounceTime;
    public int speed = 2;

    
    void Update()
    {
        
        if (bounce)
        {
            transform.rotation = Quaternion.Euler(x, y, bounceTime * Mathf.Sin(Time.time * speed));
        }
        else
            transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }

    
}
