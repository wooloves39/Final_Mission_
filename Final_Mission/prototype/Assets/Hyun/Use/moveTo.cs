using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 10.0f,
                                                       "time", 3.0f,
                                                       "delay",0.5f,
                                                       "easetype",iTween.EaseType.easeInOutElastic)
                                                       );	
	}
}
