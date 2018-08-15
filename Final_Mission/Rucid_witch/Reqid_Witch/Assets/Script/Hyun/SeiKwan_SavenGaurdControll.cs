using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwan_SavenGaurdControll : MonoBehaviour {
	public GameObject SeiKwan_Saven;
	private LinePointChecker pointChecker;
	private CoolDown CoolTime;
	// Use this for initialization
	void Start () {
		pointChecker = GetComponent<LinePointChecker>();
		CoolTime = FindObjectOfType<CoolDown>();
	}

	// Update is called once per frame
	void Update()
	{
		if (pointChecker.getCurrentSkill() == 4)
		{
			bool Mp = false;
			bool Cool = false;
			if (CoolTime.CheckCool(2, pointChecker.getCurrentSkill()))
			{
				Cool = true;
			}
			if (CoolTime.CheckMp(2, pointChecker.getCurrentSkill()))
			{
				Mp = true;
			}
			if (!Cool && !Mp)
			{
				CoolTime.SetCool(2, 4);
				CoolTime.MpDown(2, 4);
				SeiKwan_Saven.SetActive(true);
			}
			pointChecker.resetSkill();
		}
	}
}
