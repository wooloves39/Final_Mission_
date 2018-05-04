using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoSkill : MonoBehaviour {
	public List<GameObject> skill;
	private int type=new int();
	public int Skill_index;
	private void Start()
	{
		
	}
	void Update()
	{
		type = Singletone.Instance.Myskill[Skill_index];
		for (int i = 0; i < 5; ++i)
		{
			skill[i].SetActive(false);
		}
		if (type != -1)
		{
			skill[type].SetActive(true);
		}
	}
	public int Type { get; set; }
}
