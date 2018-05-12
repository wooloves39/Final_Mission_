using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
	public Animator LHandAni;
	public Animator RHandAni;
	// Use this for initialization
	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.LTouchHandleOn()&& InputManager_JHW.LTriggerOn())
		{
			LHandAni.Play("Fist");

		}
		else if (InputManager_JHW.LTouchHandleOn())
		{
			LHandAni.Play("restDown");
		}
		else if (InputManager_JHW.LTriggerOn())
		{
			LHandAni.Play("IndexFingerDown");
			
		}
		else
		{
			LHandAni.Play("Idle");
		}
		if (InputManager_JHW.RTouchHandleOn() && InputManager_JHW.RTriggerOn())
		{
			RHandAni.Play("Fist");

		}
		else if (InputManager_JHW.RTouchHandleOn())
		{
			RHandAni.Play("restDown");
		}
		else if (InputManager_JHW.RTriggerOn())
		{
			RHandAni.Play("IndexFingerDown");

		}
		else
		{
			RHandAni.Play("Idle");
		}
	}

}
