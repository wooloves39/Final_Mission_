using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbashMob_Controll : MonoBehaviour {
	public GameObject Prefab;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
    private VerbashMonSkill VerManager;
    private Stage5Boss AI;
	// Use this for initialization
	void Start()
	{
		sound = GetComponent<BossSoundSetting>();
		target = GetComponent<BattleCommand>().getTarget();
		Hp = GetComponent<ObjectLife>().Hp;
		VerManager = Instantiate(Prefab).GetComponent<VerbashMonSkill>();
        VerManager.MyCharacters = gameObject;
        AI = GetComponent<Stage5Boss>();
	}
	void Attack1()
    {
		VerManager.shoot(1, target);
		//beejaeManager;
	}
	void Attack2()
    {
        AI.CoolTime(1);
		VerManager.shoot(2, target);
	}
	void Attack3()
    {
        AI.CoolTime(2);
		VerManager.shoot(3, target);

	}
	void Attack4()
    {
        AI.CoolTime(3);
		VerManager.shoot(4, target);

	}
	void Attack5()
    {
        AI.CoolTime(4);
		VerManager.shoot(5, target);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}

}
