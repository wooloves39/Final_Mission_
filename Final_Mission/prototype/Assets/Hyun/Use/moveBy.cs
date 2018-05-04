using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveBy(this.gameObject, iTween.Hash("y", 10.0f, "time", 5.0f, "delay", 0.5f
            ,"esastype",iTween.EaseType.easeInOutSine
            ));
	}
	
}
