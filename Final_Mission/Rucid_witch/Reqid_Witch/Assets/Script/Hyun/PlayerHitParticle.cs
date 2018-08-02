using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitParticle : MonoBehaviour {
	public float timer = 1.0f;
	private void OnEnable()
	{
		Invoke("SetOff", timer);
	}
	private void SetOff()
	{
		gameObject.SetActive(false);
	}
}
