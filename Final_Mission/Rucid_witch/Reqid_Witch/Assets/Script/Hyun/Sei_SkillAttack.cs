using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sei_SkillAttack : MonoBehaviour
{

	private float damage = 0.0f;
	public float skillBalance;
	private void OnEnable()
	{
		damage = transform.parent.GetComponent<SeiKwanSkill>().HandeDis * skillBalance;
		Debug.Log(damage);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerState Player = other.GetComponentInParent<PlayerState>();
			if (Player != null)
			{
				Player.DamageHp(damage);
				this.gameObject.SetActive(false);
			}
		}
	}
}