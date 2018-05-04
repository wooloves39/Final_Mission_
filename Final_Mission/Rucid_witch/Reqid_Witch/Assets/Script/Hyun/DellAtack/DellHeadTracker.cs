using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellHeadTracker : MonoBehaviour {
	private bool HeadOn = false;
	public bool getHeadOn() { return HeadOn; }
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			Debug.Log("바이올린 준비on");
			HeadOn = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			Debug.Log("바이올린 준비off");
			HeadOn = false;
		}
	}
}