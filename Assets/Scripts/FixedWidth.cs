using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class FixedWidth : MonoBehaviour
    {
    //This is the field of view that the Camera has
    public float horizontalFOV = 75f;

        void Start()
        {
       
    }

        void Update()
        {
        GetComponent<Camera>().fieldOfView = calcVerticalFOV(horizontalFOV, GetComponent<Camera>().aspect);


    }

    private float calcVerticalFOV(float horizontalFOV, float aspectRatio)
    {
        float hFOVInRads = horizontalFOV * Mathf.Deg2Rad;
        float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
        float vFOV = vFOVInRads * Mathf.Rad2Deg;
        return vFOV;
    }

    }
