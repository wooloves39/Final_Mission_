using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dell_QuickStep : MonoBehaviour {
	private MoveCtrl Playermove;
	private float curspeed;
	private void Awake()
	{
		Playermove = GetComponentInParent<MoveCtrl>();
		curspeed = Playermove.speed;
	}
	private void OnEnable()
	{
		Playermove.speed *= 1.5f;
	}
	private void OnDisable()
	{
		Playermove.speed = curspeed;
	}
	public void BuffUp() { Playermove.speed *= 1.5f; }
}
