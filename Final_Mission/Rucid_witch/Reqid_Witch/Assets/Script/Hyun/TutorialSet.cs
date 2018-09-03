using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSet : MonoBehaviour
{
    public GameObject completeMark;
    public int tutorialStep = -1;
    public GameObject EasyMonster;
    public GameObject[] Monster;
    public PlayerState player { get; set; }
    private Dia_Play playerDialog;
    public MobGenerater[] wave;

    private void Awake()
    {
        player = FindObjectOfType<PlayerState>();
        playerDialog = player.GetComponentInChildren<Dia_Play>();
        StartCoroutine(Tutorial1());
    }
    IEnumerator Tutorial1()//back
    {
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 0)
                {
                    if (InputManager_JHW.BButtonDown())
                        break;
                }
            }
            yield return null;
        }
        tutorialStep = 1;
        StartCoroutine(Tutorial2());
        if (playerDialog.getPlay())
        {
            player.SetMyState(PlayerState.State.Talk);
            playerDialog.setPlay(false);

        }
    }
    IEnumerator Tutorial2()//속성 변경
    {
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 1)
                {
                    if (InputManager_JHW.XButtonDown())
                        break;
                }
            }
            yield return null;
        }
        tutorialStep = 2;
        StartCoroutine(Tutorial3());
        if (playerDialog.getPlay())
        {
            player.SetMyState(PlayerState.State.Talk);
            playerDialog.setPlay(false);

        }
    }
    IEnumerator Tutorial3()//마법진 그리기
    {

        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 2)
                {
                    if (completeMark.activeSelf)
                        break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        tutorialStep = 3;
        StartCoroutine(Tutorial4());
        if (playerDialog.getPlay())
        {
            player.SetMyState(PlayerState.State.Talk);
            playerDialog.setPlay(false);

        }
    }
    IEnumerator Tutorial4()//공격
    {
        ObjectLife obj = EasyMonster.GetComponent<ObjectLife>();
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 3)
                {
                    if (obj.Hp <= 0)
                    {
                        EasyMonster.SetActive(false);
                        break;
                    }
                    else if (!EasyMonster.activeSelf)
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
        tutorialStep = 4;
        StartCoroutine(Tutorial5());
        if (playerDialog.getPlay())
        {
            player.SetMyState(PlayerState.State.Talk);
            playerDialog.setPlay(false);

        }
    }
    IEnumerator Tutorial5()
    {
        ObjectLife obj1 = Monster[0].GetComponent<ObjectLife>();
        ObjectLife obj2 = Monster[1].GetComponent<ObjectLife>();
        ObjectLife obj3 = Monster[2].GetComponent<ObjectLife>();
        while (true)
        {
            if (player.GetMyState() != PlayerState.State.Talk)
            {
                if (tutorialStep == 4)
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
        }
        tutorialStep = 5;
    }
}



