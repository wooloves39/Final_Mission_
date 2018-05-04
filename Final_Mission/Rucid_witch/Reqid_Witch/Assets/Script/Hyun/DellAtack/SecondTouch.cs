using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTouch : MonoBehaviour {
	private AttackMethod attackMethod;
	// Use this for initialization
	private void Awake()
	{
		attackMethod = gameObject.transform.parent.parent.parent.parent.GetComponent<AttackMethod>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			if (attackMethod.getDelltouch())
			{
				Debug.Log("활 뒷대가리 맞음");
				attackMethod.setDelltouch(false);
				attackMethod.setDellcount();
			}
		}
	}
}
