using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {
	public GameObject[] minimap;
	private int stage;
	// Use this for initialization
	void Start () {
		stage = Singletone.Instance.stage;
		minimap[stage].SetActive(true);
	}
}
