using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour {
	public GameObject Tower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Jump"))
		{
			Tower.transform.position = this.transform.position;
			Instantiate(Tower);
		}
	}
}
