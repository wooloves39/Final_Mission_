using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFrom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveFrom(this.gameObject, iTween.Hash("x", 20.0f, "time", 5.0f, "delay", 3.0f));
	}
	
}
