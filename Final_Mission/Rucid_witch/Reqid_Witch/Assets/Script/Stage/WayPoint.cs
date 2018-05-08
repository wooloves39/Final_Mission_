using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	public bool check = false;
	private int once = 0;
	

	void OnTriggerStay(Collider col)
	{
		if (once == 0)
			if (col.tag == "Ground")
			{
				once++;
				check = true;
			}
	}

}
