using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyOrer : MonoBehaviour {
	private Transform UI;
	private float timer;
	private bool flug = false;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		UI = gameObject.transform.Find("ReadyOrder");
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 0.5f)
		{
			flug = !flug;
			timer = 0;
			
		}
		if (flug)
		{
			UI.gameObject.SetActive(true);
		}
		else
		{
			UI.gameObject.SetActive(false);
		}
	}
}
