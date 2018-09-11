using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSet : MonoBehaviour
{
    public GameObject completeMark;
    public int tutorialStep = -1;
    public GameObject EasyMonster;
    public PlayerState player { get; set; }
    private Dia_Play playerDialog;
    public MobGenerater wave;
	public GameObject helpLast;
    private void Awake()
    {
        player = FindObjectOfType<PlayerState>();
        playerDialog = player.GetComponentInChildren<Dia_Play>();
        StartCoroutine(Tutorial1());
    }
	IEnumerator Tutorial1()//back
	{
        int count = 0;
		while (true)
		{
			if (player.GetMyState() != PlayerState.State.Talk)
			{
				if (tutorialStep == 0)
				{
					if (InputManager_JHW.BButtonDown())
                    {
                        ++count;

                        if (count== 2) break;
                        if (playerDialog.getPlay())
                        {
                            player.SetMyState(PlayerState.State.Talk);
                            playerDialog.setPlay(false);
                        }
                    }
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
	IEnumerator Tutorial2()//back
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
	IEnumerator Tutorial3()//속성 변경
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
    IEnumerator Tutorial4()//마법진 그리기
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
                        if (wave.Wave_Start)
                        {
                            EasyMonster.SetActive(true);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
        tutorialStep = 4;
        if (playerDialog.getPlay())
        {
            player.SetMyState(PlayerState.State.Talk);
            playerDialog.setPlay(false);
            helpLast.SetActive(true);
        }
    }
}



