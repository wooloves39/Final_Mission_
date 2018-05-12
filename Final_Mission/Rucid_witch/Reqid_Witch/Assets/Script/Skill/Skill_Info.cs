﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour {
	public bool OneHit = false;
	public float Power = 100.0f;

	public bool AreaHit = false;
	public float AreaDmg = 40.0f; // 0~100
	public float AreaCycle = 0.5f;

	public bool DotHit = false;
	public float DotDmg = 50.0f;
	public float DotTime = 5.0f;
	public float Cycle = 0.3f;

	public int HitCount = 4;
	private float[] Minus  = { 0,0,0};
	private List<GameObject> ObjList = new List<GameObject>();

	public float[] PowerMemory = { 0,0,0 };

	public float Delete_Delay_Time = 0.0f;

	public bool ElecShock = false;
	public float ShockTime = 2.0f;

	public GameObject effect;
	private void OnEnable()
	{
		PowerMemory[0] = Power;
		PowerMemory[1] = AreaDmg;
		PowerMemory[2] = DotDmg;
	}
	private void OnDisable()
	{
		ObjList = new List<GameObject>();
	}
	void Start () {
		Minus[0] = (float)(Power / HitCount);
		Minus[1] = (float)(AreaDmg/ HitCount);
		Minus[2] = (float)(DotDmg / HitCount);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag( "Monster"))
		{
			ObjList.Add(other.gameObject);
			ObjectLife temp;
			temp = other.GetComponentInParent<ObjectLife>();
			Instantiate(effect,other.transform.position,Quaternion.identity);
			if (OneHit)
			{
				if (!temp.MomentInvincible)
				{
					temp.SendMessage("SendDMG", PowerMemory[0]);
					if(ElecShock)
						temp.SendMessage("Shock",ShockTime);
					PowerMemory[0] -= Minus[0];
					if (PowerMemory[0] <= 0.0f)
					{
						Invoke("Delete", Delete_Delay_Time);
					}
				}
			}
			if (AreaHit)
			{
				if (!temp.MomentInvincible)
				{
					StartCoroutine("Area_Skill");
				}
			}
			if (DotHit)
			{
				if (!temp.MomentInvincible)
				{
					StartCoroutine("DotSkill", temp);
				}
			}
			
				
		}
	}
	void Delete()
	{
		this.gameObject.SetActive(false);
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Monster")
		{
			ObjList.Remove(other.gameObject);
		}
	}
	IEnumerator Area_Skill()
	{
		ObjectLife temp;
		while (PowerMemory [1] > 0) 
        {
            yield return new WaitForSeconds(Cycle);
			for (int j = 0; j < ObjList.Count; ++j)
			{
				if (ObjList[j].activeInHierarchy == false)
					continue;
				temp = ObjList [j].GetComponentInParent<ObjectLife> ();
				temp.SendMessage ("SendAreaDMG", Minus[1]);
				if (ElecShock)
					temp.SendMessage ("Shock", ShockTime);

			}
			PowerMemory[1] -= Minus[1];
		}
		yield return new WaitForSeconds(Delete_Delay_Time);
	}
	IEnumerator DotSkill(ObjectLife obj)
	{
		float Dmg = PowerMemory[2] / (DotTime/Cycle);
		float time = 0.0f;
		bool b = false;
		PowerMemory[2] -= Minus[2];
		if (PowerMemory[2] <= 0.0f)
		{
			yield return new WaitForSeconds(Delete_Delay_Time);
			this.gameObject.SetActive(false);
		}
		while (time <= DotTime)
		{
			if(obj.isActiveAndEnabled)
				obj.SendMessage("SendDMG", Dmg);
			if (!b)
			{
				b = true;
				if (ElecShock)
					obj.SendMessage("Shock",ShockTime);
			}
			time += Cycle;
			yield return new WaitForSeconds(Cycle);
		}
	}
}
