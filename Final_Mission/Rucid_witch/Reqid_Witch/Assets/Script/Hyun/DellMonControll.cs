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
	private void Awake()
	{
		sound = GetComponent<BossSoundSetting>();
		
		Hp = GetComponent<ObjectLife>().Hp;
		int poolCount = 5;
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
		DellAttackObj.SetActive(true);
		Vector3 pos= transform.position;
		pos.y += 5;
		DellAttackObj.transform.position = pos;
		DellAttackObj.GetComponent<DellSkill>().shoot(Hp / 5000.0f, target, true);
	}
	void Attack3()
	{
		SweetMelody.SetActive(true);
	}
	void Attack4()
	{
		rainBow.gameObject.SetActive(true);
	}
	void Attack5()
	{
		attackSkill.gameObject.SetActive(true);
		attackSkill.shoot(target.transform, Hp / 5000.0f);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}
}
