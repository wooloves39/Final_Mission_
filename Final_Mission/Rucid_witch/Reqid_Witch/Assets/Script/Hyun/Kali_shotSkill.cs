using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kali_shotSkill : MonoBehaviour {
	private Rigidbody rigi;
	public float speedBalance = 1.0f;
	private Transform ObjTr;
	private void Awake()
	{
        ObjTr = FindObjectOfType<KaliMobControll>().transform;
		rigi = GetComponent<Rigidbody>();
	}
	private void OnEnable()
	{
    
	    transform.position=ObjTr.transform.position;
		transform.rotation = ObjTr.transform.rotation;
        rigi.velocity = ObjTr.transform.forward * speedBalance;
	}
  
}
