using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellMonBuff : MonoBehaviour {
	private float Upspeed;
	private float Curspeed;

	private float HpVal=1.0f;

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
		StartCoroutine(HpUpCor());
		if (objectLife.Hp < objectLife.MaxHp / 2) objectLife.Hp = objectLife.MaxHp;
	}
	private void OnDisable()
	{
		objectLife.Speed = Curspeed;
	}
	IEnumerator HpUpCor()
	{
		while (true)
		{
			yield return new WaitForSeconds(1.0f);
			if (objectLife.Hp < objectLife.MaxHp) objectLife.Hp = HpVal;
		}
	}
}
