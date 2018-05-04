using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_AniControll : MonoBehaviour {
	private Animator animator;
	private SkillFollower skillFollower;
	private int selectSkill;
	private bool cor = false;
	private AudioSource source;
	// Use this for initialization
	private void Awake()
	{
		source = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		skillFollower = transform.parent.GetComponent<SkillFollower>();
	}
	private void OnEnable()
	{
		selectSkill = 0;
	}
	// Update is called once per frame
	void Update () {
		if (skillFollower.IsConfirm()&& !cor)
		{
			cor = true;
			StartCoroutine(logicMove());
		}
		switch (selectSkill)
		{
			case 0:
				animator.Play("Skill1");
				break;
			case 1:
				animator.Play("Skill2");
				break;
			case 2:
				animator.Play("Skill3");
				break;
			case 3:
				animator.Play("Skill4");
				break;
			case 4:
				animator.Play("Skill5");
				break;
		}
	}
	IEnumerator logicMove()
	{
		while (skillFollower.IsConfirm())
		{
			Vector3 Stick;
			Stick = InputManager_JHW.MainJoystick();
			if (Stick.z > 0.3f|| Stick.x > 0.3f)
			{
				source.Play();
				   ++selectSkill;
				if (selectSkill >= 5)
				{
					selectSkill = 0;
				}
				yield return new WaitForSeconds(1.0f);
			}
			else if (Stick.z < -0.3f|| Stick.x < -0.3f)
			{
				source.Play();
				--selectSkill;
				if (selectSkill <= -1)
				{
					selectSkill = 4;
				}
				yield return new WaitForSeconds(1.0f);
			}
			yield return new WaitForSeconds(.1f);
		}
		cor = false;
	}
}
