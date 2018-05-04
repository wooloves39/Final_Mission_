using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallofGod : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		//타겟된 오브젝트로
		transform.LookAt(transform.forward);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			callofGad(10.0f, 3.0f, 5.0f);
		}
	}
	void callofGad(float speed, float scale, float time)
	{
		StartCoroutine(callofGadCor(speed, scale, time));
	}
	IEnumerator callofGadCor(float speed, float scale, float time)
	{
		float timer = 0.0f;
		float cur_Scale = 1.0f;
		while (true)
		{
			timer += Time.deltaTime;
			cur_Scale = scale * (timer / time);
			Debug.Log(cur_Scale);
			Vector3 scaleVector = Vector3.one;
			if (cur_Scale < 1.0f) cur_Scale = 1.0f;
			transform.localScale = scaleVector * cur_Scale;
			transform.Translate(transform.forward * Time.deltaTime * speed);
			if (timer > time) break;
			yield return null;
		}
	}
}
