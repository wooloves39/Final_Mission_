using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwanMonControll : MonoBehaviour {

    BossEffectControler Eff;
	public GameObject ArrowPrefab;
	MemoryPool Arrowpool = new MemoryPool();
	GameObject[] Arrow;
	private GameObject target;
	private float Hp;
	private BossSoundSetting sound;
	public GameObject skill4;
    private Stage5Boss AI;
	// Use this for initialization
    private void Start()
    {
        target = GetComponent<BattleCommand>().getTarget();
    }
	private void Awake()
	{
        Eff = GetComponentInChildren<BossEffectControler>();
        AI = GetComponent<Stage5Boss>();
		sound = GetComponent<BossSoundSetting>();
		Hp = GetComponent<ObjectLife>().Hp;
		int poolCount = 5;
		Arrowpool.Create(ArrowPrefab, poolCount);
		Arrow = new GameObject[poolCount];
        
		for (int i = 0; i < Arrow.Length; ++i)
        {
            Arrowpool.GetItem(i).GetComponent<SeiKwanSkill>().MonsterAttack = true;
			Arrow[i] = null;
        }
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
				if (Arrow[i].GetComponent<SeiKwanSkill>().Del_timer)
				{
					Arrow[i].GetComponent<SeiKwanSkill>().resetDelete();
					Arrowpool.RemoveItem(Arrow[i]);
					Arrow[i] = null;
				}
				//어떤 조건에 의거 Arrow삭제
			}
		}
	}
    void Hit()
    {
        Eff.EffSet(2);
        sound.PlayerSound(BossSoundSetting.BosssoundPack.Defance);
    }
    void Appier()
    {
        sound.PlayerSound(0);
    }
    void Lose_Sound()
    {
        sound.PlayerSound(3);
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
				Vector3 initPos =transform.position;
				initPos.y += 1.0f;
				Arrow[i].transform.position = initPos;
				break;
			}
			//5발 다쏘고 난다음도 생각해야함
		}
		Vector3 shootPos = target.transform.position;
		shootPos.y += 1.0f;
		Arrow[ArrowNum].transform.LookAt(shootPos);
		Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(1, target, Hp/250.0f, 5.0f);
		sound.PlayerSound(BossSoundSetting.BosssoundPack.AttackSkill);
	}
	void Attack2()
    {
        AI.CoolTime(1);
		int ArrowNum = 0;
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
				Vector3 initPos = transform.position;
				initPos.y += 1.0f;
				Arrow[i].transform.position = initPos;
				break;
			}
			//5발 다쏘고 난다음도 생각해야함
		}
		Vector3 shootPos = target.transform.position;
		shootPos.y += 1.0f;
		Arrow[ArrowNum].transform.LookAt(shootPos);
		Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(2, target, Hp / 500.0f,5.0f);
		sound.PlayerSound(BossSoundSetting.BosssoundPack.AttackSkill);
	}
	void Attack3()
    {
        AI.CoolTime(2);
		int ArrowNum = 0;
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
				Vector3 initPos = transform.position;
				initPos.y += 1.0f;
				Arrow[i].transform.position = initPos;
				break;
			}
			//5발 다쏘고 난다음도 생각해야함
		}
		Vector3 shootPos = target.transform.position;
		shootPos.y += 1.0f;
		Arrow[ArrowNum].transform.LookAt(shootPos);
		Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(3, target, Hp / 1000.0f, 5.0f);
		sound.PlayerSound(BossSoundSetting.BosssoundPack.AttackSkill);
	}
	void Attack4()
    {
        AI.CoolTime(3);
		skill4.SetActive(true);
	
	}
	void Attack5()
    {
        AI.CoolTime(4);
        AI.Ulti = true;
		int ArrowNum = 0;
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
				Vector3 initPos = transform.position;
				initPos.y += 1.0f;
				Arrow[i].transform.position = initPos;
				break;
			}
			//5발 다쏘고 난다음도 생각해야함
		}
		Vector3 shootPos = target.transform.position;
		shootPos.y += 1.0f;
		Arrow[ArrowNum].transform.LookAt(shootPos);
		Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(5, target, Hp / 1000.0f*10, 5.0f);
		sound.PlayerSound(4);
	}
	void setTarget()
    {
        Eff.EffSet(0);
        Hp = GetComponent<ObjectLife>().Hp;

	}
}
