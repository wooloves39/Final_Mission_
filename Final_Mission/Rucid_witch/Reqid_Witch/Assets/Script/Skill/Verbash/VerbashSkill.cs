﻿using System.Collections;
using UnityEngine;

public class VerbashSkill : MonoBehaviour
{
	public GameObject[] magic;
	public float[] playSkill = { 0.7f, 3.0f, 2.0f, 2.0f, 2.0f };
	public float[] CoolTime = { 8, 80, 10, 20, 120 };
	public float[] UseMp = { 8, 80, 10, 20, 120 };
	public bool left = false;

	private bool[] CoolDown = { false, false, false, false, false };

    private VerbashSkill4[] V4 = {null,null};
	private int skill;
	private GameObject target;

	private PlayerState Player;
	private LineDraw line;
	private bool SHOOT = false;
	public Transform handle;
	private float hight;
	private Targetting Target;
    private CoolDown cooldown;
	private void OnEnable()
	{
		hight = Target.transform.position.y;
	}
	private void OnDisable()
	{
		SHOOT = false;
		for (int i = 0; i < 5; ++i)
			CoolDown[i] = false;

		Player.LightningBolt = false;
	}

	private void Awake()
	{
        V4 = magic[3].GetComponentsInChildren<VerbashSkill4>();
		Player = FindObjectOfType<PlayerState>();
		Target = Player.GetComponentInChildren<Targetting>();
		line = FindObjectOfType<LineDraw>();
        target = this.gameObject;
        cooldown =  Player.GetComponent<CoolDown>();

	}
	public void Update()
	{
        for (int i = 0; i < 5; ++i)
        {
            cooldown.Ver_Cool[i] =  CoolDown[i];
        }
        if (LineDraw.curType == 3 && InputManager_JHW.RTriggerOn() && InputManager_JHW.LTriggerOn())
        {
            if (left)
            {
                if ( Player.GetMyState() != PlayerState.State.Drawing)
                {
                    if (handle.transform.position.y > hight + 0.1f)
                    {
                        shoot(line.Skills[3].getCurrentSkill());
                    }
                }
               //else
               //{
               //    if (handle.transform.position.y < hight - 0.1f)
               //        if (CoolDown[line.Skills[3].getCurrentSkill()] == false)
               //}
            }
            else
            {
                if ( Player.GetMyState() != PlayerState.State.Drawing)
                {
                    if (handle.transform.position.y > hight + 0.1f)
                    {
                        shoot(line.Skills[3].getCurrentSkill());
                    }
                }
               // else
               // {
               //     if (handle.transform.position.y < hight - 0.1f)
               //         if (CoolDown[line.Skills[3].getCurrentSkill()] == false)
               // }
            }
        }
		
		
	}
	public void shoot(int skillIndex)
	{
		if (Target.getMytarget() != null)
		{
			target = Target.getMytarget();
			skill = skillIndex;
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
							StartCoroutine("Skill1");
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
							StartCoroutine("Skill2");
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
							StartCoroutine("Skill3");
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
							StartCoroutine("Skill4");
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
							StartCoroutine("Skill5");
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

	}
	IEnumerator Skill1()
	{
		magic[0].transform.position = target.transform.position;

		magic[0].SetActive(true);
		CoolDown[0] = true;
		yield return new WaitForSeconds(1.5f);

		magic[0].SetActive(false);
		yield return new WaitForSeconds(CoolTime[0]-1.5f);
		CoolDown[0] = false;

	}
    IEnumerator Skill2()
    {
        magic[1].transform.position = target.transform.position;

        magic[1].SetActive(true);
        CoolDown[1] = true;
        yield return new WaitForSeconds(2.0f);

        magic[1].SetActive(false);
        yield return new WaitForSeconds(CoolTime[2]-2.0f);
        CoolDown[1] = false;

    }
    IEnumerator Skill3()
    {
        magic[2].transform.position = target.transform.position;

        magic[2].SetActive(true);
        CoolDown[2] = true;
        yield return new WaitForSeconds(1.5f);

        magic[2].SetActive(false);
        yield return new WaitForSeconds(CoolTime[2]-1.5f);
        CoolDown[2] = false;

    }
    IEnumerator Skill4()
    {
		magic[3].transform.position = Player.gameObject.transform.position;
        magic[3].SetActive(true);
        CoolDown[3] = true;

        yield return new WaitForSeconds(0.2f);
        V4[0].shoot(target);
        yield return new WaitForSeconds(0.1f);
        V4[1].shoot(target);
        yield return new WaitForSeconds(7.7f);

        magic[3].SetActive(false);
        V4[0].reset();
        V4[1].reset();
        yield return new WaitForSeconds(CoolTime[3]-8.0f);
        CoolDown[3] = false;
    }
    IEnumerator Skill5()
    {
        magic[4].transform.position = target.transform.position;
		magic[4].SetActive(true);
        CoolDown[4] = true;

        yield return new WaitForSeconds(4.0f);

        magic[4].SetActive(false);
        yield return new WaitForSeconds(CoolTime[4]-4.0f);
        CoolDown[4] = false;
    }
}
