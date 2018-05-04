using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour {
	public GameObject ArrowPrefab;

	MemoryPool pool = new MemoryPool();
	GameObject[] Arrow;
	// Use this for initialization
	void Start () {
		int poolCount = 5;
		pool.Create(ArrowPrefab, poolCount);
		Arrow = new GameObject[poolCount];
		for (int i = 0; i < Arrow.Length; ++i)
			Arrow[i] = null;
	}
	private void OnApplicationQuit()
	{
		pool.Dispose();
	}
	// Update is called once per frame
	void Update () {
		if (true)//어떤 조건에 의해 화살이 생길때!
		{
			for(int i = 0; i < Arrow.Length; ++i)
			{
				if (Arrow[i] == null)
				{
					Arrow[i] = pool.NewItem();
					//에로우 첫포지션 등 셋팅
					break; 
				}
			}
		}
		for(int i = 0; i < Arrow.Length; ++i)
		{
			if (Arrow[i])
			{
				//어떤 조건에 의거하여 화살이 지워져야할때
				pool.RemoveItem(Arrow[i]);
				Arrow[i] = null;
			}
		}
	}
}
