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
    public GameObject Effect;
    // Use this for initialization
    void Awake () 
    {
		sound = GetComponent<BossSoundSetting>();
		Hp = GetComponent<ObjectLife>().Hp;
		VerManager = Instantiate(Prefab).GetComponent<VerbashMonSkill>();
        VerManager.MyCharacters = gameObject;
        AI = GetComponent<Stage5Boss>();
	}
    void Start()
    {
        target = GetComponent<BattleCommand>().getTarget();
    }
    void Apprier()
    {
        sound.PlayerSound(0);
    }
    void Hit()
    {

        sound.PlayerSound(1);
    }
    void Lose_Sound()
    {
        Effect.SetActive(false);
        sound.PlayerSound(3);
    }
	void Attack1()
    {
        sound.PlayerSound(2);
		VerManager.shoot(1, target);
		//beejaeManager;
	}
	void Attack2()
    {
        sound.PlayerSound(2);
        AI.CoolTime(1);
		VerManager.shoot(2, target);
	}
	void Attack3()
    {
        sound.PlayerSound(2);
        AI.CoolTime(2);
		VerManager.shoot(3, target);

	}
	void Attack4()
    {
        sound.PlayerSound(2);
        AI.CoolTime(3);
		VerManager.shoot(4, target);

	}
	void Attack5()
    {
        sound.PlayerSound(4);
        AI.CoolTime(4);
		VerManager.shoot(5, target);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}

}
