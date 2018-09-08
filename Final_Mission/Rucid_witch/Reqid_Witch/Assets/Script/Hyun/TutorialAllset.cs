using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAllset : MonoBehaviour {
	public Transform player;
	Vector3 LookPos;
	// Use this for initialization
	void Start () {
		LookPos = player.position;
		LookPos.y = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(LookPos);
	}
}
