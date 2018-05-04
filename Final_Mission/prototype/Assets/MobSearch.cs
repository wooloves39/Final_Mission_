using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSearch : MonoBehaviour {
	public bool Search = false;
	public Vector3 PlayerPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			Search = true;
			PlayerPos = other.GetComponentInParent<Move> ().transform.position;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			Search = false;
		}
	}
}
