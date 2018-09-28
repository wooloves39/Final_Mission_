using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5Boss: MonoBehaviour {
	MoveMsg msg;
	public int[] BasicPeace;
	public int[] BasicBattle;

	StagePosition Stage5Pos;
	ObjectLife ObjLife;
	NatureCommand NCommand;
	BattleCommand BCommand;
	Animator ani;

	public float Time_Nature_Stop;		//0
	public float Time_Nature_Move;		//1
	public float Time_Nomal_StopMotion;	//2(Idle)
	public float Time_Nomal_MoveWay;	//3 사용자 지정위치로 이동(미구현)

	public float Time_Taget_Search;		//10
	public float Time_Battle_Move;		//11
    //public float Time_Normal_Attack;	//12
    public float Time_RunAway;     //13
    public float Time_AttackMove;      //14

	public float Time_Skill_1;		//20
	public float Time_Skill_2;		//21
	public float Time_Skill_3;		//22
	public float Time_Skill_4;		//23
	public float Time_Skill_5;		//24

	public float Die_Time = 2.0f;


    private int[] SkillValue = {0,25,50,75,100 }; 
    public float[] BossCoolTime = {0,9,12,15,100 };   
    public bool[] BossCoolDown = {false,false,false,false,false };      

	public bool Delay = false;
	public bool Fight = false;//false;
	public bool Ulti = false;
	Queue Battle = null;
	Queue Peace = null;
	private Transform Player;
    private bool run = false;
    private int AttackMove;
    private int AttackMoveNum;
	public bool Islive { get; set; }
	void Awake()
    {
        AttackMove = 0;
        AttackMoveNum = getRandom(9,17);
		Islive = true;
		Stage5Pos = FindObjectOfType<StagePosition>().GetComponent<StagePosition>();
		ObjLife = GetComponent<ObjectLife>();
		ani = GetComponent<Animator>();
		NCommand = GetComponent<NatureCommand>();
		BCommand = GetComponent<BattleCommand>();
		Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

		//가져와서 적용해야 할 부분
		msg = new MoveMsg();
		//가져와서 적용해야 할 부분

		if (Singletone.Instance.stage == 6)
		{
			Ulti = true;
			ObjLife.Hp = 300;
			ObjLife.MaxHp = 300;
		}
        if (Singletone.Instance.stage == 10)
        {
            Ulti = true;
            ObjLife.Hp = 250;
            ObjLife.MaxHp = 250;
        }

		Battle = new Queue();
		Peace = new Queue();
		for (int i = 0; i<BasicPeace.Length ; ++i)
			Peace.Enqueue (BasicPeace [i]);
		for (int i = 0; i<BasicBattle.Length ; ++i)
			Battle.Enqueue (BasicBattle [i]);
	}
    void OnEnable()
    {
        StartCoroutine(AISearching());
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
				ani.SetBool("Die", true);
				yield return new WaitForSeconds(Die_Time);
                if (Singletone.Instance.stage >= 6)
                {
                    this.gameObject.SetActive(false);
                }
				Islive = false;
				break;
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
					num = (int)Peace.Dequeue();
				else
				{
                    
                    if (AttackMove >= AttackMoveNum)
					{
                        if (!ani.GetCurrentAnimatorStateInfo(0).IsName("skill1") &&
                           !ani.GetCurrentAnimatorStateInfo(0).IsName("skill2") &&
                           !ani.GetCurrentAnimatorStateInfo(0).IsName("skill3") &&
                           !ani.GetCurrentAnimatorStateInfo(0).IsName("skill4") &&
                           !ani.GetCurrentAnimatorStateInfo(0).IsName("skill5"))
                        {
                            num = 14;
                            AttackMove = 0;
                            AttackMoveNum = getRandom(9, 17);
                            if (!run && Ulti)
                            {
                                if (AttackMoveNum == 15)//12.5%
                                {
                                    if (getRandom(0, 4) == 0)//3.125%로도망 = 주기 * 3.125%
                                    {
                                        run = true;
                                        num = 13;
                                    }
                                }
                            }
                        }

					}
					else
                    {
                        AttackMove++;
						if (Vector3.Distance(Player.position, this.gameObject.transform.position) <= ObjLife.Range)
						{
							int NUM = getRandom(0, 100);
							if (!Ulti && ObjLife.Hp <= ObjLife.MaxHp * 0.3)
							{
								num = 24;
							}
							else
							{
								if (SkillValue[0] <= NUM && NUM < SkillValue[1])
								{
									num = 20;
								}
								else if (SkillValue[1] <= NUM && NUM < SkillValue[2])
								{
									if (BossCoolDown[1])
										num = 20;
									else
										num = 21;
								}
								else if (SkillValue[2] <= NUM && NUM < SkillValue[3])
								{
									if (BossCoolDown[2])
										num = 20;
									else
										num = 22;
								}
								else
									if (BossCoolDown[3])
									num = 20;
								else
									num = 23;
							}
						}
						else
							num = 11;
					}
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
							ani.SetBool("IsMove", false);
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
                                    msg.destination = this.transform.position + this.transform.forward * -8;
                                    break;
                                case 1:
                                    msg.destination = this.transform.position + this.transform.right * 12;
                                    break;
                                case 2:
                                    msg.destination = this.transform.position + this.transform.right * -12;
                                    break;

                            }
                            msg.Speed = ObjLife.BattleSpeed;
                            BCommand.BattleMove(msg);
                            break;
                        }
					case 20:
						{
							ani.SetBool("Run", false);
							ani.SetBool("IsMove", false);
							//ani.SetBool("Skill1", true);
							time = Time_Skill_1;
							BCommand.Skill(time, 0);
							break;
						}
					case 21:
						{
							ani.SetBool("Run", false);
							ani.SetBool("IsMove", false);
							//ani.SetBool("Skill2", true);
							time = Time_Skill_2;
							BCommand.Skill(time, 1);
							break;
						}
					case 22:
                        {
							ani.SetBool("Run", false);
							ani.SetBool("IsMove", false);
							//ani.SetBool("Skill3", true);
							time = Time_Skill_3;
							BCommand.Skill(time, 2);
							break;
						}
					case 23:
                        {
							ani.SetBool("Run", false);
							ani.SetBool("IsMove", false);
							//ani.SetBool("Skill4", true);
							time = Time_Skill_4;
							BCommand.Skill(time, 3);
							break;
						}
					case 24:
						{
                            ani.SetBool("Run", false);
							ani.SetBool("IsMove", false);
							time = Time_Skill_5;
							BCommand.Skill(time, 4);
							break;
						}
					default:
						time = 1.0f;
						break;
				}
				prevFight = Fight;
			}
			Limit += 0.1f;
			yield return new WaitForSeconds (0.1f);
		}
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
    public void CoolTime(int num)
    {
        StartCoroutine("Cool", num);
    }
    IEnumerator Cool(int num)
    {
        BossCoolDown[num] = true;
        yield return new WaitForSeconds(BossCoolTime[num]);
        BossCoolDown[num] = false;

    }

}
