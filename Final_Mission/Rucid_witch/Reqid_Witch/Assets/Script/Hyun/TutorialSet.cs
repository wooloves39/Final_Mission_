using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSet : MonoBehaviour {

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
    {
        while (true)
        {
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
        }
        tutorialStep = 4;
    }
}
