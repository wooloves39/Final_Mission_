using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeejaeSkill : MonoBehaviour
{
	public GameObject[] magic;
	public float[] playSkill = { 0.7f, 3.0f, 2.0f, 2.0f, 2.0f };
	public int[] CoolTime = { 8, 80, 10, 20, 120 };
	public int[] UseMp = { 8, 80, 10, 20, 120 };
	public AudioSource audio;
	public AudioClip[] sound;
	private bool[] CoolDown = { false, false, false, false, false };

	private int skill;
	private GameObject target;
	private float handDis;
	float deltaTime;


	private Collider collider;
	private PlayerState Player;

	private AttackMethod handle;
	private LineDraw line;
	public bool handle2 = false;

	private void OnDisable()
	{
		for (int i = 0; i < 5; ++i)
			CoolDown[i] = false;

		Player.LightningBolt = false;
	}

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
		handle = FindObjectOfType<AttackMethod>();
		Player = FindObjectOfType<PlayerState>();
		deltaTime = Time.deltaTime;
		collider = GetComponent<Collider>();
		line = FindObjectOfType<LineDraw>();
	}
	public void SetTarget(GameObject targets)
	{
		target = targets;
	}
	private void Update()
	{
		if (LineDraw.curType == 2 && handle.Beejae_Marker[0].gameObject.activeInHierarchy == false && handle.Beejae_Marker[1].gameObject.activeInHierarchy == false && handle2 == false 
			&& ((line.Skills[2].getCurrentSkill() ==  3) || (line.Skills[2].getCurrentSkill() == 2)))
		{
			bool fail = false;
			bool NoMp = false;
			if (line.Skills[2].getCurrentSkill() == 2)
			{
				if (Player.Mp >= UseMp[1])
				{
					if (!CoolDown[1])
					{
						StartCoroutine("Buff");
						Player.Mp -= UseMp[1];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
			}
			else
			{
				if (Player.Mp >= UseMp[2])
				{
					if (!CoolDown[2])
					{
						StartCoroutine("ThunderShock");
						Player.Mp -= UseMp[2];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
			}
			if (fail)
			{
				Debug.Log("쿨타임 처리");
			}
			if (NoMp)
			{
				Debug.Log("엠피가 부족");
			}
			line.Skills[2].resetSkill();
		}

		if (LineDraw.curType == 2 && handle.Beejae_Marker[0].gameObject.activeInHierarchy == false && handle.Beejae_Marker[1].gameObject.activeInHierarchy == false && handle2 == true)
		{
			handle2 = false;
			shoot(line.Skills[2].getCurrentSkill(), 0.0f);
		}
	}
	
	public void shoot(int skillIndex, float handDistance)
	{
		skill = skillIndex;
		handDis = handDistance;
		bool fail = false;
		bool NoMp = false;
		switch (skill)
		{
			case 0:
			case 1:
				if (Player.Mp >= UseMp[0])
				{
					if (!CoolDown[0])
					{
						StartCoroutine("SkyThunder");
						Player.Mp -= UseMp[0];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
				break;
			case 2:
				if (Player.Mp >= UseMp[1])
				{
					if (!CoolDown[1])
					{
						StartCoroutine("Buff");
						Player.Mp -= UseMp[1];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
				break;
			case 3:
				if (Player.Mp >= UseMp[2])
				{
					if (!CoolDown[2])
					{
						StartCoroutine("ThunderShock");
						Player.Mp -= UseMp[2];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
				break;
			case 4:
				if (Player.Mp >= UseMp[3])
				{
					if (!CoolDown[3])
					{
						StartCoroutine("ThunderBall");
						Player.Mp -= UseMp[3];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
				break;
			case 5:
				if (Player.Mp >= UseMp[4])
				{
					if (!CoolDown[4])
					{
						StartCoroutine("BlackThunder");

						Player.Mp -= UseMp[4];
					}
					else
					{
						fail = true;
					}
				}
				else
				{
					NoMp = true;
				}
				break;
		}
		if (fail)
		{
			Debug.Log("쿨타임 처리");
		}
		if (NoMp)
		{
			Debug.Log("엠피가 부족");
		}
		
	}
	IEnumerator SkyThunder()
	{
		magic[0].transform.position = target.transform.position;
		magic[0].SetActive(true);
		CoolDown[0] = true;
		yield return new WaitForSeconds(0.45f);
		if (Player.LightningBolt)
		{
			target.GetComponent<ObjectLife>().SendMessage("Shock",2.0f);
		}
		target.GetComponent<ObjectLife>().SendMessage("SendDMG", 30.0f);
		yield return new WaitForSeconds(0.30f);
		magic[0].SetActive(false);

		yield return new WaitForSeconds(CoolTime[0]-1);
		CoolDown[0] = false;
	}

	IEnumerator Buff()
	{
		magic[1].SetActive(true);
		CoolDown[1] = true;
		Player.LightningBolt = true;
		yield return new WaitForSeconds(playSkill[1]);
		magic[1].SetActive(false);
		yield return new WaitForSeconds(60.0f - playSkill[1]);
		Player.LightningBolt = false;
		yield return new WaitForSeconds(20.0f - playSkill[1]);
		CoolDown[1] = false;
	}
	IEnumerator ThunderShock()
	{
		magic[2].transform.position = Player.transform.position;
		magic[2].SetActive(true);
		CoolDown[2] = true;
		yield return new WaitForSeconds(playSkill[2]);
		magic[2].SetActive(false);
		yield return new WaitForSeconds(CoolTime[2]- playSkill[2]);
		CoolDown[2] = false;
	}
	IEnumerator ThunderBall()
	{
		magic[3].transform.position = target.transform.position;
		magic[3].SetActive(true);
		CoolDown[3] = true;
		yield return new WaitForSeconds(playSkill[3]);
		magic[3].SetActive(false);
		yield return new WaitForSeconds(CoolTime[3]- playSkill[3]);
		CoolDown[3] = false;
	}
	IEnumerator BlackThunder()
	{
		magic[4].transform.position = target.transform.position;
		magic[4].SetActive(true);
		CoolDown[4] = true;
		target.GetComponent<ObjectLife>().SendMessage("Shock", 4.0f);
		yield return new WaitForSeconds(playSkill[4]);
		target.GetComponent<ObjectLife>().SendMessage("SendDMG", 100.0f);
		magic[4].SetActive(false);
		yield return new WaitForSeconds(CoolTime[4]- playSkill[4]);
		CoolDown[4] = false;
	}
	IEnumerator SkillSound(int num,float delay)
	{
		yield return new WaitForSeconds(delay);
		audio.clip = sound[num];
		audio.volume = Singletone.Instance.Sound;
		audio.Play();
	}
}
