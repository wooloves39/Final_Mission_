﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kali_Skill_Attack : MonoBehaviour {

	private float damage = 0.0f;
	public float skillBalance;
	public bool dot = false;
	public float delay = 0.0f;
	PlayerState Player;
	bool ranged = false;
	int num = 0;
	private void OnEnable()
	{
		num = 0;
		damage = skillBalance;
		ranged = false;
	}
	void OnTriggerEnter(Collider other)
	{
		if(!dot)
			if (other.CompareTag("Player"))
			{
				Player = other.GetComponentInParent<PlayerState>();
				if (Player != null)
				{
					Invoke("DelayDamage",delay);
				}
			}
	}
	void DelayDamage()
	{
		Player.DamageHp(damage);
	}
	void OnTriggerStay(Collider other)
	{
		if (dot)
			if (other.CompareTag("Player"))
			{
				{
					Player = other.GetComponentInParent<PlayerState>();
					if (Player != null)
					{
						ranged = true;
					}
				}
			}
	}
	void OnTriggerExit(Collider other)
	{
		if (dot)
			if (other.CompareTag("Player"))
			{
				{
					Player = other.GetComponentInParent<PlayerState>();
					if (Player != null)
					{
						ranged = false;
					}
				}
			}
	}
	private void Update()
	{
		if(dot)
		{
			if (ranged)
			{
				num++;
				if (num > 10)
				{
					Player.DamageHp(damage);
					num = 0;
				}
			}
		}
	}
}
