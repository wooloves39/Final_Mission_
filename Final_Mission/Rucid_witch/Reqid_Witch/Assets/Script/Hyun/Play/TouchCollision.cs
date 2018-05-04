using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollision : MonoBehaviour {
	private bool touch;
	private void Awake()
	{
		touch = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.GetComponent<TouchCollision>())
		{
			touch = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<TouchCollision>())
		{
			touch = false;
		}
	}
	public bool GetTouch() { return touch; }
}
