using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectLife : MonoBehaviour {


	private NavMeshAgent agent;
	public float Hp;
	public float MaxHp;
	public float Speed;
	public float BattleSpeed;
	public float Range;
	MonsterSoundSetting MobSound;

	public float Attack;
	public float[] SkillDMG = {0,0,0,0};

	public bool MomentInvincible = false;//순간무적
	public float InvincibleTime = 0.2f;//순간무적 시간
	
	public GameObject ElecShock;//구조 바꿔야함
	private Animator ani;

	private void Start()
	{
		MobSound = GetComponentInChildren<MonsterSoundSetting>();
		agent = GetComponent<NavMeshAgent>();
	}
	
	private void SendDMG(float dmg)
	{
		if (!MomentInvincible)
		{
			Hp -= dmg;
			MobSound.PlaySound(1);
			StartCoroutine("SetInvincible");
		}
	}
	private void SendAreaDMG(float dmg)
	{
		Hp -= dmg;
		MobSound.PlaySound(1);
	}
	IEnumerator SetInvincible()
	{
		MomentInvincible = true;
		yield return new WaitForSeconds(InvincibleTime);
		MomentInvincible = false;
	}
	void Shock(float t)
	{
		StartCoroutine("ShockSound",t);
	}
	IEnumerator ShockSound(float t)
	{
		float time = 0;
		float Cycle1 = 0.15f;
		float Cycle2 = 0.10f;
		float[] temp = { Speed, BattleSpeed };
		Vector3 playerpos;
		Speed = 0.1f;
		BattleSpeed = 0.1f;
		agent.speed = Speed;
		playerpos = agent.destination;
		agent.destination = this.transform.position;
		while (time < t)
		{
			yield return new WaitForSeconds(Cycle1);

			ElecShock.SetActive(true);
			MobSound.PlaySound(4);
			yield return new WaitForSeconds(Cycle2);
			time += (Cycle1 + Cycle2);
			ElecShock.SetActive(false);
		}
		agent.destination =playerpos;
		Speed = temp[0];
		BattleSpeed = temp[1];
	}
}
