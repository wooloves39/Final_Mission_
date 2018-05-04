using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallScale : MonoBehaviour {
	public GameObject Ring;
	public float scale = 1.0f;
	public float time = 0.05f;
	public float limit = 3.0f;
	public float cnt;
	Vector3 StartRing;
	Vector3 StartThis;
	// Use this for initializationvoid OnEnable()
	void Start()
	{
		StartRing = Ring.transform.localScale;
		StartThis = this.transform.localScale;
		cnt = 0.0f;
		StartCoroutine ("ScaleUp");
	}
	void OnEnable()
	{
		cnt = 0.0f;
		StartCoroutine ("ScaleUp");
	}
	IEnumerator ScaleUp()
	{
		while (true) {
			
			this.transform.localScale = StartRing + new Vector3 (scale, scale, scale) *cnt/limit;
			Ring.transform.localScale = StartThis + new Vector3 (scale, scale, scale) *cnt/limit;

			cnt += time;
			if (limit < cnt)
				break;
			else
				yield return new WaitForSeconds (time);
		}
	}
}
