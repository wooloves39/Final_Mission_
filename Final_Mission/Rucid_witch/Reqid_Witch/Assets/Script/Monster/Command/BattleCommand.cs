using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleCommand : MonoBehaviour {

	float TimeLimit;
	float time = 0.0f;
	int skill_index = 0;
	public float MAttdelay = 0.0f;
	public float AttackFrame = 0.4f;
	public float[] SkillFrame;
	private NavMeshAgent agent;
	private PlayerState Player;
	private ObjectLife MobInfo;
	private Animator ani;
	MonsterSoundSetting MobSound;

	public GameObject MobObj;
	public GameObject[] skill;
	private float DMG;


	void Start()
	{
		MobSound = GetComponentInChildren<MonsterSoundSetting>();
		GameObject temp = FindObjectOfType<PlayerState>().gameObject;
		Player = temp.GetComponent<PlayerState>();
		MobInfo = GetComponentInChildren<ObjectLife>();
		ani = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}
	public void BattleMove(MoveMsg msg)
	{
		agent.destination = msg.destination;
		agent.speed = msg.Speed;
		TimeLimit = msg.time;
		time = 0.0f;

		StartCoroutine("BMove");
	}
	public void Attack(float T, bool b)
	{
		DMG = MobInfo.Attack;
		agent.speed = 0;
		TimeLimit = T;
		time = 0.0f;
		MobSound.PlaySound(2);
		if(b)
			StartCoroutine("RangeAtt");
		else
			StartCoroutine("MeleeAtt");
	}
	public void Skill(float T,int n)
	{
		agent.speed = 0;
		TimeLimit = T;
		time = 0.0f;
		skill_index = n;
		DMG = MobInfo.SkillDMG[skill_index];
		StartCoroutine("SkillCoroutine");
	}





	IEnumerator SkillCoroutine()
	{
		float temp = Time.deltaTime;
		while (true)
		{
			switch (skill_index)
			{
				case 1:
					if (time >= SkillFrame[0])
						ani.SetBool("Skill1", false);
					break;
				case 2:
					if (time >= SkillFrame[1])
						ani.SetBool("Skill2", false);
					break;
				case 3:
					if (time >= SkillFrame[2])
						ani.SetBool("Skill3", false);
					break;
				case 4:
					if (time >= SkillFrame[3])
						ani.SetBool("Skill4", false);
					break;
					
			}
			if (time >= TimeLimit)
			{
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);

		}
	}
		
	IEnumerator MeleeAtt()
	{
		yield return new WaitForSeconds(MAttdelay);
		float temp = Time.deltaTime;
		bool once = false;
		while (true)
		{
			if (time >= AttackFrame && !once)
			{
				once = true;
				Player.DamageHp(DMG);
				ani.SetBool("IsAttack", false);
			}
			if (time >= TimeLimit)
			{
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
	IEnumerator RangeAtt()
	{
		this.transform.LookAt(Player.transform.position);
		float temp = Time.deltaTime;

		RangedAttack Ranged = MobObj.GetComponent<RangedAttack>();
		Ranged.damage = DMG;
		Ranged.PlayerPos = Player.transform.position;
		MobObj.SetActive(true);

		while (true)
		{
			if(time >= AttackFrame)
				ani.SetBool("IsAttack", false);
			if (time >= TimeLimit)
			{
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
	IEnumerator BMove()
	{
		while (true)
		{
			float temp = Time.deltaTime;
			if (time >= TimeLimit)
			{
				agent.speed = 0.0f;
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}

}
