using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLineUI : MonoBehaviour {
	public GameObject[] SkillSet;
	private void Awake()
	{
		for (int i = 0; i < SkillSet.Length; ++i)
		{
			SkillSet[i].SetActive(false);
		}
	}
	private void OnEnable()
	{
		SkillSet[LineDraw.curType].SetActive(true);
	}
	private void OnDisable()
	{
		for(int i = 0; i < SkillSet.Length; ++i)
		{
			SkillSet[i].SetActive(false);
		}
	}
}
