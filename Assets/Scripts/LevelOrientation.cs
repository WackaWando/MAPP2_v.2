using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;

        //Portrait//PortraitUpsideDown//LandscapeRight//AutoRotation
    }
}
