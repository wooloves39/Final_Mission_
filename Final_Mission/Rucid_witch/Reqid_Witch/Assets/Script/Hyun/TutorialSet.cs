using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSet : MonoBehaviour
{

<<<<<<< HEAD
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
=======
    public int tutorialStep = -1;
    public GameObject EasyMonster;
    public GameObject[] Monster;
    public PlayerState player;
    public MobGenerater[] wave;

    // Update is called once per frame
    private void Awake()
    {
        player = FindObjectOfType<PlayerState>();
        StartCoroutine(Tutorial1());
        StartCoroutine(Tutorial2());
        StartCoroutine(Tutorial3());
        StartCoroutine(Tutorial4());
    }
    IEnumerator Tutorial1()
    {
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 0)
                {
                    if (InputManager_JHW.BButton())
                        break;
                }
            }
            yield return new WaitForSeconds(1);
        }
        tutorialStep = 1;
    
    }
    IEnumerator Tutorial2()
>>>>>>> 97fced78beaf372329f159953be637d32b72cf82
    {
        while (true)
        {
<<<<<<< HEAD
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
=======
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 1)
                {
                    if (InputManager_JHW.XButton())
                        break;
                }
            }
            yield return new WaitForSeconds(1);
        }
        tutorialStep = 2;
    }
    IEnumerator Tutorial3()
    {
        ObjectLife obj = EasyMonster.GetComponent<ObjectLife>();
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 2)
                {
                    if (obj.Hp <= 0)
                    {
                        EasyMonster.SetActive(false);
                        break;
                    }
                    else if (!EasyMonster.activeInHierarchy)
                    {
                        if (wave[0].Wave_Start)
                        {
                            EasyMonster.SetActive(true);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
        tutorialStep = 3;
    }
    IEnumerator Tutorial4()
    {
        ObjectLife obj1 = Monster[0].GetComponent<ObjectLife>();
        ObjectLife obj2 = Monster[1].GetComponent<ObjectLife>();
        ObjectLife obj3 = Monster[2].GetComponent<ObjectLife>();
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 3)
                {

                    if (obj1.Hp <= 0 && obj2.Hp <= 0 && obj3.Hp <= 0)
                    {
                        Monster[0].SetActive(false);
                        Monster[1].SetActive(false);
                        Monster[2].SetActive(false);

                        break;
                    }
                    else
                    {
                        if (wave[1].Wave_Start)
                        {
                            if (obj1.Hp > 0)
                                Monster[0].SetActive(true);

                            if (obj2.Hp > 0)
                                Monster[1].SetActive(true);

                            if (obj3.Hp > 0)
                                Monster[2].SetActive(true);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1);
>>>>>>> 97fced78beaf372329f159953be637d32b72cf82
        }
        tutorialStep = 4;
    }
}
