using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeejaeMonControll : MonoBehaviour {
	public GameObject BeejeaPrefab;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
    private BeeJaeMonSkill beejaeManager;
    private Stage5Boss AI;
	// Use this for initialization
	void Awake () 
    {
		sound = GetComponent<BossSoundSetting>();
		Hp = GetComponent<ObjectLife>().Hp;
		beejaeManager=Instantiate(BeejeaPrefab).GetComponent<BeeJaeMonSkill>();
        beejaeManager.MyCharacters=gameObject;
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
    void Look()
    {
        this.gameObject.transform.LookAt(target.transform.position);
    }
    void Hit()
    {

        sound.PlayerSound(1);
    }
    void Lose_Sound()
    {
        sound.PlayerSound(3);
    }
	void Attack1()
    {
        sound.PlayerSound(2);
        // Use this for initialization
        Debug.Log("Attack1");
		beejaeManager.shoot(1, target);
		//beejaeManager;
	}
	void Attack2()
    {
        sound.PlayerSound(2);
        AI.CoolTime(1);
		beejaeManager.shoot(2, target);
	}
	void Attack3()
    {
        AI.CoolTime(2);
        sound.PlayerSound(2);
		beejaeManager.shoot(3, target);

	}
	void Attack4()
    {
        sound.PlayerSound(2);
        AI.CoolTime(3);
		beejaeManager.shoot(4, target);

	}
	void Attack5()
    {
        sound.PlayerSound(4);
        AI.CoolTime(4);
		beejaeManager.shoot(5, target);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}

}
