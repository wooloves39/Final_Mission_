using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dell_Buff_Active : MonoBehaviour {
	public GameObject[] particles;
	public float BuffTime;
	private void OnEnable()
	{
		StartCoroutine(Buff(BuffTime));
	}
	IEnumerator Buff(float buffTimer)
	{
		yield return new WaitForSeconds(4.0f);
		for (int i = 0; i < particles.Length; ++i)
		{
			particles[i].SetActive(false);
		}
		yield return new WaitForSeconds(buffTimer);
		for (int i = 0; i < particles.Length; ++i)
		{
			particles[i].SetActive(true);
		}
		gameObject.SetActive(false);
	}

}
