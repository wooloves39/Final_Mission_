using System.Collections;
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

	private bool Shoot = false;
	private bool del_timer = false;
	public bool Del_timer { get { return del_timer; } set { del_timer = value; } }
	//private Collider collider;
	public GameObject SeiKwanArrow;


	private Vector3 curScale;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
		//collider = GetComponent<Collider>();
	}
	public void shoot(int skillIndex, GameObject targets, float handDistance, float del_time = 10.0f)
	{
		transform.localScale = transform.localScale * 3;
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
		switch (skill)
		{
			case 1:
				BraveArrow();
				break;
			case 2:
				ArrowTrab();
				break;
			case 3:
				SkyArrow(targets.transform.position);
				break;
			case 5:
				HavensGate(targets.transform.position);
				break;
		}
		if (skill == 5) del_time += 20f;
		//if (skill > 1) UseOtherObject();
		Shoot = true;
		StartCoroutine(Shooting(del_time));
		target = null;
	}
	private void BraveArrow()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.zero;
		if (target)
		{
			TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		}
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			r.velocity = Arrowforward * 15f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			r.velocity = TargettingDir * 15f * handDis;
		}
	}
	private void ArrowTrab()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.zero;
		if (target)
		{
			TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		}
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			r.velocity = Arrowforward * 15f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			r.velocity = TargettingDir * 15f * handDis;
		}
		Debug.Log(handDis);
		StartCoroutine(ArrowTrabCor(.5f));
	}
	IEnumerator ArrowTrabCor(float timer)
	{
		yield return new WaitForSeconds(timer);
		arrow_trab_particle.SetActive(true);
		arrow_trab_particle.transform.LookAt(SeiKwanArrow.transform);
	}
	private void SkyArrow(Vector3 targetPoint)
	{
		Vector3 Arrowforward = transform.forward;
		Rigidbody r = GetComponent<Rigidbody>();
		r.velocity = (Vector3.up / .5f + Arrowforward) * 15f * handDis;
		for (int i = 0; i < sky_Arraws.Length; ++i)
		{
			StartCoroutine(SkyArrowCor(sky_Arraws[i], targetPoint, 2.0f));
		}
	}
	IEnumerator SkyArrowCor(GameObject skyArrow, Vector3 target, float timer)
	{
		Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
		float speed = Random.Range(5, 10);
		yield return new WaitForSeconds(timer);
		skyArrow.SetActive(true);
		skyArrow.transform.position = transform.position + dir;
		Rigidbody r = skyArrow.GetComponent<Rigidbody>();
		Vector3 TargettingDir = Vector3.Normalize(target - skyArrow.transform.position);
		skyArrow.transform.LookAt(target);
		r.velocity = TargettingDir * 30f * handDis;
	}
	private void HavensGate(Vector3 targetPoint)
	{
		SeiKwanArrow.SetActive(false);
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.Normalize(targetPoint - transform.position);
		r.velocity = TargettingDir * 15f * handDis;
		StartCoroutine(HavensGateCor(targetPoint));
	}
	IEnumerator HavensGateCor(Vector3 targetPoint)
	{
		while (true)
		{
			if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
				break;
			yield return null;
		}
		Rigidbody r = GetComponent<Rigidbody>();
		r.velocity = Vector3.zero;
		transform.LookAt(Vector3.up);
		Gate.SetActive(true);
	}
	IEnumerator Shooting(float delTime = 2.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = true;
		Shoot = false;
	}
	public bool IsShoot() { return Shoot; }
	public void resetDelete()
	{
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
		for (int i = 0; i < sky_Arraws.Length; ++i)
		{
			sky_Arraws[i].transform.position = transform.position;
			sky_Arraws[i].transform.localScale = transform.localScale;
			sky_Arraws[i].transform.rotation = transform.rotation;
			sky_Arraws[i].SetActive(false);
		}
		del_timer = false;
	}
	private void UseOtherObject()
	{
		SeiKwanArrow.SetActive(false);
		//collider.enabled = false;
	}
}
