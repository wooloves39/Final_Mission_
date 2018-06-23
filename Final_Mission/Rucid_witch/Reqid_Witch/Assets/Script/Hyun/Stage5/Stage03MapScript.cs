using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage03MapScript : MonoBehaviour {
	public GameObject[] particleOn;
	// Use this for initialization
	void Start () {
		StartCoroutine(ParticleOnCor());
	}
	IEnumerator ParticleOnCor()
	{
		particleOn[0].SetActive(true);
		yield return new WaitForSeconds(2.5f);
		particleOn[1].SetActive(true);
		yield return new WaitForSeconds(2.5f);
		particleOn[2].SetActive(true);
		yield return new WaitForSeconds(2.5f);
		particleOn[3].SetActive(true);
		yield return new WaitForSeconds(2.5f);
		particleOn[4].SetActive(true);
	}
}
