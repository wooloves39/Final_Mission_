using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDirectionArrow : MonoBehaviour {
	public Transform TargetTr { get; set; }
	public float speed = 2.0f;
	private Transform ParTr;
	private void Awake()
	{
		ParTr = transform.parent;
	}
	// Use this for initialization
	private void OnEnable()
	{
		transform.position = transform.parent.position;
		transform.LookAt(TargetTr);
	}
	private void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime);
		if(Vector3.Distance(TargetTr.transform.position, transform.position) < .5f)
		{
			transform.position = ParTr.position;
		}
	}

}
