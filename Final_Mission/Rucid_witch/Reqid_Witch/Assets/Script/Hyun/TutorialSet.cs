using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSet : MonoBehaviour {

    public bool isBack = false;
    public bool isSkillChange = false;
    public bool isDrow = false;
    public bool isAttack = false;
    public bool isTargetChange = false;
    public int tutorialStep = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void stepUp()
    {
        switch (tutorialStep)
        {
            case 0:
                isBack = true;
                break;
            case 1:
                isSkillChange = true;
                break;
            case 2:
                isDrow = true;
                break;
            case 3:
                isAttack = true;
                break;
            case 4:
                isTargetChange = true;
                break;
        }
        ++tutorialStep;
    }
}
