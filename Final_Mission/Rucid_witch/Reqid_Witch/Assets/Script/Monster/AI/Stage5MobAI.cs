using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5MobAI: MonoBehaviour {
	MoveMsg msg;
	public int[] BasicPeace;
	public int[] BasicBattle;

	StagePosition Stage5Pos;
	ObjectLife ObjLife;
	NatureCommand NCommand;
	BattleCommand BCommand;
	Animator ani;

	MonsterSoundSetting MobSound;

	public float Time_Nature_Stop;		//0
	public float Time_Nature_Move;		//1
	public float Time_Nomal_StopMotion;	//2(Idle)
	public float Time_Nomal_MoveWay;	//3 사용자 지정위치로 이동(미구현)

	public float Time_Taget_Search;		//10
	public float Time_Battle_Move;		//11
	public float Time_Normal_Attack;    //12

	public float Die_Time = 1.0f;

	public bool Delay = false;
	public bool Fight = false;	//false;
	public bool isRange = false;	// 근거리 false 원거리true

	Queue Battle = null;
	Queue Peace = null;
	private Transform Player;
	void Start()
	{
		MobSound = GetComponentInChildren<MonsterSoundSetting>();
		MobSound.PlaySound(0);
		Time_Nature_Move = getRandom(1, 5);
		Time_Battle_Move = getRandom(1, 5);
		Stage5Pos = FindObjectOfType<StagePosition>().GetComponent<StagePosition>();
		ObjLife = GetComponent<ObjectLife>();
		ani = GetComponent<Animator>();
		NCommand = GetComponent<NatureCommand>();
		BCommand = GetComponent<BattleCommand>();
		Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

		//가져와서 적용해야 할 부분
		msg = new MoveMsg();
		//가져와서 적용해야 할 부분


		Battle = new Queue();
		Peace = new Queue();
		for (int i = 0; i<BasicPeace.Length ; ++i)
			Peace.Enqueue (BasicPeace [i]);
		for (int i = 0; i<BasicBattle.Length ; ++i)
			Battle.Enqueue (BasicBattle [i]);
		//while (Peace.Count > 0) {
		//	Debug.Log (Peace.Dequeue ());
		//}
		StartCoroutine("AISearching");
	}
	IEnumerator AISearching(){

		
		int num = 0;
		float time = 1.0f;
		float Limit = 0.0f;
		bool prevFight = false;
		//평화
		while (true)
		{
			if (ObjLife.Hp <= 0)
			{
				Targetting T;
				T = FindObjectOfType<Targetting>().GetComponent<Targetting>();
				Debug.Log(T);
				ani.SetBool("Die", true);

				MobSound.PlaySound(3);

				yield return new WaitForSeconds(Die_Time);
				this.gameObject.SetActive(false);
			}
			{
				if (Fight)
					NCommand.StateChange(true);
				else
					NCommand.StateChange(false);

				if (Fight != prevFight)
				{
					Limit = float.MaxValue;
				}
				if (Fight == false)
				{
					while (Peace.Count < 2)
					{
						num = getRandom(0, 3);
						Peace.Enqueue(num);
					}
				}
				//전투
				else
				{
					//전투중 AI 조건
					while (Battle.Count < 2)
					{
						if (Vector3.Distance(Player.position, this.gameObject.transform.position) <= ObjLife.Range)
							num = 12;
						else
							num = 11;
						Battle.Enqueue(num);
					}
				}

				if (Limit >= time)
				{
					Limit = 0.0f;
					if (!Fight)
						num = (int)Peace.Dequeue();//동작 처리시에 큐서 빠져나감
					else
					{
						//num = (int)Battle.Dequeue();//동작 처리시에 큐서 빠져나감

						if (Vector3.Distance(Player.position, this.gameObject.transform.position) <= ObjLife.Range)
							num = 12;
						else
							num = 11;
					}

			//	//	
			//	//실행할 동작 - 삭제할 부분
			//	Debug.Log(num);
			//	string temp;
			//	AITree.Instance.AIDic.TryGetValue(num, out temp);
			//	Debug.Log(temp);
			//	//실행할 동작 - 삭제할 부분

					switch (num)
					{
						case 0:
							{
								//ani.SetBool("Stop", true);
								ani.SetBool("IsMove", false);
								time = Time_Nature_Stop;
								break;
							}
						case 1:
							{
								ani.SetBool("Stop", false);
								ani.SetBool("IsMove", true);
								time = Time_Nature_Move;
								msg.time = time;
								msg.destination = Stage5Pos.GetRandomPos();
								msg.Speed = ObjLife.Speed;
								NCommand.NatureMove(msg);
								break;
							}
						case 2:
							{
								ani.SetBool("Stop", false);
								ani.SetBool("IsMove", false);
								time = Time_Nomal_StopMotion;
								break;
							}
						case 3:
							{
								time = Time_Nomal_MoveWay;
								break;
							}
						case 10:
							{

								time = Time_Taget_Search;
								break;
							}
						case 11:
							{
								ani.SetBool("Stop", false);
								ani.SetBool("IsMove", true);
								ani.SetBool("IsAttack", false);
								time = Time_Battle_Move;
								msg.time = time;
								msg.destination = Player.position;
								msg.Speed = ObjLife.BattleSpeed;
								BCommand.BattleMove(msg);
								break;
							}
						case 12:
							{
								ani.SetBool("Stop", false);
								ani.SetBool("IsMove", false);
								ani.SetBool("IsAttack", true);
								time = Time_Normal_Attack;
								BCommand.Attack(time,isRange);
								break;
							}
						default:
							time = 1.0f;
							break;
					}
					prevFight = Fight;
				}
				Limit += 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}
