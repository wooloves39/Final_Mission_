using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwan_SavenGaurdControll : MonoBehaviour {
	public GameObject SeiKwan_Saven;
	private LinePointChecker pointChecker;
	// Use this for initialization
	void Start () {
		pointChecker = GetComponent<LinePointChecker>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pointChecker.getCurrentSkill() == 4)
		{
			pointChecker.resetSkill();
			SeiKwan_Saven.SetActive(true);
		}
	}
}
