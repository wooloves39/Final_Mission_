using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwanMonControll : MonoBehaviour {

	public GameObject ArrowPrefab;
	MemoryPool Arrowpool = new MemoryPool();
	GameObject[] Arrow;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
	// Use this for initialization
	private void Awake()
	{
		sound = GetComponent<BossSoundSetting>();
		target = GetComponent<BattleCommand>().getTarget();
		Hp = GetComponent<ObjectLife>().Hp;
		int poolCount = 5;
		Arrowpool.Create(ArrowPrefab, poolCount);
		Arrow = new GameObject[poolCount];
		for (int i = 0; i < Arrow.Length; ++i)
			Arrow[i] = null;
	}
	private void OnApplicationQuit()
	{
		Arrowpool.Dispose();
	}
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Arrow.Length; ++i)
		{
			if (Arrow[i])
			{
				if (Arrow[i].GetComponent<SeiKwanSkill>().IsDelete())
				{
					Arrow[i].GetComponent<SeiKwanSkill>().resetDelete();
					Arrowpool.RemoveItem(Arrow[i]);
					Arrow[i] = null;
				}
				//어떤 조건에 의거 Arrow삭제
			}
		}
	}
	void Attack1()
	{
		int ArrowNum=0;
		for (int i = 0; i < Arrow.Length; ++i)
		{
			if (Arrow[i] == null)
			{
				ArrowNum = i;
				Arrow[i] = Arrowpool.NewItem();
				Arrow[i].transform.position = transform.position + transform.forward;
				Rigidbody r = Arrow[i].GetComponent<Rigidbody>();
				r.useGravity = false;
				r.velocity = new Vector3(0, 0, 0);
				break;
			}
			//5발 다쏘고 난다음도 생각해야함
		}
		Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(1, target, Hp/100.0f,3.0f);
		sound.PlayerSound(BossSoundSetting.BosssoundPack.AttackSkill);
	}
	void setTarget()
	{
		Hp = GetComponent<ObjectLife>().Hp;

	}
}
