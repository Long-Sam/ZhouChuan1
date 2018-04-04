using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroySelf());
	}
	IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
