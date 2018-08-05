using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraAI : MonoBehaviour
{

	MoveMsg msg;
	public int[] BasicPeace;
	public int[] BasicBattle;

	StagePosition Stage5Pos;
	PlayerState playerstate;
	ObjectLife ObjLife;
	NatureCommand NCommand;
	BattleCommand BCommand;
	Animator ani;

	public float Time_Nature_Stop;      //0
	public float Time_Nature_Move;      //1
	public float Time_Nomal_StopMotion; //2(Idle)
	public float Time_Nomal_MoveWay;    //3 사용자 지정위치로 이동(미구현)

	public float Time_Taget_Search;     //10
	public float Time_Battle_Move;      //11
										//public float Time_Normal_Attack;  //12
	public float Time_RunAway;     //13
    public float Time_AttackMove;      //14
    public float Time_Chaging;      //14

	public float Time_Skill_1;      //20
	public float Time_Skill_2;      //21
	public float Time_Skill_3;      //22
	public float Time_Skill_4;      //23
	public float Time_Skill_5;      //24
	public float Time_Skill_6;      //25
    public float Time_Skill_7;      //26
    public float Time_Skill_8;      //27    체력 60%
    public float Time_Skill_9;      //28    체력 30%

	public float Die_Time = 2.0f;

	public float[] SkillValue = { 0,24,41,58,70,82,91,100}; // 24,17,17,12,12,9,9
	public float[] BossCoolTime = { 0, 6, 6, 12, 12, 21, 21 };
    public bool[] BossCoolDown = { false, false, false, false, false, false, false };

	public bool Delay = false;
	public bool Fight = false;//false;

    bool Ulti1 = false;
    bool Ulti2 = false;
    bool Chaging = false;

	Queue Battle = null;
	Queue Peace = null;
	private Transform Player;
    public GameObject[] Chage;

    private Stage7_end endingOn;
	void Awake()
	{
        endingOn = FindObjectOfType<Stage7_end>();
           Stage5Pos = FindObjectOfType<StagePosition>().GetComponent<StagePosition>();
		ObjLife = GetComponent<ObjectLife>();
		ani = GetComponent<Animator>();
		NCommand = GetComponent<NatureCommand>();
		BCommand = GetComponent<BattleCommand>();
		Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

		playerstate = Player.gameObject.GetComponentInParent<PlayerState>();
		//가져와서 적용해야 할 부분
		msg = new MoveMsg();
		//가져와서 적용해야 할 부분


		Battle = new Queue();
		Peace = new Queue();
		for (int i = 0; i < BasicPeace.Length; ++i)
			Peace.Enqueue(BasicPeace[i]);
		for (int i = 0; i < BasicBattle.Length; ++i)
			Battle.Enqueue(BasicBattle[i]);
		StartCoroutine("AISearching");
	}
	IEnumerator AISearching()
	{
		int num = 0;
		float time = 1.0f;
		float Limit = 0.0f;
		bool prevFight = false;
		//평화
		while (true)
		{
			if (playerstate.GetMyState() == PlayerState.State.Pause)
			{
				yield return null;
				ani.SetBool("Skill1", false);
				ani.SetBool("Skill2", false);
				ani.SetBool("Skill3", false);
				ani.SetBool("Skill4", false);
				ani.SetBool("Skill5", false);
				ani.SetBool("Skill6", false);
                ani.SetBool("Skill7", false);
                ani.SetBool("Skill8", false);
                ani.SetBool("Skill9", false);
			}
			if (ObjLife.Hp <= 0)
			{
				ani.SetBool("Die", true);
                endingOn.EndOn();
                yield return new WaitForSeconds(Die_Time);
				this.gameObject.SetActive(false);
			}

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
					num = getRandom(1, 3);
					Peace.Enqueue(num);
				}
			}
			//전투
			else
			{
				//전투중 AI 조건
				while (Battle.Count < 2)
				{
					{
						if (Vector3.Distance(Player.position, this.gameObject.transform.position) <= ObjLife.Range)
							num = 12;
						else
							num = 11;
						Battle.Enqueue(num);
					}
				}
			}

			if (Limit >= time)
			{
				Limit = 0.0f;

				if (!Fight)
					num = (int)Peace.Dequeue();
				else
				{

					if (Vector3.Distance(Player.position, this.gameObject.transform.position) <= ObjLife.Range)
					{
                        int NUM = getRandom(0, 100);
                        if (!Ulti1 && ObjLife.Hp <= ObjLife.MaxHp * 0.6)
                        {
                            num = 27;
                            Ulti1 = true;
                        }
						if (!Ulti2 && ObjLife.Hp <= ObjLife.MaxHp * 0.3)
						{
							num = 28;
							Ulti2 = true;
						}
						else
						{
							if ( NUM < SkillValue[1])
							{
								num = 20;
							}
							else
							{
								for (int i = 1; i < 7; ++i)
								{
									if (SkillValue[i] <= NUM && NUM < SkillValue[i + 1])
									{
										if (BossCoolDown[i])
										{
                                            if (!Chaging)
                                            {
                                                Chaging = true;
                                                num = 30;
                                            }
                                            else
                                            {
                                                Chaging = false;
                                                num = 20;
                                            }
										}
										else
											num = 20 + i;
									}
								}
							}
						}
					}
					else
						num = 11;
				}
				////실행할 동작 - 삭제할 부분
				//Debug.Log(num);
				//
				//string temp;
				//AITree.Instance.AIDic.TryGetValue(num, out temp);
				//Debug.Log(temp);
				////실행할 동작 - 삭제할 부분

				switch (num)
				{
					case 0:
						{
							ani.SetBool("Move", false);
							time = Time_Nature_Stop;
							break;
						}
					case 1:
						{
							ani.SetBool("Stop", false);
							ani.SetBool("Move", true);
							time = Time_Nature_Move;
							msg.time = time;
							msg.destination = Stage5Pos.GetRandomPos();
							msg.Speed = ObjLife.Speed;
							NCommand.NatureMove(msg);
							break;
						}
					case 2:
						{
							Fight = true;
							break;
						}
					case 3:
						{
							time = Time_Nomal_MoveWay;
							break;
						}
					case 10:
						{
							ani.SetBool("Run", false);
							time = Time_Taget_Search;
							break;
						}
					case 11:
						{
							ani.SetBool("Run", true);
							ani.SetBool("Move", false);
							time = Time_Battle_Move;
							msg.time = time;
							msg.destination = Player.position;
							msg.Speed = ObjLife.BattleSpeed;
							BCommand.BattleMove(msg);
							break;
						}
					case 12:
						{
							//ani.SetBool("IsMove", false);
							//ani.SetBool("IsAttack", true);
							//time = Time_Normal_Attack;
							//BCommand.Attack(time);
							break;
						}
					case 13:
						{
							ani.SetBool("Run", true);
							ani.SetBool("Move", false);
							time = Time_RunAway;
							msg.time = time;
							msg.destination = Stage5Pos.GetRandomPos();
							msg.Speed = ObjLife.BattleSpeed;
							BCommand.BattleMove(msg);
							break;
						}
					case 14:
						{
							ani.SetBool("Run", true);
							ani.SetBool("Move", false);
							time = Time_AttackMove;
							msg.time = time;
							int NUM = getRandom(0, 3);
							switch (NUM)
							{
								case 0:
									msg.destination = this.transform.position + this.transform.forward * -5;
									break;
								case 1:
									msg.destination = this.transform.position + this.transform.right * 7;
									break;
								case 2:
									msg.destination = this.transform.position + this.transform.right * -7;
									break;

							}
							msg.Speed = ObjLife.BattleSpeed;
							BCommand.BattleMove(msg);
							break;
						}
					case 20:
						{
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill1", true);
							time = Time_Skill_1;
							BCommand.Skill(time, 0);
							break;
						}
					case 21:
						{
							StartCoroutine("Coll", 1);
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill2", true);
							time = Time_Skill_2;
							BCommand.Skill(time, 1);
							break;
						}
					case 22:
						{
							StartCoroutine("Coll", 2);
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill3", true);
							time = Time_Skill_3;
							BCommand.Skill(time, 2);
							break;
						}
					case 23:
						{
							StartCoroutine("Coll", 3);
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill4", true);
							time = Time_Skill_4;
							BCommand.Skill(time, 3);
							break;
						}
					case 24:
						{
							StartCoroutine("Coll", 4);
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill5", true);
							time = Time_Skill_5;
							BCommand.Skill(time, 4);
							break;
						}
					case 25:
						{
							StartCoroutine("Coll", 5);
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill6", true);
							time = Time_Skill_6;
							BCommand.Skill(time, 5);
							break;
						}
					case 26:
						{
							StartCoroutine("Coll", 6);
							ani.SetBool("Run", false);
							ani.SetBool("Move", false);
							ani.SetBool("Skill7", true);
							time = Time_Skill_7;
							BCommand.Skill(time, 6);
							break;
						}

                    case 27:
                        {
                            ani.SetBool("Run", false);
                            ani.SetBool("Move", false);
                            ani.SetBool("Skill8", true);
                            time = Time_Skill_8;
                            BCommand.Skill(time, 7);
                            break;
                        }

                    case 28:
                        {
                            ani.SetBool("Run", false);
                            ani.SetBool("Move", false);
                            ani.SetBool("Skill9", true);
                            time = Time_Skill_9;
                            BCommand.Skill(time, 8);
                            break;
                        }

                    case 30:
                        {
                            ani.SetBool("Run", false);
                            ani.SetBool("Move", false);
                            time = Time_Chaging;
                            StartCoroutine("charge");
                            break;
                        }
					default:
						time = 1.0f;
						break;
				}
				prevFight = Fight;
			}
			Limit += 0.2f;
			yield return new WaitForSeconds(0.2f);
		}
	}
	int getRandom(int x, int y)
	{
		return Random.Range(x, y);
	}
	IEnumerator Coll(int num)
	{
		BossCoolDown[num] = true;
		yield return new WaitForSeconds(BossCoolTime[num]);
		BossCoolDown[num] = false;

	}
    IEnumerator charge()
    {

        this.transform.LookAt(Player.transform.position);
        int num = getRandom(0, 4);
        Chage[num].SetActive(true);
        yield return new WaitForSeconds(Time_Chaging);
        Chage[num].SetActive(false);
    }
}
