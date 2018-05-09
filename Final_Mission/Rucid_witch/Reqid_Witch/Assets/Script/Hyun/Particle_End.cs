using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_End : MonoBehaviour {
	public float EndTime;
	private void Awake()
	{
		Destroy(gameObject, EndTime);
	}
}
