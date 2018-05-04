using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSimulatir : MonoBehaviour
{
	float deltaTime;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			Vector3 targetPos = transform.position;
			targetPos.z += 40;
			SoulExplosion(targetPos);
		}
	}
	void SoulExplosion(Vector3 target)
	{
		StartCoroutine(SoulExplosionCor(target));
	}
	IEnumerator SoulExplosionCor(Vector3 target)
	{
		Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
		float speed = Random.Range(10, 15);
		float Timer = 0.0f;
		float MaxTime = Vector3.Distance(transform.position, target)/20f;
		while (true)
		{
			Timer += deltaTime;
			if (Vector3.Distance(transform.position, target) < 0.5f) break;
			transform.LookAt(target);
			Vector3 lookPos = transform.forward;
			if (Timer < MaxTime)
			{
				lookPos += dir / 2.0f;
				transform.Translate(lookPos * deltaTime * speed);
			}
			else
			{
				transform.Translate(target.normalized * deltaTime * speed);
			}
			yield return null;
		}
	}
}
