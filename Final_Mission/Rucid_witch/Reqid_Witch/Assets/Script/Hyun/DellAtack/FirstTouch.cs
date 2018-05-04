using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTouch : MonoBehaviour {
	private AttackMethod attackMethod;
	private bool firstTouch;
	private AudioSource dellsound;
	private void OnEnable()
	{
		firstTouch = false;
	}
	// Use this for initialization
	private void Awake()
	{
		dellsound = gameObject.transform.parent.GetComponent<AudioSource>();
		attackMethod = gameObject.transform.parent.parent.parent.parent.GetComponent<AttackMethod>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			if (!attackMethod.getDelltouch())
			{
				Debug.Log("활 앞대가리 맞음");
				attackMethod.setDelltouch(true);
				if (!firstTouch)
				{
					attackMethod.DellCharging(9.0f);
					dellsound.Play();
					firstTouch = true;
				}
			}
		}
	}
}
