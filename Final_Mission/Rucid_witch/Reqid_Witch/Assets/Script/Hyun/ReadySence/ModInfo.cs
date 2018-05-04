using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModInfo : MonoBehaviour {
	public GameObject[] Objects;
	private int stage;
	// Use this for initialization
	void Start () {
		stage = Singletone.Instance.stage;
		Objects[stage-1].SetActive(true);
	}
}
