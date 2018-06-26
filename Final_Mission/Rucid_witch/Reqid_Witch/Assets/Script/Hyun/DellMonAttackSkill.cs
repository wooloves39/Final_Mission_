using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellMonAttackSkill : MonoBehaviour {
	public Transform Target{ get; set; }
	private Rigidbody rigi;
	private void Awake()
	{
		rigi = GetComponent<Rigidbody>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 270 * Time.deltaTime);
	}
	public void shoot(Transform tr,float charging)
	{
		Target = tr;
		transform.LookAt(Target);
		rigi.velocity = Vector3.forward * charging;
	}
}
