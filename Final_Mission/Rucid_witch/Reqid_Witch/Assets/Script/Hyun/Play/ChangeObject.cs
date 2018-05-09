using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour {
	private SetChangeParticle skillChange;
	private void Awake()
	{
		skillChange = transform.parent.GetComponent<SetChangeParticle>();
	}
	private void OnEnable()
	{
		StartCoroutine(changeParticle());
	}
	IEnumerator changeParticle()
	{
		yield return new WaitForSeconds(2.0f);
		skillChange.reset();
	}
	// Update is called once per frame
	void Update () {
	}
}
