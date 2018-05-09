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
		ChangeParticle[0] = Instantiate(particles[mySkills[0]], transform);
		ChangeParticle[1] = Instantiate(particles[mySkills[1]], transform);
		ChangeParticle[2] = Instantiate(particles[mySkills[2]], transform);
		for (int i = 0; i < ChangeParticle.Length; ++i)
		{
			ChangeParticle[i].SetActive(false);
		}
		gameObject.SetActive(false);
	}
	public void setChange(int num) { ChangeParticle[num].SetActive(true); }
	public void reset()
	{
		ChangeParticle[0].SetActive(false);
		ChangeParticle[1].SetActive(false);
		ChangeParticle[2].SetActive(false);
		gameObject.SetActive(false);
	}

}
