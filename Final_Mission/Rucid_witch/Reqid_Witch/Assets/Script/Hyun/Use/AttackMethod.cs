using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMethod : MonoBehaviour
{

	private PlayerSoundSetting playerSound;
	//0이 왼손 1이 오른손
	public GameObject[] Hands;


	//#2번 공격
	public GameObject SweetMelody;
	public DellHeadTracker HeadTracker;
	public FirstTouch Dell_First;
	public SecondTouch Dell_Second;

	public GameObject DellAttackObjPrefab;
	MemoryPool Dellpool = new MemoryPool();
	GameObject[] DellAttackObj;
	//#1,3번 공격
	public GameObject[] Beejae_Marker;
	public GameObject[] Verbash_Controller;
	//#0번 공격
	private TouchCollision[] AzuraHands;
	public GameObject AzuraBallPrefab;
	MemoryPool Azurapool = new MemoryPool();
	GameObject[] AzuraBall;
	int AzuraBallNum = new int();
	//#4번 공격 다른 공격방식과 다르게 메모리 풀을 활용한다 최대 5발!
	public GameObject ArrowPrefab;
	MemoryPool Arrowpool = new MemoryPool();
	GameObject[] Arrow;

    public GameObject BeejaePrefab;
	public float RayLength = 50f;
	private Coroutine currentCorutine;
	private bool flug = false;
	public bool Flug { get { return flug; } set { flug = value; } }
	private Transform camTr;
	private Quaternion MarkerRotate;
	private PlayerState MyState;
	private Viberation PlayerViberation;
	public Targetting PlayerTarget;
	private LineDraw typecheck;
	// Use this for initialization
	private void Awake()
	{
		playerSound = GetComponent<PlayerSoundSetting>();
		MyState = GetComponent<PlayerState>();
		PlayerViberation = GetComponent<Viberation>();
		camTr = Camera.main.transform;
		MarkerRotate = Beejae_Marker[0].transform.rotation;
		AzuraHands = new TouchCollision[2];
		AzuraHands[0] = Hands[0].GetComponent<TouchCollision>();
		AzuraHands[1] = Hands[1].GetComponent<TouchCollision>();
		typecheck = GetComponentInChildren<LineDraw>();

		if (typecheck.IsHaveSkill(2))
		{
			Instantiate(BeejaePrefab);
		}
		if (typecheck.IsHaveSkill(0))
		{
			int poolCount = 5;
			Azurapool.Create(AzuraBallPrefab, poolCount);
			AzuraBall = new GameObject[poolCount];
			for (int i = 0; i < AzuraBall.Length; ++i)
				AzuraBall[i] = null;
		}
		if (typecheck.IsHaveSkill(1))
		{
			int poolCount = 5;
			Arrowpool.Create(ArrowPrefab, poolCount);
			Arrow = new GameObject[poolCount];
			for (int i = 0; i < Arrow.Length; ++i)
				Arrow[i] = null;
		}
		if (typecheck.IsHaveSkill(4))
		{
			int poolCount = 5;
			Dellpool.Create(DellAttackObjPrefab, poolCount);
			DellAttackObj = new GameObject[poolCount];
			for (int i = 0; i < DellAttackObj.Length; ++i)
				DellAttackObj[i] = null;
		}
	}
	private void OnApplicationQuit()
	{
		Azurapool.Dispose();
		Arrowpool.Dispose();
		Dellpool.Dispose();
	}
	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.LTriggerOn() && InputManager_JHW.RTriggerOn())
		{
			if (MyState.GetMyState() == PlayerState.State.Nomal)
			{
				MyState.SetMyState(PlayerState.State.Attack);
				if (currentCorutine == null)
				{
					flug = true;
					switch (LineDraw.curType)
					{
						case 0://아즈라 공격 형태 기를 모으는 형태, 오큘러스 터치의 충돌에서 출발하여 양손을 벌릴때 점차 커지며 방출
							{
								currentCorutine = StartCoroutine(AzuraControll());
							}
							break;
						case 1:// 화살의 형태 화살을 장전한채로 트리거를 누르고 있을 시 기를 모아 방출
							{
								currentCorutine = StartCoroutine(SeikwanControll());
							}
							break;
						case 2://전격 공격, 총알 발사 형태, 몬스터를 타겟하여 전격을 발사 형태, 저격 된 상태에서 기를 모아 방출
							{
								currentCorutine = StartCoroutine(BeejaeControll());
							}
							break;
						case 3:// 양 컨트롤러의 포인터가 맞춰졌을대 발동, 트리거를 계속 on하면 기를 모아 방출 베르베시
							{
								currentCorutine = StartCoroutine(VerbaseControll());
							}
							break;
						case 4://바이올린 상태 전체 공격 위주, 한정된 시간에 여러번 좌우 이동을 통해 차징 공격
							{
								currentCorutine = StartCoroutine(DellControll());
							}
							break;

					}
				}
			}
		}
		else if ((!InputManager_JHW.RTriggerOn() && !InputManager_JHW.LTriggerOn()) && flug)
		{

			flug = false;
			MyState.SetMyState(PlayerState.State.Nomal);
			SettingOff();

		}
		if (MyState.GetMyState() == PlayerState.State.ChargingOver)
		{
			SettingOff();
		}
		if (LineDraw.curType == 1)
		{
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
		else if (LineDraw.curType == 0)
		{
			for (int i = 0; i < AzuraBall.Length; ++i)
			{
				if (AzuraBall[i])
				{

					if (AzuraBall[i].GetComponent<AzuraSkill>().IsDelete())
					{
						AzuraBall[i].GetComponent<AzuraSkill>().resetDelete();
						Azurapool.RemoveItem(AzuraBall[i]);
						AzuraBall[i] = null;
					}
					//어떤 조건에 의거 AzuraBall삭제
				}
			}
		}
		else if (LineDraw.curType == 4)
		{
			for (int i = 0; i < DellAttackObj.Length; ++i)
			{
				if (DellAttackObj[i])
				{

					if (DellAttackObj[i].GetComponent<DellSkill>().IsDelete())
					{
						DellAttackObj[i].GetComponent<DellSkill>().resetDelete();
						Dellpool.RemoveItem(DellAttackObj[i]);
						DellAttackObj[i] = null;
					}
					//어떤 조건에 의거 AzuraBall삭제
				}
			}
		}
	}
    public void DeleteObj(int num)
    {
        if (num == 0)
        {
            for (int i = 0; i < AzuraBall.Length; ++i)
            {
                if (AzuraBall[i])
                {
                        AzuraBall[i].GetComponent<AzuraSkill>().resetDelete();
                        Azurapool.RemoveItem(AzuraBall[i]);
                        AzuraBall[i] = null;
                }
            }
        }
     else   if (num == 1)
        {
            for (int i = 0; i < Arrow.Length; ++i)
            {
                if (Arrow[i])
                {
                        Arrow[i].GetComponent<SeiKwanSkill>().resetDelete();
                        Arrowpool.RemoveItem(Arrow[i]);
                        Arrow[i] = null;
                }
            }
        }
        else if (num == 4)
        {
            for (int i = 0; i < DellAttackObj.Length; ++i)
            {
                if (DellAttackObj[i])
                {
                        DellAttackObj[i].GetComponent<DellSkill>().resetDelete();
                        Dellpool.RemoveItem(DellAttackObj[i]);
                        DellAttackObj[i] = null;
                }
            }
        }
    }
	private IEnumerator BeejaeControll()
	{
		int layerMask = (-1) - (1 << LayerMask.NameToLayer("UserSkill"));

		//왼손
		while (flug)
		{
			Ray ray = new Ray(Hands[0].transform.position, Hands[0].transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, RayLength,layerMask))
			{
				Debug.Log(hit.collider.tag);
				Debug.Log(hit.collider.gameObject.name);
				if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Monster"))
				{
					if (!Beejae_Marker[0].activeSelf)
					{
						Beejae_Marker[0].SetActive(true);
					}
					Vector3 point = hit.point;
					point.y += 0.4f;
					Beejae_Marker[0].transform.LookAt(camTr.position);
					Beejae_Marker[0].transform.Rotate(90, 0, 0);
					Beejae_Marker[0].transform.position = point;
				}

			}
			//오른손
			ray = new Ray(Hands[1].transform.position, Hands[1].transform.forward);
			if (Physics.Raycast(ray, out hit, RayLength, layerMask))
			{
				if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Monster"))
				{
					if (!Beejae_Marker[1].activeSelf)
					{
						Beejae_Marker[1].SetActive(true);
					}
					Vector3 point = hit.point;
					point.y += 0.4f;
					Beejae_Marker[1].transform.LookAt(camTr.position);
					Beejae_Marker[1].transform.Rotate(90, 0, 0);
					Beejae_Marker[1].transform.position = point;
				}
			}
			yield return null;
		}
	}
	private IEnumerator AzuraControll()
	{
		Vector3 AttackPoint = (AzuraHands[0].transform.position + AzuraHands[1].transform.position) / 2;
		AttackPoint += Camera.main.transform.forward * 0.1f;
		bool instance = false;
		float distance = 0.0f;
		Vector3 AzuraScale = AzuraBallPrefab.transform.localScale;

		while (flug)
		{
			if (!instance && (AzuraHands[0].GetTouch() || AzuraHands[1].GetTouch()))
			{
				instance = true;
				for (int i = 0; i < AzuraBall.Length; ++i)
				{
					if (AzuraBall[i] == null)
					{
						AzuraBallNum = i;
						AzuraBall[i] = Azurapool.NewItem();
						AzuraBall[i].transform.position = AttackPoint;
						Rigidbody r = AzuraBall[i].GetComponent<Rigidbody>();
						r.useGravity = false;
						r.velocity = new Vector3(0, 0, 0);
						break;
					}
					//5발 다쏘고 난다음도 생각해야함
				}
				MyState.SetMyState(PlayerState.State.Charging, typecheck.Skills[0].GetSkillChargingTime());
			}
			else if (instance)
			{
				float handDis = Vector3.Distance(Hands[0].transform.position, Hands[1].transform.position);
				if (handDis > distance)
				{
					distance = handDis;
					Vector3 Azura = new Vector3(distance * 4.0f, distance * 4.0f, distance * 4.0f);
					AzuraBall[AzuraBallNum].transform.localScale = Azura;
				}

			}
			//yield return null;
			yield return new WaitForSeconds(0.03f);
		}
	}
	private IEnumerator SeikwanControll()
	{
		bool instance = false;
		float distance = 0.0f;
		Vector3 Seikwan = ArrowPrefab.transform.localScale;
		int ArrowNum = new int();
		while (flug)
		{
			if (!instance && (AzuraHands[0].GetTouch() || AzuraHands[1].GetTouch()) &&
				(InputManager_JHW.LTriggerOn() && InputManager_JHW.RTriggerOn()))
			{
				instance = true;
				for (int i = 0; i < Arrow.Length; ++i)
				{
					if (Arrow[i] == null)
					{
						ArrowNum = i;
						Arrow[i] = Arrowpool.NewItem();
						Arrow[i].transform.position = Hands[0].transform.position;
						Rigidbody r = Arrow[i].GetComponent<Rigidbody>();
						r.useGravity = false;
						r.velocity = new Vector3(0, 0, 0);
						break;
					}
					//5발 다쏘고 난다음도 생각해야함
				}
				MyState.SetMyState(PlayerState.State.Charging, typecheck.Skills[1].GetSkillChargingTime());
			}
			else if (instance)
			{
				float handDis = Vector3.Distance(Hands[0].transform.position, Hands[1].transform.position);
				if ((!InputManager_JHW.RTriggerOn() && InputManager_JHW.LTriggerOn()))
				{
					if (!Arrow[ArrowNum].GetComponent<SeiKwanSkill>().IsShoot())
					{
						//Rigidbody r = Arrow[ArrowNum].GetComponent<Rigidbody>();
						//Vector3 Arrowforward = Arrow[ArrowNum].transform.forward;
						GameObject myTarget = PlayerTarget.getMytarget();
						//Vector3 TargettingDir = Vector3.zero;
						if (myTarget != null)
						{
							playerSound.PlayerSound(PlayerSoundSetting.soundPack.AttackSkill);
							Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(typecheck.Skills[1].getCurrentSkill(), myTarget, handDis,MyState.chargingRate());

						}
						else
						{
							if (typecheck.Skills[1].getCurrentSkill() < 3)
							{
								playerSound.PlayerSound(PlayerSoundSetting.soundPack.AttackSkill);
								Arrow[ArrowNum].GetComponent<SeiKwanSkill>().shoot(typecheck.Skills[1].getCurrentSkill(), myTarget, handDis, MyState.chargingRate());
							}
							else
							{
								Arrow[ArrowNum].GetComponent<SeiKwanSkill>().resetDelete();
								Arrowpool.RemoveItem(Arrow[ArrowNum]);
								Arrow[ArrowNum] = null;
							}
						}

						instance = false;
						distance = 0.0f;
						MyState.CharginTimeReset();
					}
				}
				else
				{
					Vector3 ArrowPos = (Hands[0].transform.position + Hands[1].transform.position) / 2;
					Vector3 LookAtpos = Hands[0].transform.position;
					if (!MyState.IsBack())
					{
						if (Hands[0].transform.localPosition.x < 0)
						{
							LookAtpos.z -= 0.06f;
						}
						else
						{
							LookAtpos.z += 0.06f;
						}
					}
					else
					{
						if (Hands[0].transform.localPosition.x < 0)
						{
							LookAtpos.z += 0.06f;
						}
						else
						{
							LookAtpos.z -= 0.06f;
						}

					}

					ArrowPos += Hands[0].transform.forward * 0.05f;
					Arrow[ArrowNum].transform.LookAt(LookAtpos);
					Arrow[ArrowNum].transform.position = ArrowPos;

					if (handDis > distance)
					{
						distance = handDis;
						Seikwan.z = distance * 10;
						Arrow[ArrowNum].transform.localScale = Seikwan;
					}
				}
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
	private IEnumerator VerbaseControll()
	{
		Verbash_Controller[0].SetActive(true);
		Verbash_Controller[1].SetActive(true);
		while (LineDraw.curType == 3)
		{
			yield return new WaitForSeconds(0.03f);
		}
		Verbash_Controller[0].SetActive(false);
		Verbash_Controller[1].SetActive(false);

	}
	private IEnumerator DellControll()
	{
		bool instance = false;
		bool attacking = false;
		float attackTimer = 0.0f;
		float deltaTime = Time.deltaTime;
		int skillIndex = typecheck.Skills[4].getCurrentSkill();
		int chargingCount = 0;
		int DellNum;
		
		while (flug)
		{
			if (HeadTracker.getHeadOn())
			{
				instance = true;
				if (skillIndex == 1)
				{
					SweetMelody.SetActive(true);
				}
				else if (skillIndex == 4)
				{
					MyState.SetMyState(PlayerState.State.Charging, 9.0f);
				}
			}
			else
			{
				if (instance)
				{
					SweetMelody.SetActive(false);
					Debug.Log("델 해드에서 떨어짐");
					PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.5f, 1.0f, OVRInput.Controller.RTouch));
					PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.5f, 1.0f, OVRInput.Controller.LTouch));
					instance = false;
					break;
				}
				instance = false;
			}
			if (instance)
			{
				attackTimer += deltaTime;
				if (!attacking)
				{
					if (Dell_First.Touch)
					{
						PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.3f, 0.3f, OVRInput.Controller.RTouch));
						attacking = true;
						attackTimer = 0.0f;
					}
				}
				else
				{
					if (Dell_Second.Touch)
					{
						PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.3f, 0.3f, OVRInput.Controller.RTouch));
						++chargingCount;
						Debug.Log("델 카운트 "+chargingCount);
						attacking = false;
						attackTimer = 0.0f;
					}
				}
				if (skillIndex == 4)
				{
					if ((!InputManager_JHW.RTriggerOn() && InputManager_JHW.LTriggerOn()))
					{
						GameObject myTarget = PlayerTarget.getMytarget();
						if (myTarget != null)
						{
							DellNum = 0;
							for (int i = 0; i < DellAttackObj.Length; ++i)
							{
								if (DellAttackObj[i] == null)
								{
									DellNum = i;
									DellAttackObj[i] = Dellpool.NewItem();
									DellAttackObj[i].transform.position = transform.position;
									break;
								}
							}
							DellAttackObj[DellNum].GetComponent<DellSkill>().shoot(chargingCount, myTarget,MyState.chargingRate());
							chargingCount = 0;
						}
					}
				}
				if (attackTimer > 4.0f)
				{
					SweetMelody.SetActive(false);
					Debug.Log("델 스킬 종료");
					PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.5f, 1.0f, OVRInput.Controller.RTouch));
					PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.5f, 1.0f, OVRInput.Controller.LTouch));
					break;
				}
			}
			yield return new WaitForSeconds(0.01f);
		}

	}
	public void Charging(float time)
	{
		MyState.SetMyState(PlayerState.State.Charging, time);
	}
	private void SettingOff()
	{
		if (currentCorutine != null)
		{
			StopCoroutine(currentCorutine);
		}
		switch (LineDraw.curType)
		{
			case 0://아즈라 공격 형태 기를 모으는 형태, 오큘러스 터치의 충돌에서 출발하여 양손을 벌릴때 점차 커지며 방출
				{
					float handDis = Vector3.Distance(Hands[0].transform.position, Hands[1].transform.position);
					if (AzuraBall[AzuraBallNum] && MyState.GetMyState() != PlayerState.State.ChargingOver)
					{
						if (!AzuraBall[AzuraBallNum].GetComponent<AzuraSkill>().IsShoot())
						{
							GameObject myTarget = PlayerTarget.getMytarget();
							if (myTarget != null)
							{
								playerSound.PlayerSound(PlayerSoundSetting.soundPack.AttackSkill);
								AzuraBall[AzuraBallNum].GetComponent<AzuraSkill>().shoot(typecheck.Skills[0].getCurrentSkill(), myTarget, handDis,MyState.chargingRate());
							}
						}
					}
					for (int i = 0; i < AzuraBall.Length; ++i)
					{
						if (AzuraBall[i])
						{
							if (!AzuraBall[i].GetComponent<AzuraSkill>().IsShoot())
							{
								AzuraBall[i].GetComponent<AzuraSkill>().resetDelete();
								Azurapool.RemoveItem(AzuraBall[i]);
								AzuraBall[i] = null;
							}
							//어떤 조건에 의거 Arrow삭제
						}
					}
				}
				break;
			case 1:// 화살의 형태 화살을 장전한채로 트리거를 누르고 있을 시 기를 모아 방출
				{
					for (int i = 0; i < Arrow.Length; ++i)
					{
						if (Arrow[i])
						{
							if (!Arrow[i].GetComponent<SeiKwanSkill>().IsShoot())
							{
								Arrow[i].GetComponent<SeiKwanSkill>().resetDelete();
								Arrowpool.RemoveItem(Arrow[i]);
								Arrow[i] = null;
							}
							//어떤 조건에 의거 Arrow삭제
						}
					}
				}
				break;
			case 2://전격 공격, 총알 발사 형태, 몬스터를 타겟하여 전격을 발사 형태, 저격 된 상태에서 기를 모아 방출
				{
					Beejae_Marker[0].transform.rotation = MarkerRotate;
					Beejae_Marker[1].transform.rotation = MarkerRotate;
					Beejae_Marker[0].SetActive(false);
					Beejae_Marker[1].SetActive(false);
				}
				break;
			case 3:// 양 컨트롤러의 포인터가 맞춰졌을대 발동, 트리거를 계속 on하면 기를 모아 방출
				{
				}
				break;
			case 4: //바이올린 상태 전체 공격 위주, 한정된 시간에 여러번 좌우 이동을 통해 차징 공격
				{
					SweetMelody.SetActive(false);
					for (int i = 0; i < DellAttackObj.Length; ++i)
					{
						if (DellAttackObj[i])
						{
							if (!DellAttackObj[i].GetComponent<DellSkill>().IsShoot())
							{
								DellAttackObj[i].GetComponent<DellSkill>().resetDelete();
								Dellpool.RemoveItem(DellAttackObj[i]);
								DellAttackObj[i] = null;
							}
						}
					}
				}
				break;
		}
		currentCorutine = null;
	}
}
