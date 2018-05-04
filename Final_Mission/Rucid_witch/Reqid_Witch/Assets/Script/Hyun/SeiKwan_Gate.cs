using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwan_Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Monster")) { Debug.Log("여기서행동 불가 상태를 줘"); }
	}
}
