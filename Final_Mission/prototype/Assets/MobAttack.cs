using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour {
	public float Speed = 8.0f;
	// Use this for initialization
	Vector3 Direction;
	MonsterAI ai;
	void Start () {
		ai = FindObjectOfType<MonsterAI> ();
		//this.transform.LookAt (ai.mobSearch.PlayerPos);

		Vector3 Direction = ai.mobSearch.PlayerPos;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.forward * Time.deltaTime * Speed);
		if (Vector3.Distance ( Direction, this.transform.position) > ai.MobRange*2)
			Destroy (this.gameObject);
		
		if (Vector3.Distance (ai.mobSearch.PlayerPos, this.transform.position) < 0.5f) {
			//Debug.Log ("Player Hit");
			Destroy (this.gameObject);
		}
		
	}
}
