using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellSkill : MonoBehaviour {


	// Use this for initialization
	private int skill;
	private GameObject target;
	private float handDis;
	public float HandeDis { get { return handDis; } set { handDis = value; } }
	float deltaTime;
	private bool Shoot = false;
	private bool del_timer = false;
	public bool Del_timer { get { return del_timer; } set { del_timer = value; } }



	//private Collider collider;
	private CoolDown CoolTime;
	private Vector3 curScale;
	private Rigidbody rigi;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
		CoolTime = FindObjectOfType<CoolDown>();
		rigi = GetComponent<Rigidbody>();
	}
	public void shoot(int chargingCount, GameObject targets)
	{
		bool Mp = false;
		bool Cool = false;
		float del_time = chargingCount * 2;
		transform.localScale = transform.localScale * 3;
		target = targets;
		if (CoolTime.CheckCool(4, skill))
		{
			Cool = true;
		}
		if (CoolTime.CheckMp(4, skill))
		{
			Mp = true;
		}
		if (!Cool && !Mp)
		{
			CoolTime.SetCool(2, skill);
			Rigidbody r = GetComponent<Rigidbody>();
			Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
			r.velocity = TargettingDir *20.0f;//벨런스 조절 필요
			Shoot = true;
			StartCoroutine(Shooting(del_time));
		}
		else
		{
			if (Mp)
				Debug.Log("Mp부족 처리 부분");
			if (Cool)
				Debug.Log("쿨타임 중 처리 부분");
		}
		target = null;
	}
	
	IEnumerator Shooting(float delTime = 2.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = true;
		Shoot = false;
	}
	public bool IsDelete() { return del_timer; }
	public bool IsShoot() { return Shoot; }
	public void resetDelete()
	{
		del_timer = false;
	}
}
