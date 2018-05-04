using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

	Vector2 movePosition;
	
	// Update is called once per frame
	void Update () {
        
		movePosition = Input.mousePosition;
		transform.position = movePosition;
	}
}
