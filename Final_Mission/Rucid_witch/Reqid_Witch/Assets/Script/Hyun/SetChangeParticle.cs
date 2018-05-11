using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChangeParticle : MonoBehaviour
{
	public GameObject[] particles;
	private int[] mySkills;
	private GameObject[] ChangeParticle;
	private void Awake()
	{
		ChangeParticle = new GameObject[3];
		mySkills = Singletone.Instance.Myskill;
		for (int i = 0; i < ChangeParticle.Length; ++i)
		{
			if (mySkills[i] > -1)
			{
				ChangeParticle[i] = Instantiate(particles[mySkills[i]], transform);
				ChangeParticle[i].SetActive(false);
			}

		}
		gameObject.SetActive(false);
	}
	public void setChange(int num)
	{
		if (ChangeParticle[num])
			ChangeParticle[num].SetActive(true);
	}
	public void reset()
	{
		for (int i = 0; i < ChangeParticle.Length; ++i)
		{
			if (ChangeParticle[i])
				ChangeParticle[i].SetActive(false);
		}

		gameObject.SetActive(false);
	}

}
