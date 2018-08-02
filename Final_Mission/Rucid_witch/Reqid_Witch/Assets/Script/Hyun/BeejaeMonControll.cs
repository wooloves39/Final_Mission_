using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeejaeMonControll : MonoBehaviour {
	public GameObject BeejeaPrefab;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
	private BeeJaeMonSkill beejaeManager;
	// Use this for initialization
	void Start () {
		sound = GetComponent<BossSoundSetting>();
		target = GetComponent<BattleCommand>().getTarget();
		Hp = GetComponent<ObjectLife>().Hp;
		beejaeManager=Instantiate(BeejeaPrefab).GetComponent<BeeJaeMonSkill>();
		beejaeManager.MyCharacters=gameObject;
	}
	void Attack1()
	{
        Debug.Log("Attack1");
		beejaeManager.shoot(1, target);
		//beejaeManager;
	}
	void Attack2()
	{
		beejaeManager.shoot(2, target);
	}
	void Attack3()
	{
		beejaeManager.shoot(3, target);

	}
	void Attack4()
	{
		beejaeManager.shoot(4, target);

	}
	void Attack5()
	{
		beejaeManager.shoot(5, target);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}

}
