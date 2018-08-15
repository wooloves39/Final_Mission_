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
    public int WavePosNum = 0;
    GameObject obj;
    public bool hidden = false;
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
                    Prefab_Count = FinalMobCount[N];
                }
            }
        }
		else
		{
            pool.Create(Prefab, Prefab_Count);
		}
		GenTime = mobGenerater.GenTime;
        StartCoroutine(MobGen());
        if (!hidden)
        {
            StartCoroutine(MonsterTeam());
            StartCoroutine(Stage7BossDie());
        }
	}
    IEnumerator Stage7BossDie()
    {
        MonsterWaveGenerate[] OtherWave = {null,null, null};
        if (FinalMiddleBoss)
        {
            while (true)
            {
                if (pool.BossDie())
                {
                    OtherWave = GetComponents<MonsterWaveGenerate>();
                    for (int i = 0; i < 3; ++i)
                    {
                        OtherWave[i].pool.AllMonsterKill();
                    }
                    break;
                }
                else
                {
                    yield return new WaitForSeconds(1.0f);
                }
            }
        }
    }
    IEnumerator MonsterTeam()
    {
        if (Prefab_Count != 1)
        {
            while (true)
            {
                if (pool.MonsterAttackCommand())
                    break;
                else
                    yield return new WaitForSeconds(1.0f);
                
            }
        }
    }

    IEnumerator MobGen()
	{
		yield return new WaitUntil(() => mobGenerater.Wave_Start);

		yield return new WaitForSeconds(GenTime);
		for (int i = 0; i < Prefab_Count; ++i)
		{
            switch (WavePosNum)
            {
                case 0:
                   obj = pool.NewItem(mobGenerater.Position[WavePosNum].transform.position);

                    break;
                case 1:
                   obj = pool.NewItem(mobGenerater.Position[WavePosNum].transform.position);

                    break;
                case 2:
                    obj = pool.NewItem(mobGenerater.Position[WavePosNum].transform.position);

                    break;

                case 3:
                    obj = pool.NewItem(mobGenerater.Position[WavePosNum].transform.position);

                    break;
                case 4:
                    obj = pool.NewItem(mobGenerater.Position[WavePosNum].transform.position);

                    break;
            }

			if (FinalMiddleBoss||Singletone.Instance.stage==10)
			{
				obj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
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
