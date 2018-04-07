using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoSingleton<Employee> {
   // public GameObject 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowMain()
    {
        for(int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            Debug.Log(i);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
