using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzuraParticle : MonoBehaviour {
	private Transform AzuraBall;
	private void Awake()
	{
		AzuraBall = transform.parent.parent.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = AzuraBall.localScale*0.05f;
	}
}
