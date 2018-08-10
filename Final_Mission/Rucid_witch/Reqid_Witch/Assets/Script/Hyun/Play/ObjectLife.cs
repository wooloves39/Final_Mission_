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

	public bool boss;
	public float Attack;
	public float[] SkillDMG = {0,0,0,0};

	public bool MomentInvincible = false;//순간무적
	public float InvincibleTime = 0.2f;//순간무적 시간
	
	public GameObject ElecShock;//구조 바꿔야함
	private Animator ani;
    private bool dot = false;
	private void Start()
	{
		MobSound = GetComponentInChildren<MonsterSoundSetting>();
		agent = GetComponent<NavMeshAgent>();
		ani = GetComponent<Animator>();
	}
	
	private void SendDMG(float dmg)
	{
		if (!MomentInvincible)
		{
			if (boss)
			{

				if (dmg < 50.0)
				{
					if (!ani.GetCurrentAnimatorStateInfo(0).IsName("skill1") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill2") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill3") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill4") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill5"))
						ani.Play("Defence");
				}
				else
				{
					if (!ani.GetCurrentAnimatorStateInfo(0).IsName("skill1") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill2") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill3") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill4") &&
						!ani.GetCurrentAnimatorStateInfo(0).IsName("skill5"))
						ani.Play("Defence2");
				}
			}
			else
			{
				MobSound.PlaySound(1);
			}
			Hp -= dmg;
			StartCoroutine("SetInvincible");
		}
	}
    public void SendDotDMG(float dmg,float time,float cycleTime)
	{
		if (!dot)
        {
            dot = true;
            StartCoroutine(DotDMG( dmg, time, cycleTime));
        }
    }
    IEnumerator DotDMG(float dmg,float time,float cycleTime)
    {
        float T = 0.0f;
		while (T < time)
        {
            if(!this.gameObject.activeInHierarchy)
                break;
			Debug.Log(dmg);
            Hp -= dmg;
            if(!boss)
                MobSound.PlaySound(1);
            T += cycleTime;
            yield return new WaitForSeconds(cycleTime);
        }
        dot = false;
    }
    public void SendAreaDMG(float dmg)
	{
		if (!ani.GetCurrentAnimatorStateInfo(0).IsName("skill1") &&
			!ani.GetCurrentAnimatorStateInfo(0).IsName("skill2") &&
			!ani.GetCurrentAnimatorStateInfo(0).IsName("skill3") &&
			!ani.GetCurrentAnimatorStateInfo(0).IsName("skill4") &&
			!ani.GetCurrentAnimatorStateInfo(0).IsName("skill5"))
			ani.Play("Defence");
		Hp -= dmg;
	
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
			Debug.Log("감전 사운드");
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
