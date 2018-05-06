using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoards : MonoBehaviour {

	private Transform camTr;
	private Transform tr;
	public Vector3 RotateBalance;
	// Use this for initialization
	void Start()
	{
		camTr = Camera.main.transform;
		tr = transform;
	}

	// Update is called once per frame
	void Update()
	{
		tr.LookAt(camTr.position);
		tr.Rotate(RotateBalance);
	}
}
