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
	
	// Update is called once per frame
	void Update () {
		
	}
	void Attack1()
	{
		buffs.SetActive(true);
	}
	void Attack2()
    {
        AI.CoolTime(1);
		DellAttackObj.SetActive(true);
		Vector3 pos= transform.position;
		pos.y += 3;
		DellAttackObj.transform.position = pos;
		DellAttackObj.GetComponent<DellSkill>().shoot(Hp / 5000.0f, target, true);
	}
	void Attack3()
    {
        AI.CoolTime(2);
		SweetMelody.SetActive(true);
	}
	void Attack3_Off()
	{
		SweetMelody.SetActive(false);
	}
	void Attack4()
    {
        AI.CoolTime(3);
		rainBow.gameObject.SetActive(true);
	}
	void Attack5()
    {
        AI.CoolTime(4);
		attackSkill.gameObject.SetActive(true);
		attackSkill.shoot(target.transform, 500.0f/Hp);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;
	}
}
