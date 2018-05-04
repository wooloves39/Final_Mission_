using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memorypool_test : MonoBehaviour {
	public float speed = 2.0f;
	public GameObject missilePrefab;

	float fireRate = 0.2f;
	float startTime;
	float shootTimeLeft;

	MemoryPool pool = new MemoryPool();
	GameObject[] missile;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		int poolCount = 10;
		pool.Create(missilePrefab, poolCount);
		missile = new GameObject[poolCount];
		for(int i = 0; i < missile.Length; ++i)
		{
			missile[i] = null;
		}
	}
	private void OnApplicationQuit()
	{
		pool.Dispose();
	}
	// Update is called once per frame
	void Update () {
		float amtMove = speed * Time.deltaTime;
		float key = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * key * amtMove);
		shootTimeLeft = Time.time - startTime;
		//발사
		if (Input.GetMouseButtonDown(0))
		{
			if (shootTimeLeft > fireRate)
			{
				for (int i = 0; i < missile.Length; i++)
				{
					if (missile[i] == null)
					{
						missile[i] = pool.NewItem();
						missile[i].transform.position = transform.position;
						break;
					}
				}
				startTime = Time.time;
				shootTimeLeft = 0.0f;
			}
		}
		//미사일삭제
		for (int i = 0; i < missile.Length; i++)
		{
			if (missile[i])
			{
				if (missile[i].transform.position.z > 20)
				{
					pool.RemoveItem(missile[i]);
					// missile[i].GetComponent<CsMissile>().init();
					missile[i] = null;
				}
			}
		}
	}
}
