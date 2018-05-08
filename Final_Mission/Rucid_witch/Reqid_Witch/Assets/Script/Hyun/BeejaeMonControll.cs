using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeejaeMonControll : MonoBehaviour {
	public GameObject BeejeaPrefab;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
	public GameObject skill2;
	private BeeJaeMonSkill beejaeManager;
	// Use this for initialization
	void Start () {
		sound = GetComponent<BossSoundSetting>();
		target = GetComponent<BattleCommand>().getTarget();
		Hp = GetComponent<ObjectLife>().Hp;
		beejaeManager=Instantiate(BeejeaPrefab).GetComponent<BeeJaeMonSkill>();
	}
	void Attack1()
	{
		//beejaeManager;
	}
	void Attack2()
	{
		
	}
	void Attack3()
	{
		
	}
	void Attack4()
	{
		
	}
	void Attack5()
	{
		
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}

}
