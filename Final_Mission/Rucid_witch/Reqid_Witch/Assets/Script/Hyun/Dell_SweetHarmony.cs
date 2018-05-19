using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dell_SweetHarmony : MonoBehaviour {
	
	private void OnEnable()
	{
		transform.localScale = Vector3.one;
		StartCoroutine(SweetHarmony());
	}
	private void OnDestroy()
	{
		StopAllCoroutines();
	}
	IEnumerator SweetHarmony()
	{
		Debug.Log("스윗 멜로디 발동");
		float scales = 1.0f;
		while (true)
		{
			scales += .5f;
			transform.localScale = new Vector3(scales, scales, scales);
			if (scales > 5) scales = 1.0f;
			yield return new WaitForSeconds(.3f);
		}
	}

}
