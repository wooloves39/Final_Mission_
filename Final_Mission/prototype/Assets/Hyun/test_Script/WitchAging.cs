using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAging : MonoBehaviour {
	private Transform[] childHone;
	private void Awake()
	{
		childHone = GetComponentsInChildren<Transform>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X))
		{
			witchAging(2.0f,10f);
		}
	}
	void witchAging(float speed, float deltime)
	{
		for(int i = 1; i < childHone.Length; ++i)
		{
			childHone[i].Rotate(0, i * 15, 0);
			StartCoroutine(witchAgingCour(i,  speed,  deltime));
		}
	}
	IEnumerator witchAgingCour(int indexNum,float speed,float deltime)
	{
		float timer = 0.0f;
		while (true) {
			if (timer > deltime) break;
			timer += Time.deltaTime;
			childHone[indexNum].transform.Translate(childHone[indexNum].transform.forward* speed * Time.deltaTime);
			yield return null;
		}
	}
}
