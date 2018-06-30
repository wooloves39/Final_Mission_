using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingMark : MonoBehaviour {
	public bool isCool = false;
	private Slider slider;
	public float MPGage;
	// Use this for initialization
	void Start () {
		slider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
