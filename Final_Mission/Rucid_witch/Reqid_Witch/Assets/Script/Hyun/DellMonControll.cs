using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellMonControll : MonoBehaviour {

	public GameObject SweetMelody;

	public GameObject DellAttackObj;
	public GameObject buffs;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
	public DellMonRainBow rainBow;
    public DellMonAttackSkill attackSkill;
    private Stage5Boss AI;
	private void Awake()
	{
		sound = GetComponent<BossSoundSetting>();
        Hp = GetComponent<ObjectLife>().Hp;
        AI = GetComponent<Stage5Boss>();
	}
	// Use this for initialization
	void Start () {
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
        sound.PlayerSound(3);
    }
    void Attack1()
    {
        sound.PlayerSound(2);
		buffs.SetActive(true);
	}
	void Attack2()
    {
        sound.PlayerSound(2);
        AI.CoolTime(1);
		DellAttackObj.SetActive(true);
		Vector3 pos= transform.position;
		pos.y += 3;
		DellAttackObj.transform.position = pos;
		DellAttackObj.GetComponent<DellSkill>().shoot(Hp / 5000.0f, target, true);
	}
	void Attack3()
    {
        sound.PlayerSound(2);
        AI.CoolTime(2);
		SweetMelody.SetActive(true);
	}
	void Attack3_Off()
	{
		SweetMelody.SetActive(false);
	}
	void Attack4()
    {
        sound.PlayerSound(2);
        AI.CoolTime(3);
		rainBow.gameObject.SetActive(true);
	}
	void Attack5()
    {
        Vector3 pos = transform.position;
        pos.y += 3;
        attackSkill.transform.position = pos;
        sound.PlayerSound(4);
        AI.CoolTime(4);
		attackSkill.gameObject.SetActive(true);
		attackSkill.shoot(target.transform, 500.0f/Hp);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;
	}
}
