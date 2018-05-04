using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rotate : MonoBehaviour {
    Vector3 pos = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = InputManager_JHW.SubJoystick() ;
        pos.y = -pos.x;
        pos.x = 0.0f;
        pos.z = 0.0f;
        transform.Rotate(pos);
	}
}
