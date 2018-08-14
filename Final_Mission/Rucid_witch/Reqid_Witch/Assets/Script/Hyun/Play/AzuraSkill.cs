using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzuraSkill : MonoBehaviour
{
	private int skill;
	private GameObject target;
	private float handDis;
	private PlayerState player;
	float deltaTime;
	public GameObject Blast;
	public GameObject God;
	public GameObject[] witchsHone;
	public GameObject[] SoulExp;
	public float[] Speed = { 25, 20, 15, 15, 25 };
	private bool Shoot = false;
	private bool del_timer = false;
	private CoolDown CoolTime;
	private Skill_Info info;

	private Collider collider;
    private int[] UseMp = {0,0,0,0,0};
	public GameObject AzuraBall;


	private void Awake()
	{
		info = GetComponent<Skill_Info>();
		player = FindObjectOfType<PlayerState>();

		deltaTime = Time.deltaTime;
		collider = GetComponent<Collider>();
        CoolTime = player.GetComponent<CoolDown>();
        for (int i = 0; i < 5; ++i)
        {
            UseMp[i] = CoolTime.Azu_UseMp[i];
        }
	}

	public void shoot(int skillIndex, GameObject targets, float handDistance, float Gage = 0)
	{
		float chargingGage = Gage + 1;
		deltaTime = Time.deltaTime;
		bool Mp = false;
		bool Cool = false;
		transform.localScale = transform.localScale * 3;
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
        if (handDis <= 0.0f)
        {
            handDis = 0.001f;

        }
    
        if (CoolTime.CheckCool(1, skill))
		{
			Cool = true;
		}
		if (CoolTime.CheckMp(1, skill))
		{
			Mp = true;
		}
		if (!Cool && !Mp)
		{
			if (skill > 1) UseOtherObject();
			switch (skill)
			{
				case 1:
					WitchsHone(chargingGage);
					break;
				case 2:
					SoulExplosion(target.transform.position, chargingGage);
					break;
				case 3:
					witchAging(4f, chargingGage);
					break;
				case 4:
					callofGad(target.transform.position, 15.0f, 3f, chargingGage);
					//gameObject Soul, Vector3 targetPos, float speed, float scale, float time)
					break;
				case 5:
					LastBlast(target.transform.position, chargingGage);
					break;
			}
			CoolTime.MpDown(1, skill);
			Shoot = true;
			StartCoroutine(Shooting());
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
	private void WitchsHone(float chargingGage)
	{
		Rigidbody r = GetComponent<Rigidbody>();
		if(GetComponent<Skill_Info>())
		GetComponent<Skill_Info>().chargingSet(chargingGage);
		Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);//;
        if (TargettingDir == Vector3.zero) TargettingDir = Vector3.forward;
        r.velocity = TargettingDir * Speed[0] * handDis;

	}
	//########################################################
	void SoulExplosion(Vector3 target, float chargingGage)//12개의 스킬 날리기
	{
		for (int i = 0; i < SoulExp.Length; ++i)
		{
			if(SoulExp[i].GetComponent<Skill_Info>())
			SoulExp[i].GetComponent<Skill_Info>().chargingSet(chargingGage);
			SoulExp[i].transform.position = player.transform.position;
			SoulExp[i].SetActive(true);
			SoulExp[i].transform.localScale = new Vector3(2, 2, 2);
			StartCoroutine(SoulExplosionCor(SoulExp[i], target));
		}
	}
	IEnumerator SoulExplosionCor(GameObject soul, Vector3 target)
	{
		Vector3 dir = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
		float speed = Random.Range(5, 10);
		float Timer = 0.0f;
		float MaxTime = Vector3.Distance(soul.transform.position, target) / Speed[1] * 2.5f;
        if (MaxTime < 1.0f)
        {
            MaxTime = 1.5f;
        }
        while (true)
		{
			Timer += deltaTime;
			if (Vector3.Distance(soul.transform.position, target) < 0.1f)
			{
				break;
			}
			if (Timer > 0.5f)
			{
				speed = Speed[1];
				soul.transform.LookAt(target);
				soul.transform.Translate(Vector3.forward * deltaTime * speed);
			}
			else
			{
				speed = Speed[1] / 2;
				soul.transform.LookAt(this.transform.position + dir);
				soul.transform.Translate(Vector3.forward * deltaTime * speed);
			}
			if (Timer >= MaxTime)
			{
				//테스트
				StopCoroutine(Shooting());
				del_timer = true;
				Shoot = false;
				break;
			}
			else
				yield return null;
		}
	}
	//########################################################
	void witchAging(float deltime, float chargingGage)//12개
	{
		for (int i = 0; i < witchsHone.Length; ++i)
		{
			if(witchsHone[i].GetComponent<Skill_Info>())
			witchsHone[i].GetComponent<Skill_Info>().chargingSet(chargingGage);
			witchsHone[i].transform.position = player.transform.position;
			witchsHone[i].transform.Rotate(0, i * 30, 0);
			witchsHone[i].SetActive(true);
			StartCoroutine(witchAgingCour(witchsHone[i], deltime));
		}
	}
	IEnumerator witchAgingCour(GameObject hone, float Limit)
	{
		float timer = 0.0f;
		while (true)//필요없을수도
		{
			hone.transform.Translate(Vector3.forward * Speed[2] * handDis * deltaTime);
			hone.transform.Rotate(0, 1.5f, 0);

			if (timer > Limit)
				break;
			timer += deltaTime;
			yield return new WaitForSeconds(deltaTime);
		}
		hone.SetActive(false);
	}
	//########################################################

	//callofGad(target.transform.position,10f, 10f, 5f);
	void callofGad(Vector3 targetPos, float scale, float time, float chargingGage)
	{
		info.PowerMemory[0] = 0.0f;
		if(God.GetComponent<Skill_Info>())
		God.GetComponent<Skill_Info>().chargingSet(chargingGage);
		God.SetActive(true);
		God.transform.LookAt(targetPos);
		StartCoroutine(callofGadCor(God, targetPos, scale, time));
		//gameObject Soul, Vector3 targetPos, float speed, float scale, float time)
	}
	IEnumerator callofGadCor(GameObject Soul, Vector3 targetPos, float scale, float time)
	{
		float timer = 0.0f;
		float cur_Scale = 1.0f;
		float limit = 1.0f;
		while (true)
		{
			timer += deltaTime;
			Vector3 scaleVector = Vector3.one;
			if (timer < 0.5f)
			{
				Soul.transform.Translate(Vector3.forward * 0.05f * Speed[3]);

				cur_Scale = 1.1f;
			}
			else
				cur_Scale = 1.05f;

			limit *= cur_Scale;
			if (limit < scale)
			{
				Soul.transform.localScale = Soul.transform.localScale * cur_Scale;
				Soul.transform.position = targetPos;

			}
			else
			{
				God.SetActive(false);
				break;
			}

			if (timer > time)
			{
				God.SetActive(false);
				break;
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
	//########################################################  
	private void LastBlast(Vector3 target, float chargingGage)
	{
		info.PowerMemory[0] = 0.0f;
		Blast.transform.localScale = Vector3.one * 2;
		if(Blast.GetComponent<Skill_Info>())
		Blast.GetComponent<Skill_Info>().chargingSet(chargingGage);
		Blast.SetActive(true);
		Blast.transform.position = target;
		StartCoroutine(LastBlastCor(Blast, 3.0f));
	}
	IEnumerator LastBlastCor(GameObject Blast, float Timer)
	{
		float timer = 0.0f;
		while (true)
		{
			timer += deltaTime;
			Blast.transform.Rotate(0, 5 * timer, 0);
			if (timer >= Timer)
			{
				timer = 0;
				Blast.transform.localScale = Vector3.one * 2 * (1 - timer / Timer);
				Blast.transform.rotation = Quaternion.identity;
				Blast.gameObject.SetActive(false);
				break;
				//내위치 변경
			}
			yield return null;
		}
	}
	IEnumerator Shooting(float delTime = 5.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = true;
		Shoot = false;
	}
	public bool IsDelete() { return del_timer; }
	public bool IsShoot() { return Shoot; }
	public void resetDelete()
	{
		info.PowerMemory[0] = 50.0f;
		AzuraBall.SetActive(true);
		collider.enabled = true;
		God.SetActive(false);
		God.transform.localScale = Vector3.one;
		God.transform.position = transform.position;
		Blast.transform.position = transform.position;
		Blast.transform.localScale = transform.localScale;
		Blast.transform.rotation = transform.rotation;
		Blast.SetActive(false);
		for (int i = 0; i < witchsHone.Length; ++i)
		{
			witchsHone[i].transform.position = transform.position;
			witchsHone[i].transform.localScale = transform.localScale;
			witchsHone[i].transform.rotation = transform.rotation;
			witchsHone[i].SetActive(false);
		}
		for (int i = 0; i < SoulExp.Length; ++i)
		{
			SoulExp[i].transform.position = transform.position;
			SoulExp[i].transform.localScale = transform.localScale;
			SoulExp[i].transform.rotation = transform.rotation;
			SoulExp[i].SetActive(false);
		}
		del_timer = false;
	}
	private void UseOtherObject()
	{
		AzuraBall.SetActive(false);
		collider.enabled = false;
	}
}
