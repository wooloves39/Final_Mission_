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
	void Start()
	{
		MyState = player.transform.parent.GetComponent<PlayerState>();
		monsterWaves = GetComponents<MonsterWaveGenerate>();
	}
	private void Update()
	{
	}
	public void waveOn()
	{
		Wave_Start = true;
		for (int i = 0; i < ReaspwanParticles.Length; ++i)
		{
			ReaspwanParticles[i].SetActive(true);
		}
		StartCoroutine(Waving());
	}
	IEnumerator Waving()
	{
		bool alldie = false;
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
		yield return new WaitForSeconds(1);
		Debug.Log("다음 다이어로그 시작 부분");
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
	//IEnumerator MobDie()
	//{
	//	yield return new WaitUntil(() => (!pool.AllDie()&& !pool.AllDie()));//풀 종료 
	//	yield return new WaitForSeconds(1);
	//	Debug.Log("다음 다이어로그 시작 부분");
	//	if (player.getPlay())
	//	{
	//		MyState.SetMyState(PlayerState.State.Talk);
	//		player.setPlay(false);
	//		StopCoroutine(temp);
	//		for (int i = 0; i < ReaspwanParticles.Length; ++i)
	//		{
	//			ReaspwanParticles[i].SetActive(false);
	//		}
	//	}
	//}
	// Update is called once per frame
	//IEnumerator MobGen()
	//{
	//	int num = 0;
	//	bool check = false;

	//	while (true)
	//	{
	//		if (Wave_Start)
	//		{

	//			if (num < Prefab_Count.Count)
	//			{
	//				if (myTime >= GenTime[num])
	//				{

	//					for (int i = 0; i < Prefab_Count[num]; ++i)
	//					{
	//						int initPos = i % 3;
	//						pool.NewItem(Position[initPos].transform.position);
	//					}
	//					if (!check)
	//					{
	//						StartCoroutine("MobDie");
	//						check = true;
	//					}
	//					num++;
	//				}
	//			}
	//			myTime++;
	//			yield return new WaitForSeconds(1);
	//		}
	//		yield return new WaitForSeconds(1);
	//	}
	//}
	//private void OnApplicationQuit()
	//{
	//	pool.Dispose();
	//}
}
