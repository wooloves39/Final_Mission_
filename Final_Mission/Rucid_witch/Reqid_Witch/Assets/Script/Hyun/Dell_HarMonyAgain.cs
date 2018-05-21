using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dell_HarMonyAgain : MonoBehaviour
{
	public Dell_Walzy Walzy;
	public Dell_QuickStep QuickStep;
	private PlayerState playerState;
	// Use this for initialization
	private void Awake()
	{
		playerState = GetComponentInParent<PlayerState>();
	}
	private void OnEnable()
	{
		if (playerState.Hp + playerState.Hp / 2 >= 100.0f) playerState.Hp = 100.0f;
		else
		{
			playerState.Hp += playerState.Hp / 2;
		}
		if (playerState.Mp + playerState.Mp / 2 >= 100.0f) playerState.Mp = 100.0f;
		else
		{
			playerState.Mp += playerState.Mp / 2;
		}
		if (QuickStep.gameObject.activeSelf)
		{
			QuickStep.BuffUp();
			QuickStep.GetComponent<Dell_Buff_Active>().BuffReset();
		}
		if (Walzy.gameObject.activeSelf)
		{
			Walzy.BuffUp();
			Walzy.GetComponent<Dell_Buff_Active>().BuffReset();
		}
	}
}
