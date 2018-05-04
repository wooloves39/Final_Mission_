using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInput : MonoBehaviour {
	int n = Singletone.Instance.setskill;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (n != 0)
				n--;
			else
				n = 2;
			Singletone.Instance.setskill = n;
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			if (n < 2)
				n++;
			else
				n = 0;
			Singletone.Instance.setskill = n;
		}
	}
}
