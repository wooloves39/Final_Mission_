using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {
	private ObjectLife life;
	public GameObject TargetFrame;
	public GameObject BarFrame;
	public GameObject[] Level;
	public float here;
	public bool check = false;
	public bool taget = false;

	// Use this for initialization
	void Start () {
		life = GetComponentInParent<ObjectLife>();
		BarFrame.SetActive(false);
		for (int i = 0; i < Level.Length; ++i)
		{
			Level[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Tageting();
		if (check)
		{
			BarFrame.SetActive(true);
			here = (float)life.Hp / (float)life.MaxHp;
			here *= (Level.Length - 1);
			this.transform.LookAt(Camera.main.transform);
			for (int i = 0; i < Level.Length; ++i)
			{
				if (i == (int)here)
					Level[i].SetActive(true);
				else
					Level[i].SetActive(false);
			}
		}
		else
		{
			BarFrame.SetActive(false);
			for (int i = 0; i < Level.Length; ++i)
			{
				Level[i].SetActive(false);
			}
		}
	}
	void Tageting()
	{
		if (taget == true)
		{
			TargetFrame.SetActive(true);
			check = true;
		}
		else
		{
			check = false;
			TargetFrame.SetActive(false);
		}
		if (life.Hp != life.MaxHp)
		{
			check = true;
		}
	}
}
