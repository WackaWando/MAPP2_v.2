﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragArea : MonoBehaviour {

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponentInParent<DragPlayer>().SetClickOnCharacter(true);
        }
    }
    }
