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
	public GameObject[] FinalPrefab;
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
				int N = Singletone.Instance.NoHaveSkill(first);
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
}
