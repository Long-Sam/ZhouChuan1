using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour {
    float devHeight = 1024;
    float devWidth = 768;
	// Use this for initialization
	void Start () {
        float screenHeight= Screen.height;

        float orthorgaSize = GetComponent<Camera>().orthographicSize;

        float aspectRatio = Screen.width * 1.0f / Screen.height;

        float cameraWidth = orthorgaSize * 2 * aspectRatio;

        if (cameraWidth < devWidth)
        {
            orthorgaSize = devWidth / (2 * aspectRatio);
            this.GetComponent<Camera>().orthographicSize = orthorgaSize;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
