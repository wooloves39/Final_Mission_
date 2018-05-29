using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTouch : MonoBehaviour
{
	private AttackMethod attackMethod;
	public GameObject particle;
	public bool Touch { get; set; }
	private void Awake()
	{
		Touch = false;
		   attackMethod = gameObject.transform.GetComponentInParent<AttackMethod>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (attackMethod.Flug)
		{
			if (other.gameObject.CompareTag("DellAttack"))
			{
				particle.SetActive(true);
				Touch = true;
			}

		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			particle.SetActive(false);
			Touch = false;
		}
	}
}

