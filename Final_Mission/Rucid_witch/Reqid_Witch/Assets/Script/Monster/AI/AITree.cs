﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AITree {
	public Dictionary <int,string> AIDic = new Dictionary<int,string> ();

	private static AITree instance = null;
	public static AITree Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new AITree();
			}
			return instance;
		}
	}

	public string SearchAI(int n)
	{
		string temp;
		AIDic.TryGetValue(n,out temp);
		return temp;
	}
	AITree()
	{
		//평화상태
		int Dnum = 0;
		AIDic.Add(Dnum, "Stop");
		Dnum = 1;
		AIDic.Add(Dnum,"NatureMove");
		Dnum = 2;
		AIDic.Add(Dnum,"StopMotion");
		Dnum = 3;
		AIDic.Add(Dnum,"MoveWay");//사용자가 지정한 길을 따라 이동

		//전투상태
		Dnum = 10;
		AIDic.Add(Dnum,"TagetSearch");
		Dnum = 11;
		AIDic.Add(Dnum,"Move");//추격
		Dnum = 12;
		AIDic.Add(Dnum,"NomalAttack");

		//기본 공격스킬
		Dnum = 20;
		AIDic.Add(Dnum ,  "NomalSkill_1");
		Dnum = 21;
		AIDic.Add(Dnum ,  "NomalSkill_2");
		Dnum = 22;
		AIDic.Add(Dnum ,  "NomalSkill_3");
		Dnum = 23;
		AIDic.Add(Dnum ,  "NomalSkill_4");
		Dnum = 24;
		AIDic.Add(Dnum ,  "NomalSkill_5");

		//조건 부 스킬(상황에 맞는)
		Dnum = 30;
		AIDic.Add(Dnum ,  "SpecialSkill_1");
		Dnum = 31;
		AIDic.Add(Dnum ,  "SpecialSkill_2");
		Dnum = 32;
		AIDic.Add(Dnum ,  "SpecialSkill_3");

		//상태이상 치료
		Dnum = 40;
		AIDic.Add(Dnum ,  "Cure_All");
		Dnum = 41;
		AIDic.Add(Dnum ,  "Cure_Freezing");
		Dnum = 42;
		AIDic.Add(Dnum ,  "Cure_Burning");
		Dnum = 43;
		AIDic.Add(Dnum ,  "Cure_Blooding");
		Dnum = 44;
		AIDic.Add(Dnum ,  "Cure_Darkness");
		Dnum = 45;
		AIDic.Add(Dnum ,  "Cure_ElecShocking");

		//버프
		Dnum = 50;
		AIDic.Add(Dnum ,  "Buff_Heal");
		Dnum = 51;
		AIDic.Add(Dnum ,  "Buff_Attack");
		Dnum = 52;
		AIDic.Add(Dnum ,  "Buff_Ammor");
		Dnum = 53;
		AIDic.Add(Dnum ,  "Buff_Shiled");
	}
}

