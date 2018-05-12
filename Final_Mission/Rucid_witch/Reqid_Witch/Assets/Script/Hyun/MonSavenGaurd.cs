
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonSavenGaurd : MonoBehaviour
{
	private ObjectLife objectLife;
	private void Awake()
	{
		objectLife = transform.parent.GetComponent<ObjectLife>();
	}
	private void OnEnable()
	{
		StartCoroutine(SavenGaurdCor());
	}
	IEnumerator SavenGaurdCor()
	{
		float timer = 0.0f;
		while (timer <= 5.0f)
		{
			timer += .6f;
			if (objectLife.Hp < 500)
			{
				objectLife.Hp += 1;
			}
			yield return new WaitForSeconds(.6f);
		}
		gameObject.SetActive(false);
	}
}