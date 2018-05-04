using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour {
	public GameObject[] next;
	public string enemy;
	int i = 0 ;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (next[i].transform.position);
		this.transform.Translate (Vector3.forward*3*Time.deltaTime);

		if (Vector3.Distance (this.transform.position, next [i].transform.position) < 0.05f) {
			if (i < 8)
				++i;
			else
				i = 1;
		}
	}
}
