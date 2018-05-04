using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {
	public GameObject hour;
	public GameObject minute;
	private Vector3 pivot;
	public GameObject[] Gear;
	// Use this for initialization
	void Start () {
		pivot = Vector3.zero;
		pivot.y = hour.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		hour.transform.RotateAround(pivot,Vector3.down, 0.5f);
		minute.transform.RotateAround(pivot, Vector3.up, 1.0f);
		for(int i = 0; i < Gear.Length; ++i)
		{
			if(i%2==0)
			Gear[i].transform.Rotate(Vector3.back,i*0.1f+0.1f);
			else
			{
				Gear[i].transform.Rotate(Vector3.forward, i * 0.1f + 0.1f);
			}
		}
	}
}
