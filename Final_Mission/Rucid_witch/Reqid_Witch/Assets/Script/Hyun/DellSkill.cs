using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellSkill : MonoBehaviour
{
	// Use this for initialization
	private int skill;
	private GameObject target;
	float deltaTime;
	private bool Shoot = false;
	private bool del_timer = false;
	public bool Del_timer { get { return del_timer; } set { del_timer = value; } }

	//private Collider collider;
	private Vector3 curScale;
	private Rigidbody rigi;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
		rigi = GetComponent<Rigidbody>();
	}
	public void shoot(int chargingCount, GameObject targets)
	{
		float del_time = chargingCount * 2;
		transform.localScale = transform.localScale * 3;
		target = targets;
		Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		rigi.velocity = TargettingDir * 20.0f;//벨런스 조절 필요
		Shoot = true;
		StartCoroutine(Shooting(del_time));
		target = null;
	}
	public void shoot(float chargingCount, GameObject targets,bool isMon=false)
	{
		float del_time = chargingCount * 2;
		transform.localScale = transform.localScale * 3;
		target = targets;
		
		Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		rigi.velocity = TargettingDir * 20.0f;//벨런스 조절 필요
		Shoot = true;
		StartCoroutine(Shooter(del_time));
		target = null;
	}
	IEnumerator Shooting(float delTime = 2.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = true;
		Shoot = false;
	}
	IEnumerator Shooter(float delTime = 2.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = false;
		Shoot = false;
		gameObject.SetActive(false);
		rigi.velocity = Vector3.zero;
	}
	public bool IsDelete() { return del_timer; }
	public bool IsShoot() { return Shoot; }
	public void resetDelete()
	{
		del_timer = false;
	}
}
