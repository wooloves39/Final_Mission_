using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSet : MonoBehaviour
{

    public bool isBack = false;
    public bool isSkillChange = false;
    public bool isDrow = false;
    public bool isAttack = false;
    public int tutorialStep = 0;
    private bool isBackTu = false;
    private bool isSkillChangeTu = false;
    private bool isDrowTu = false;
    private bool isAttackTu = false;

    public GameObject completeMark;
    public AudioSource Sound;
    public AudioClip AttackSound;
    private void Update()
    {
        if (isBack)
        {
            if (InputManager_JHW.BButtonDown())
            {
                Debug.Log("뒤로 돌아!");
                isBackTu = true;
                isBack = false;
            }
        }
        else if (isSkillChange)
        {
            if (InputManager_JHW.XButtonDown())
            {
                Debug.Log("스킬 교체!");
                isSkillChangeTu = true;
                isSkillChange = false;
            }
        }
        else if (isDrow)
        {
            if (completeMark.activeSelf == true)
            {
                Debug.Log("스킬 드로우!");
                isDrowTu = true;
                isDrow = false;
            }
        }
        else if (isAttack)
        {
            if (Sound.isPlaying && Sound.clip == AttackSound)
            {
                Debug.Log("어택!");
                isAttackTu = true;
                isAttack = false;
            }
        }
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
        }
        ++tutorialStep;
    }
}
