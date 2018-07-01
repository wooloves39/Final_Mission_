using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dell_Buffs : MonoBehaviour {
	public GameObject[] buffs;//0번 퀵스텝 1번 왈츠 2번 하모니 어게인
							  //퀵스텝 -40초간 이동속도 1.5 증가
							  // 왈츠 -HP,MP회복속도 증가
							  // 하모니어게인 즉시 50회복 나머지 버프 시간 초기화, 능력치 1.5배 
							  // Use this for initialization
	private LinePointChecker pointChecker;
	private CoolDown CoolTime;
	void Start() {
		pointChecker = GetComponent<LinePointChecker>();
		CoolTime = FindObjectOfType<CoolDown>();
	}

	// Update is called once per frame
	void Update() {
		bool Mp = false;
		bool Cool = false;
		switch (pointChecker.getCurrentSkill())
		{
			case 2:
				{
					
						CoolTime.SetCool(5, 2);
						CoolTime.MpDown(5, 2);
						buffs[0].SetActive(true);
					pointChecker.resetSkill();
				}
				break;
			case 3:
				{
					
						CoolTime.SetCool(5, 3);
						CoolTime.MpDown(5, 3);
						buffs[1].SetActive(true);
					pointChecker.resetSkill();
				}
				break;
			case 5:
				{
					
						CoolTime.SetCool(5, 5);
						CoolTime.MpDown(5, 5);
						buffs[2].SetActive(true);
					pointChecker.resetSkill();
				}
				break;
		}
		
	}
}
