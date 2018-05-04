using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour {

	public LinePointChecker[] Skills;
	private int[] mySkills;
	private float timer = 0;
	private bool skillon;
	private float skill_timer;
	private int mytype;
	private bool touchOn = false;
	private LaserColl raser;
	private PlayerState Mystate;
	public static int curType;
	// Use this for initialization
	void Awake()
	{
		raser = GetComponentInChildren<LaserColl>();
		mytype = 0;
		skill_timer = 0;
		skillon = false;
		mySkills = Singletone.Instance.Myskill;
		curType = mySkills[mytype];
		raser.gameObject.SetActive(false);
		Mystate = gameObject.transform.parent.parent.GetComponent<PlayerState>();
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		//skill이 성립되었을경우 1초간 보여준다. 
		if (skillon == true)
		{
			skill_timer += Time.deltaTime;
			if (skill_timer > 1.0f)
			{
				skill_timer = 0.0f;
				skillon = false;
			}
		}
		else
		{
			//마우스 클릭시
			//if (touchOn == false && InputManager_JHW.AButton())

			if (InputManager_JHW.RTriggerOn() && touchOn == false)
			{
				if (Mystate.GetMyState() == PlayerState.State.Nomal || Mystate.GetMyState() == PlayerState.State.Drawing)
				{
					Mystate.SetMyState(PlayerState.State.Drawing);
					//skill 오브젝트를 좌표에 맞게 생성한다.
					raser.gameObject.SetActive(true);

					Vector3 pos = raser.transform.position;
					pos += raser.transform.forward*.1f;
					Skills[mySkills[mytype]].transform.position = pos;

					//Skills[mySkills[mytype]].transform.rotation = transform.rotation;
					Skills[mySkills[mytype]].transform.rotation = Camera.main.transform.rotation;
					Skills[mySkills[mytype]].gameObject.SetActive(true);
					touchOn = true;
				}
			}
			else if (touchOn == true && !InputManager_JHW.RTriggerOn())
			{
				raser.gameObject.SetActive(false);
				touchOn = false;
				Skills[mySkills[mytype]].SkillOn();
				Mystate.SetMyState(PlayerState.State.Nomal);
			}
			if (InputManager_JHW.LTriggerOn() && Mystate.GetMyState() == PlayerState.State.Drawing)
			{
				raser.gameObject.SetActive(false);
				touchOn = false;
				Skills[mySkills[mytype]].SkillOn();
				Mystate.SetMyState(PlayerState.State.Nomal);
			}
		}
	}
	public void Upcount(PointCheck col)
	{
		//Skills[mySkills[mytype]].UpCount();
		Skills[mySkills[mytype]].TouchPoint(col);
	}
	public void myType()
	{

		++mytype;
		if (mytype > 2) mytype = 0;
		if (mySkills[mytype] == -1) --mytype;
		curType = mySkills[mytype];
		Skills[curType].resetSkill();
	}
	public bool IsHaveSkill(int type)
	{
		for (int i = 0; i < mySkills.Length; ++i)
		{
			if (type == mySkills[i]) return true;
		}
		return false;

	}
}
