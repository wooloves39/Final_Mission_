using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingMarkSet : MonoBehaviour
{
	private ChargingMark[] chargingMarks;
	public int myType;
	private CoolDown coolDown;
	private CoolTimeSaver coolTimeSaver;
	// Use this for initialization
	void Awake()
	{
		//셋팅
		coolTimeSaver = GetComponentInParent<CoolTimeSaver>();
		chargingMarks = GetComponentsInChildren<ChargingMark>();
		coolDown = GetComponentInParent<CoolDown>();
		switch (myType)
		{
			case 1:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].setSkillData(coolDown.Azu_UseMp[i], coolDown.Azu_CoolTime[i]);
				}
				break;
			case 2:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].setSkillData(coolDown.Sei_UseMp[i], coolDown.Sei_CoolTime[i]);
				}
				break;
			case 3:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].setSkillData(coolDown.Bee_UseMp[i], coolDown.Bee_CoolTime[i]);
				}
				break;
			case 4:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].setSkillData(coolDown.Ver_UseMp[i], coolDown.Ver_CoolTime[i]);
				}
				break;
			case 5:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].setSkillData(coolDown.Dell_UseMp[i], coolDown.Dell_CoolTime[i]);
				}
				break;
		}
		gameObject.SetActive(false);
	}
	private void OnEnable()
	{
		switch (myType)
		{
			case 1:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].CheckCoolTime (coolTimeSaver.Azu_Timer[i]);
				}
				break;
			case 2:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].CheckCoolTime(coolTimeSaver.Sei_Timer[i]);
				}
				break;
			case 3:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].CheckCoolTime( coolTimeSaver.Bee_Timer[i]);
				}
				break;
			case 4:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].CheckCoolTime( coolTimeSaver.Ver_Timer[i]);
				}
				break;
			case 5:
				for (int i = 0; i < chargingMarks.Length; ++i)
				{
					chargingMarks[i].CheckCoolTime( coolTimeSaver.Dell_Timer[i]);
				}
				break;
		}
	}
	private void OnDisable()
	{
		for(int i=0;i< chargingMarks.Length; ++i)
		{
			chargingMarks[i].gameObject.SetActive(true);
		}
	}
	public void setOff(int index)
	{
		chargingMarks[index].gameObject.SetActive(false);
	}
}
