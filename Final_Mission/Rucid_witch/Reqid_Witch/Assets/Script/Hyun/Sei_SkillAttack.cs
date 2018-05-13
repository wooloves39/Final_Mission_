using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sei_SkillAttack : MonoBehaviour
{

	private float damage = 0.0f;
	public float skillBalance;
	private SeiKwanSkill seiKwanSkill;
	public float skill_Del_Time = 0.0f;
	private void OnEnable()
	{
		seiKwanSkill = transform.GetComponentInParent<SeiKwanSkill>();
		damage =  skillBalance;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerState Player = other.GetComponentInParent<PlayerState>();
			if (Player != null)
			{
				Player.DamageHp(damage);
				StartCoroutine(Del_time());
			}
		}
	}
	IEnumerator Del_time()
	{
		yield return new WaitForSeconds(skill_Del_Time);
		seiKwanSkill.Del_timer = true;
	}
}