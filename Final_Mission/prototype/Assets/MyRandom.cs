using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRandom : MonoBehaviour {
	// Use this for initialization
	public bool check = false;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "PlayerHit") {
			check = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "PlayerHit") {
			check = false;
		}
	}
}
