using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elecshot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.down * Time.deltaTime * 10.0f);
		if (this.transform.position.y <= 0)
			Destroy (this.gameObject);
	}
}
