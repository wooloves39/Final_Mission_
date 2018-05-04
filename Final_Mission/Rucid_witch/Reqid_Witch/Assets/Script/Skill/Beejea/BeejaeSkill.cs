using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeejaeSkill : MonoBehaviour
{
	public GameObject[] magic;
	public int[] CoolTime = {8,80,10,20,120};
	public AudioSource audio;
	public AudioClip[] sound;
	private bool[] CoolDown = {false,false,false,false,false};

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
		line = GetComponent<LineDraw>();
		audio = GetComponent<AudioSource>();
		handle = FindObjectOfType<AttackMethod>();
		handle2 = FindObjectOfType<Beejea_Verbase_Setting>();
		Player = FindObjectOfType<PlayerState>();
		deltaTime = Time.deltaTime;
		collider = GetComponent<Collider>();
	}
	private void Update()
	{
		if(LineDraw.curType == 2 &&handle.Beejae_Marker[0].gameObject.activeInHierarchy == false && handle.Beejae_Marker[1].gameObject.activeInHierarchy == false && handle2 == true)
		{
			handle2 = false;
			shoot(line.Skills[2].getCurrentSkill(), handle.PlayerTarget.getMytarget(), 0.0f);
		}
	}

	public void shoot(int skillIndex, GameObject targets, float handDistance)
	{
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
		bool fail = false;
		bool NoMp = false;
		switch (skill)
		{
			case 0:
			case 1:
				if (Player.Mp >= 20)
				{
					if (!CoolDown[0])
					{
						StartCoroutine("SkyThunder");
						Player.Mp -= 20;
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
				if (Player.Mp >= 40)
				{
					if (!CoolDown[1])
					{
						StartCoroutine("Buff");
						Player.Mp -= 40;
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
				if (Player.Mp >= 25)
				{
					if (!CoolDown[2])
					{
						StartCoroutine("ThunderShock");
						Player.Mp -= 25;
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
				if (Player.Mp >= 40)
				{
					if (!CoolDown[3])
					{
						StartCoroutine("ThunderBall");
						Player.Mp -= 40;
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
				if (Player.Mp >= 110)
				{
					if (!CoolDown[4])
					{
						StartCoroutine("BlackThunder");

						Player.Mp -= 110;
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

		if (skill > 1)
			UseOtherObject();
		target = null;
	}
	IEnumerator SkyThunder()
	{
		magic[0].transform.position = target.transform.position;
		magic[0].SetActive(true);
		CoolDown[0] = true;
		yield return new WaitForSeconds(0.45f);
		if (Player.LightningBolt)
		{
			handle.PlayerTarget.getMytarget().SendMessage("Shock");
		}
		handle.PlayerTarget.getMytarget().GetComponentInParent<ObjectLife>().SendMessage("SendDMG", 30.0f);
		yield return new WaitForSeconds(0.30f);
		magic[0].SetActive(false);

		yield return new WaitForSeconds(CoolTime[0]-1);
		CoolDown[0] = true;
	}

	IEnumerator Buff()
	{
		CoolDown[1] = true;
		Player.LightningBolt = true;
		yield return new WaitForSeconds(60.0f);
		Player.LightningBolt = false;
		yield return new WaitForSeconds(20.0f);
		CoolDown[1] = false;
	}
	IEnumerator ThunderShock()
	{
		magic[2].transform.position = target.transform.position;
		magic[2].SetActive(true);
		CoolDown[2] = true;
		yield return new WaitForSeconds(CoolTime[2]);
		CoolDown[2] = false;
	}
	IEnumerator ThunderBall()
	{
		magic[3].transform.position = target.transform.position;
		magic[3].SetActive(true);
		CoolDown[3] = true;
		yield return new WaitForSeconds(CoolTime[3]);
		CoolDown[3] = false;
	}
	IEnumerator BlackThunder()
	{
		magic[4].transform.position = target.transform.position;
		magic[4].SetActive(true);
		CoolDown[4] = true;
		yield return new WaitForSeconds(CoolTime[3]);
		CoolDown[4] = false;
	}
	private void UseOtherObject()
	{
		collider.enabled = false;
	}
	IEnumerator SkillSound(int num,float delay)
	{
		yield return new WaitForSeconds(delay);
		audio.clip = sound[num];
		audio.volume = Singletone.Instance.Sound;
		audio.Play();
	}
}
