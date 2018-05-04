using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenCtrl : MonoBehaviour {
    public GameObject moveBox;
    public GameObject moveBox2;



    // Use this for initialization
    void Start () {
        iTween.MoveTo(moveBox, iTween.Hash("z", 5.0f, "time", 3.0f, "delay", 1.0f, "easetype", iTween.EaseType.easeInOutBounce,"oncomplete","moveFrom","oncompletetarget",this.gameObject));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   void swap()
    {

    }
}
