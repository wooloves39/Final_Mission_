using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBlast : MonoBehaviour {
	Transform target;//타겟받아오기
	float timer = 0.0f;
	// Use this for initialization
	void Start () {
		//transform.position = target.position;
	}
	private void OnEnable()
	{
		//transform.position = target.position;
	}
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		transform.Rotate(0, 10* timer, 0);
		if (timer >= 2.0f)
		{
			timer = 0;
			transform.rotation = Quaternion.identity;
			gameObject.SetActive(false);
			//내위치 변경
		}
	}
}
