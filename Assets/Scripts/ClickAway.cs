using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAway : MonoBehaviour {

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponentInParent<DragPlayer>().SetClickClose(true);
        }
    }
}
