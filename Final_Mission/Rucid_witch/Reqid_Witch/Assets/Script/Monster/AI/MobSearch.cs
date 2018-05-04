using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSearch : MonoBehaviour {
	Stage5MobAI Mobai;
	Stage5Boss Bossai;
	public bool Search = false;
	public Vector3 PlayerPos;
	// Use this for initialization
	void Start () {
		Mobai = GetComponentInParent<Stage5MobAI>();
		Bossai = GetComponentInParent<Stage5Boss>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			Search = true;
			if(Bossai == null)
				Mobai.Fight = true;
			else
				Bossai.Fight = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			Search = false;
			if(Bossai == null)
				Mobai.Fight = false;
			else
				Bossai.Fight = false;
		}
	}
}
