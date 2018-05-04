using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viberation : MonoBehaviour
{
	
	public static IEnumerator ViberationCoroutine(float time, float power, OVRInput.Controller controller)
	{ 
		OVRInput.SetControllerVibration(.2f, power, controller);
		yield return new WaitForSeconds(time);
		OVRInput.SetControllerVibration(.2f, 0, controller);
	}
	public static IEnumerator ViberationCoroutine(float time, float startPower, float EndPower, OVRInput.Controller controller)
	{
		int count = 0;
		float power = startPower;
		while (count!=(int)time)
		{
			++count;
			if (power > EndPower) power -= 0.1f;
			else if (power < EndPower) power += 0.1f;
			OVRInput.SetControllerVibration(.1f, power, controller);
			yield return new WaitForSeconds(1.0f);
		}
		OVRInput.SetControllerVibration(.2f, 0, controller);
		yield return null;
	}
}
