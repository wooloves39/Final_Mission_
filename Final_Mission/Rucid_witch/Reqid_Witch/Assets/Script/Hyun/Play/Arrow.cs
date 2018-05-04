using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private bool shot = false;
	private bool del_timer = false;
	private float timer;
	private float delTime;
	private Vector3 curScale;
	// Use this for initialization
	void Awake () {
		timer = new int();
		timer = 0.0f;
		curScale = gameObject.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		if (shot == true)
		{
			timer += Time.deltaTime;
			if (timer >= delTime)
				del_timer = true;
		}
	}
	public void setDelTime(float time) { delTime = time; }
	public void Shooting(bool val)
	{
		shot = val;
	}
	public bool IsShooting() { return shot; }
	public bool IsDelete()
	{
		return del_timer;
	}
	public void resetArrow()
	{
		shot = false;
		 del_timer = false;

		timer = 0.0f;
		gameObject.transform.localScale = curScale;
	}
}
