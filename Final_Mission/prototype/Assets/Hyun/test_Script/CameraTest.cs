using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			CameraFade.StartAlphaFade(Color.white,false,1f);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			CameraFade.BlinkingFade(new Color(1,0,0,0.2f), .3f,0.04f);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			CameraFade.StartAlphaFade(new Color(1, 0, 0, 0.5f),false, 3f);
		}
	}
}
