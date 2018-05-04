using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveMob
{
	Transform x;
}

public class FrameDmg : MonoBehaviour {

	public MoveMob[] DmgArr;
	int num = 0;

	void OnTriggerEnter(Collider mob)
	{
		if (mob.tag == "enemy") {
			DmgArr.SetValue (mob.transform, num);
			num++;
		}
	}

	void OnTriggerExit(Collider mob)
	{
		if (mob.tag == "enemy") {
			DmgArr.SetValue (null, num);
			num--;
			if (num < 0)
				num = 0;
		}
	}

}
