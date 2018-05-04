using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Vector3 Var = Vector3.zero;
	public float Speed = 5.0f;
	public int cnt = 0;
	public int limit = 1000;

	// Update is called once per frame
	void Update () {
		
		this.transform.Rotate (Var*Time.deltaTime * Speed);
		cnt++;
		if (cnt > limit) {
			Var = new Vector3 (getRandom (-90, 90), getRandom (-90, 90), getRandom (-90, 90));
			cnt = 0;
		}
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}
