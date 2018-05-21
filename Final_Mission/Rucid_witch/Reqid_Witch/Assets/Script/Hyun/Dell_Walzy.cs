using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dell_Walzy : MonoBehaviour {
	private PlayerState Playerstate;
	private float curspeed;
	private void Awake()
	{
		Playerstate = GetComponentInParent<PlayerState>();
		curspeed = Playerstate.RecoveryTime;
	}
	private void OnEnable()
	{
		Playerstate.RecoveryTime *= 0.85f;
	}
	private void OnDisable()
	{
		Playerstate.RecoveryTime= curspeed;
	}
	public void BuffUp() { Playerstate.RecoveryTime *= 0.75f; }
}
