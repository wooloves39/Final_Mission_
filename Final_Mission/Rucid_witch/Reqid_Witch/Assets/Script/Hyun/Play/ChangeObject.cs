using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour {
	private ParticleSystem particle;
	// Use this for initialization
	private void Awake()
	{
		particle = GetComponent<ParticleSystem>();
	}
	private void OnEnable()
	{
		StartCoroutine(changeParticle());
	}
	IEnumerator changeParticle()
	{
		yield return new WaitForSeconds(2.0f);
		transform.parent.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
	}
}
