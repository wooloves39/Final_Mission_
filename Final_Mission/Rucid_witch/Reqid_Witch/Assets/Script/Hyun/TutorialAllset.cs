using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAllset : MonoBehaviour {
	public Transform player;
	Vector3 LookPos;
	// Update is called once per frame
	void Update () {
        LookPos = player.position;
        LookPos.y = transform.position.y;
        transform.LookAt(LookPos);
	}
}
