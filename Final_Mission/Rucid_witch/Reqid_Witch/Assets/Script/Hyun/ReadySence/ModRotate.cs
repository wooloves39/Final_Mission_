using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModRotate : MonoBehaviour {
	public bool setting;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (setting)
		{
			transform.Rotate(0, 180 * Time.deltaTime, 0);
		}
		else
		{
			transform.Rotate(0, -180 * Time.deltaTime, 0);

		}
	}
}
