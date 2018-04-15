using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sys : MonoSingleton<Sys>
{

	// Use this for initialization
	void Start () {
		
	}

    public void ShowMain()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            Debug.Log(i);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
