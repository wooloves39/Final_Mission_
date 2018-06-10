using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChargeBar : MonoBehaviour {
	private PlayerState playerState;
	private Slider slider;
	// Use this for initialization
	private void Awake()
	{
		playerState = GetComponentInParent<PlayerState>();
		slider = GetComponent<Slider>();
	}
	void Start () {
		
	}
	private void OnEnable()
	{
		slider.value = 1.0f;
	}
	// Update is called once per frame
	void Update () {
		slider.value = 1 - playerState.chargingRate();
	}
}
