using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFollower : MonoBehaviour {
	public GameObject[] skill_logices;
	public SelectSkillUI selectSkillUI;
	private int checkSkill;
	public SelectMenu_Ready Menu;
	private bool confirm;
	// Use this for initialization
	void Start () {
		checkSkill = selectSkillUI.GetRotationSkill();
		skill_logices[checkSkill].SetActive(true);
	if(Menu.selMenu.gameObject==gameObject)
		confirm = Menu.confirm;
	}
	
	// Update is called once per frame
	void Update () {
		if (Menu.selMenu.gameObject == gameObject)
			confirm = Menu.confirm;
		if (checkSkill!= selectSkillUI.GetRotationSkill())
		{
			skill_logices[checkSkill].SetActive(false);
			checkSkill = selectSkillUI.GetRotationSkill();
			skill_logices[checkSkill].SetActive(true);
		}
	}
	public bool IsConfirm() {
		return confirm; }
}
