using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWaveGenerate : MonoBehaviour
{
	public GameObject Prefab;
	public int Prefab_Count;
	private int GenTime;
	private MemoryPool pool;
	private MobGenerater mobGenerater;
	private bool initFinish = false;
	public bool InitFinish { get { return initFinish; } }
	public bool Finalboss = false;
	public bool first = false;
    public bool FinalMiddleBoss = false;
    public GameObject[] FinalPrefab;
    public GameObject[] FinalMobPrefab;
    public int[] FinalMobCount;
	// Use this for initialization
	private void Awake()
	{
		mobGenerater = GetComponent<MobGenerater>();
		pool = new MemoryPool();
		if (!Finalboss)
		{
			if (Singletone.Instance.stage != 6)
				pool.Create(Prefab, Prefab_Count);
			else
			{

				int N = NoHaveSkill(first);
                if (FinalMiddleBoss)
                {
                    switch (N)
                    {
                        case 0:
                            pool.Create(FinalPrefab[N], 1);
                            break;
                        case 1:
                            pool.Create(FinalPrefab[N], 1);
                            break;
                        case 2:
                            pool.Create(FinalPrefab[N], 1);
                            break;
                        case 3:
                            pool.Create(FinalPrefab[N], 1);
                            break;
                        case 4:
                            pool.Create(FinalPrefab[N], 1);
                            break;
                    }
                }
                else
                {
                    switch (N)
                    {
                        case 0:
                            pool.Create(FinalMobPrefab[N], FinalMobCount[N]);
                            break;
                        case 1:
                            pool.Create(FinalMobPrefab[N], FinalMobCount[N]);
                            break;
                        case 2:
                            pool.Create(FinalMobPrefab[N], FinalMobCount[N]);
                            break;
                        case 3:
                            pool.Create(FinalMobPrefab[N], FinalMobCount[N]);
                            break;
                        case 4:
                            pool.Create(FinalMobPrefab[N], FinalMobCount[N]);
                            break;
                    }
                }
			}
		}
		else
		{
			pool.Create(Prefab, Prefab_Count);
		}
		GenTime = mobGenerater.GenTime;
		StartCoroutine(MobGen());
	}
	IEnumerator MobGen()
	{
		yield return new WaitUntil(() => mobGenerater.Wave_Start);

		yield return new WaitForSeconds(GenTime);
		for (int i = 0; i < Prefab_Count; ++i)
		{
			int initPos = i % 3;
			pool.NewItem(mobGenerater.Position[initPos].transform.position);
		}
		yield return new WaitForSeconds(1);
		initFinish = true;
		mobGenerater.checkInit();
		
	}
	public bool MondieAll()
	{
		return pool.AllDie();
	}
	private void OnApplicationQuit()
	{
		pool.Dispose();
	}
	public int NoHaveSkill(bool check)
	{

		int[] arr = { 0, 1, 2, 3, 4 };
		for (int i = 0; i < 5; ++i)
			for (int j = 0; j < 3; ++j)
				if (Singletone.Instance.Myskill[j] == arr[i])
					arr[i] = -1;

		for (int i = 0; i < 5; ++i)
			if (arr[i] != -1)
				if (check)
				{
					return arr[i];
					break;
				}
				else
				{
					arr[i] = -1;
					break;
				}

		for (int i = 0; i < 5; ++i)
			if (arr[i] != -1)
				if (!check)
					return arr[i];

		return 0;
	}
}
