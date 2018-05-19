using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTouch : MonoBehaviour
{
	private AttackMethod attackMethod;
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

				Touch = true;
			}

		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{

			Touch = false;
		}
	}
}

