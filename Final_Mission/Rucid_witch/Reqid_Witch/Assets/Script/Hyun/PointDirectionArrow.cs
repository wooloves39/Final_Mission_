using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDirectionArrow : MonoBehaviour
{
	public Transform TargetTr { get; set; }
	public float speed = 2.0f;
	private Transform ParTr;
	private void Awake()
	{
		ParTr = transform.parent;
		transform.position = transform.parent.position;
		transform.LookAt(TargetTr);
		transform.Rotate(0, 0, -90);
	}
	// Use this for initialization
	private void OnEnable()
	{
		transform.position = transform.parent.position;
		transform.LookAt(TargetTr);
		transform.Rotate(0, 0,  - 90);
	}
	private void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime* speed);
		if (Vector3.Distance(TargetTr.transform.position, transform.position) < .05f)
		{
			transform.position = ParTr.position;
		}
	}

}
