using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	public bool check = false;
	private int once = 0;

	private void Start()
	{
		Invoke("delete", 5.0f);
	}
	private void delete()
	{
		gameObject.SetActive(false);
	}

	void OnTriggerStay(Collider col)
	{
		if (once == 0)
			if (col.CompareTag("Ground"))
			{
				once++;
				check = true;
			}
	}

}
