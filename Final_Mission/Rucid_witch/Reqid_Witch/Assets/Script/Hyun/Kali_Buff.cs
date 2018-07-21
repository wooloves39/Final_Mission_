using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kali_Buff : MonoBehaviour {
	private float Upspeed;
	private float Curspeed;
	private float HpVal = 1.0f;

	//쿨타임도 줄일수 있도록 준비해보자
	private ObjectLife objectLife;
	private void Awake()
	{
		objectLife = GetComponentInParent<ObjectLife>();
		Curspeed = objectLife.Speed;
		Upspeed = Curspeed * 1.5f;
	}
	private void OnEnable()
	{
		objectLife.Speed = Upspeed;
	}
	private void OnDisable()
	{
		objectLife.Speed = Curspeed;
	}
}
