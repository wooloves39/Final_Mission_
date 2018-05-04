using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
	Tower tower;
	// Use this for initialization
	void Start () {
		tower = GetComponentInParent<Tower> ();
	}
	
	// Update is called once per frame
	void Update () {		
		this.transform.LookAt (tower.taget);
		this.transform.Translate (Vector3.forward*11*Time.deltaTime);
		if (Vector3.Distance (this.transform.position, tower.taget) < 0.5f)
			Destroy(gameObject);}
}
