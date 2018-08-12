﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwanSkill : MonoBehaviour
{

	// Use this for initialization
	private int skill;
	private GameObject target;
	private float handDis;
	public float HandeDis { get { return handDis; } set { handDis = value; } }
	float deltaTime;
	public GameObject Gate;
	public GameObject[] sky_Arraws;
	public GameObject arrow_trab_particle;
	public GameObject[] trab_object;

	private bool Shoot = false;
	private bool del_timer = false;
	public bool Del_timer { get { return del_timer; } set { del_timer = value; } }
	//private Collider collider;
	public GameObject SeiKwanArrow;
	private CoolDown CoolTime;

	private Vector3 curScale;
	private Rigidbody rigi;
    private Quaternion bagicRota;
    private PlayerState player;
    public bool MonsterAttack = false;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
		CoolTime = FindObjectOfType<CoolDown>();
        player = CoolTime.GetComponent<PlayerState>();
		rigi = GetComponent<Rigidbody>();
        bagicRota = this.transform.rotation;
	}
	public void shoot(int skillIndex, GameObject targets, float handDistance,
	float del_time = 10.0f, float Gage=0)
	{
		float chargingGage = Gage + 1;
		bool Mp = false;
		bool Cool = false;
		transform.localScale = transform.localScale * 3;
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
        if (MonsterAttack)
        {
            switch (skill)
            {
                case 1:
                    BraveArrow(chargingGage);
                    break;
                case 2:
                    ArrowTrab(chargingGage);
                    break;
                case 3:
                    SkyArrow(targets.transform.position, chargingGage);
                    break;
                case 5:
                    HavensGate(targets.transform.position, chargingGage);
                    break;
            }
            //CoolTime.MpDown(2, skill);
            if (skill == 5) del_time += 20f;
            //if (skill > 1) UseOtherObject();
            Shoot = true;
            StartCoroutine(Shooting(del_time));
        }
        else
        {
            if (CoolTime.CheckCool(2, skill))
            {
                Cool = true;
            }
            if (CoolTime.CheckMp(2, skill))
            {
                Mp = true;
            }
            if (!Cool && !Mp)
            {
                CoolTime.SetCool(2, skill);
                CoolTime.MpDown(1, skill);
                switch (skill)
                {
                    case 1:
                        BraveArrow(chargingGage);
                        break;
                    case 2:
                        ArrowTrab(chargingGage);
                        break;
                    case 3:
                        SkyArrow(targets.transform.position, chargingGage);
                        break;
                    case 5:
                        HavensGate(targets.transform.position, chargingGage);
                        break;
                }
                //CoolTime.MpDown(2, skill);
                if (skill == 5) del_time += 20f;
                //if (skill > 1) UseOtherObject();
                Shoot = true;
                StartCoroutine(Shooting(del_time));
            }
        }
		target = null;
	}
	//#### #### #### #### 기본
	private void BraveArrow(float chargingGage)
	{
		SeiKwanArrow.GetComponentInChildren<Skill_Sound_Set>().check = true;
		if(SeiKwanArrow.GetComponent<Skill_Info>())
		SeiKwanArrow.GetComponent<Skill_Info>().chargingSet(chargingGage);
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.zero;
		if (target)
		{
			TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		}
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			rigi.velocity = Arrowforward * 25f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			rigi.velocity = TargettingDir * 25f * handDis;
		}
	}
	//#### #### #### #### 
	private void ArrowTrab(float chargingGage)
	{
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.zero;
		if (target)
		{
			TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		}
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			rigi.velocity = Arrowforward * 25f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			rigi.velocity = TargettingDir * 25f * handDis;
		}
		Debug.Log(handDis);
		StartCoroutine(ArrowTrabCor(.15f, chargingGage));
	}
	IEnumerator ArrowTrabCor(float timer,float chargingGage)
	{

		yield return new WaitForSeconds(timer);
		SeiKwanArrow.SetActive(false);
		arrow_trab_particle.SetActive(true);
		for (int i = 0; i < trab_object.Length; ++i)
		{
			trab_object[i].transform.position = this.transform.position + new Vector3(Random.Range(-1.50f, 1.50f), Random.Range(-1.50f, 1.50f), Random.Range(-1.50f, 1.50f));
			if(trab_object[i].GetComponent<Skill_Info>())
			trab_object[i].GetComponent<Skill_Info>().chargingSet(chargingGage);
			trab_object[i].SetActive(true);
		}
		float t = 0.0f;
		while (t < 5.0f)
		{
			t += deltaTime;
			arrow_trab_particle.transform.Rotate(new Vector3(30, 30, 30) * deltaTime, Space.Self);
			yield return null;
		}

	}
	private void SkyArrow(Vector3 targetPoint, float chargingGage)
	{
		Vector3 Arrowforward = transform.forward;
		rigi.velocity = (Vector3.up / .5f + Arrowforward) * 25f * handDis;
		StartCoroutine(SkyArrowCor(targetPoint, 1.0f, chargingGage));
	}
	IEnumerator SkyArrowCor(Vector3 target, float timer,float chargingGage)
	{
		float speed = 22.5f;
		this.transform.localScale = Vector3.one;
		this.transform.rotation = Quaternion.identity;

		yield return new WaitForSeconds(timer);
		SeiKwanArrow.SetActive(false);
		rigi.velocity = Vector3.zero;

		Vector3 dir;
		sky_Arraws[0].transform.position = target + new Vector3(0, 10, 0);
		sky_Arraws[0].transform.LookAt(target);
		if(sky_Arraws[0].GetComponent<Skill_Info>())
		sky_Arraws[0].GetComponent<Skill_Info>().chargingSet(chargingGage);
		sky_Arraws[0].SetActive(true);
		for (int i = 1; i < sky_Arraws.Length; ++i)
		{
			dir = new Vector3(Random.Range(-4, 4), Random.Range(-8, 9), Random.Range(-4, 4));
			sky_Arraws[i].transform.position = target + dir + new Vector3(0, 20, 0);
			sky_Arraws[i].transform.LookAt(target + dir);
			if (sky_Arraws[i].GetComponent<Skill_Info>())
			sky_Arraws[i].GetComponent<Skill_Info>().chargingSet(chargingGage);
			sky_Arraws[i].SetActive(true);
		}
		bool once = false;
		while (this.transform.position.y > -8)
		{
			if (this.transform.position.y < 0 && !once)
			{
				sky_Arraws[0].GetComponentInChildren<Skill_Sound_Set>().check = true;
				once = true;
			}
			this.transform.Translate(Vector3.down * speed * deltaTime);
			yield return null;
		}
		Debug.Log("Sound 땅에 닿음");

		SeiKwanArrow.SetActive(true);
	}
	//#### #### #### #### 
	private void HavensGate(Vector3 targetPoint, float chargingGage)
	{
		SeiKwanArrow.SetActive(false);
		StartCoroutine(HavensGateCor(targetPoint, chargingGage));
	}
	IEnumerator HavensGateCor(Vector3 targetPoint, float chargingGage)
	{
		yield return new WaitForSeconds(1.0f);
		transform.position = targetPoint;
		Gate.GetComponentInChildren<Skill_Sound_Set>().check = true;
		if(Gate.GetComponent<Skill_Info>())
		Gate.GetComponent<Skill_Info>().chargingSet(chargingGage);
		Gate.SetActive(true);
		yield return new WaitForSeconds(3.0f);
		Gate.SetActive(false);
	}
	//#### #### #### #### 
	IEnumerator Shooting(float delTime = 2.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = true;
		Shoot = false;
	}
	public bool IsShoot() { return Shoot; }
	public void resetDelete()
	{
        Shoot = false;
        rigi.velocity = Vector3.zero;
		transform.rotation = bagicRota;
		transform.localScale = Vector3.one;
		SeiKwanArrow.SetActive(true);
		//collider.enabled = true;
		Gate.transform.position = transform.position;
		Gate.transform.localScale = transform.localScale;
		Gate.transform.rotation = transform.rotation;
		Gate.SetActive(false);
		arrow_trab_particle.transform.position = transform.position;
		arrow_trab_particle.transform.localScale = transform.localScale;
		arrow_trab_particle.transform.rotation = transform.rotation;
		arrow_trab_particle.SetActive(false);
		for (int i = 0; i < trab_object.Length; ++i)
		{
			trab_object[i].transform.position = Vector3.zero;
			trab_object[i].SetActive(false);
		}
		for (int i = 0; i < sky_Arraws.Length; ++i)
		{
			sky_Arraws[i].transform.position = transform.position;
			sky_Arraws[i].transform.localScale = transform.localScale;
			sky_Arraws[i].transform.rotation = transform.rotation;
			sky_Arraws[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
			sky_Arraws[i].SetActive(false);

		}
		Gate.SetActive(false);
		del_timer = false;
	}
	private void UseOtherObject()
	{
		SeiKwanArrow.SetActive(false);
		//collider.enabled = false;
	}
}
