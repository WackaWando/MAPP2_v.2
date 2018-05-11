using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOrientation : MonoBehaviour {
    public Camera cam;

    void Update()
    {
        if (Screen.height < Screen.width)
        {
            cam.GetComponent<FixedWidth>().SetFOV(116);

        }
        else
        {
            cam.GetComponent<FixedWidth>().SetFOV(75);
        }
    }
}
