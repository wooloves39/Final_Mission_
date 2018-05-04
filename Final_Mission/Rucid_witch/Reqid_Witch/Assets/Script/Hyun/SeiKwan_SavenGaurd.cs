using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwan_SavenGaurd : MonoBehaviour {

	private void OnEnable()
	{
		StartCoroutine(SavenGaurdCor());
	}
	IEnumerator SavenGaurdCor()
	{
		yield return new WaitForSeconds(5.0f);
		gameObject.SetActive(false);
	}
}
