using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScriptSt6 : MonoBehaviour {
	public Transform[] RotateObj;
	public float RotateAngle=10.0f;
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < RotateObj.Length; ++i)
		{
			if (i % 2 == 0)
				RotateObj[i].transform.Rotate(Vector3.up,  RotateAngle);
			else
			{
				RotateObj[i].transform.Rotate(Vector3.down,  RotateAngle);
			}
		}
	}
}
