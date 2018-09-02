using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobGenerater : MonoBehaviour
{

	public List<GameObject> Position;
	public bool Wave_Start = false;
	public int GenTime;
	public Dia_Play player;
	private PlayerState MyState;
	public GameObject[] ReaspwanParticles;
	private MonsterWaveGenerate[] monsterWaves;
    public bool block = false;
    public GameObject[] B;
    public bool Tutorial = false;
    private TutorialSet tutorialset;
    private int PrevStep = 0;
    void Start()
	{
        tutorialset = FindObjectOfType<TutorialSet>();
        MyState = player.transform.parent.GetComponent<PlayerState>();
		monsterWaves = GetComponents<MonsterWaveGenerate>();
	}
	public void waveOn()
    {
        if (tutorialset.tutorialStep < 0)
            tutorialset.tutorialStep = 0;
        PrevStep = tutorialset.tutorialStep;
        Wave_Start = true;
        if (block)
            for (int i = 0; i < 3; ++i)
            {
                B[i].SetActive(true);
            }
		for (int i = 0; i < ReaspwanParticles.Length; ++i)
		{
			ReaspwanParticles[i].SetActive(true);
		}
		StartCoroutine(Waving());
	}
	IEnumerator Waving()
	{
		bool alldie = false;
        if (!Tutorial)
        {
            yield return new WaitForSeconds(5);
            while (true)
            {
                alldie = false;
                for (int i = 0; i < monsterWaves.Length; ++i)
                {
                    if (monsterWaves[i].MondieAll())
                    {
                        alldie = true;
                        break;
                    }
                }
                if (alldie) yield return new WaitForSeconds(1);
                else
                {
                    break;
                }
            }
        }
        {
            while (true)
            {
                if (PrevStep != tutorialset.tutorialStep)
                    break;
                else
                    yield return new WaitForSeconds(1);
            }
        }
		yield return new WaitForSeconds(1);
		if (player.getPlay())
		{
			MyState.SetMyState(PlayerState.State.Talk);
			player.setPlay(false);

		}
	}
	public void checkInit()
	{
		bool flug = false;
		for (int i = 0; i < monsterWaves.Length; ++i)
		{
			if (!monsterWaves[i].InitFinish) { flug = true; break; }
		}
		if (!flug)
		{
			for (int i = 0; i < ReaspwanParticles.Length; ++i)
			{
				ReaspwanParticles[i].SetActive(false);
			}
		}
	}
}
