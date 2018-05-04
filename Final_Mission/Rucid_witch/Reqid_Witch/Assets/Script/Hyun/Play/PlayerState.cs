using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
	public enum State { Nomal, Drawing, Charging, Attack, Damage, Talk, Die, ChargingOver }

	private State MyState;
	private float ChargingTime;
	private bool back;
	public float Hp = 100;
	public float Mp = 100;
	public Material[] HpMaterial;
	private Color HpColor;
	public Material[] MpMaterial;
	private Color MpColor;
	private Viberation PlayerViberation;
	private float MaxChargingTime;
	//이게 최선일까...
	public SkillChange skillChange;
	private OVRScreenFade fade;

	private PlayerSoundSetting playerSound;
	public bool LightningBolt;
	// Use this for initialization
	void Awake()
	{
		playerSound = GetComponent<PlayerSoundSetting>();
		LightningBolt = false;
		HpColor = Color.red;
		MyState = State.Nomal;
		ChargingTime = 0.0f;
		StartCoroutine(HpRecovery());
		StartCoroutine(MpRecovery());
		PlayerViberation = gameObject.transform.GetComponent<Viberation>();
	}
	void Start()
	{
		fade = FindObjectOfType<OVRScreenFade>();
		Debug.Log(fade);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A)) Mp -= 5;
		if (Input.GetKeyDown(KeyCode.S)) Hp -= 5;
		if (MyState == State.Charging)
		{
			ChargingTime += Time.deltaTime;
		}
		if (ChargingTime > MaxChargingTime)
		{
			Debug.Log("챠징오버");
			//스킬 실패 기초안
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.5f, 1.0f, OVRInput.Controller.RTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.5f, 1.0f, OVRInput.Controller.LTouch));
			SetMyState(State.ChargingOver);
		}
		CheckHp();
		CheckMp();
	}
	public void Back(bool val) { back = val; }
	public void Back() { back = !back; }
	public bool IsBack()
	{
		return back;
	}
	// Update is called once per frame
	public State GetMyState()
	{
		return MyState;
	}
	public void SetMyState(State state)
	{
		MyState = state;
		if (state != State.Charging) ChargingTime = 0.0f;

	}
	public void SetMyState(State state, float time)
	{
		MyState = state;
		MaxChargingTime = time;
		if (state != State.Charging) ChargingTime = 0.0f;

	}
	public void SetMyState(int state)
	{
		MyState = (State)state;
	}
	public float GetHp()
	{
		return Hp;
	}
	public float GetMp()
	{
		return Mp;
	}
	private void CheckHp()
	{
		int checkHpFull = (int)(Hp / 10);
		checkHpFull = (int)Mathf.Floor(checkHpFull / 2);
		for (int i = 4; i >= 5 - checkHpFull; --i)
		{
			HpMaterial[i].SetColor("_EmissionColor", HpColor);
		}
		int checkHpSub = (int)Hp - checkHpFull * 20;

		if (Hp < 100)
		{
			if (checkHpSub < 15 && checkHpSub > 5)
			{
				HpMaterial[4 - checkHpFull].SetColor("_EmissionColor", HpColor * 0.5f);
			}
			else if (checkHpSub >= 15)
			{
				HpMaterial[4 - checkHpFull].SetColor("_EmissionColor", HpColor);
			}
			else
			{
				HpMaterial[4 - checkHpFull].SetColor("_EmissionColor", HpColor * 0.0f);
			}
		}
	}
	private void CheckMp()
	{
		MpColor = skillChange.getMpColor();
		int checkMpFull = (int)(Mp / 10);
		checkMpFull = (int)Mathf.Floor(checkMpFull / 2);
		for (int i = 4; i >= 5 - checkMpFull; --i)
		{
			MpMaterial[i].SetColor("_EmissionColor", MpColor);
		}
		int checkMpSub = (int)Mp - checkMpFull * 20;

		if (Mp < 100)
		{
			if (checkMpSub < 15 && checkMpSub > 5)
			{
				MpMaterial[4 - checkMpFull].SetColor("_EmissionColor", MpColor * 0.5f);
			}
			else if (checkMpSub >= 15)
			{
				MpMaterial[4 - checkMpFull].SetColor("_EmissionColor", MpColor);
			}
			else
			{
				MpMaterial[4 - checkMpFull].SetColor("_EmissionColor", MpColor * 0.0f);
			}
		}
	}
	public void DamageHp(float Damage)
	{
		if (!fade.fadeOnStart)
		{
			fade.fadeSmoth(new Color(.3f, 0, 0), 0, .5f, .3f, 1.0f, 0.5f);
		}
		playerSound.PlayerSound(PlayerSoundSetting.soundPack.Defance);
		Hp -= Damage;
		if (Hp < 0)
			Hp = 0;
		if (Hp <= 0)
		{
			playerSound.PlayerSound(PlayerSoundSetting.soundPack.Die);
			Hp = 0;
			MyState = State.Die;
		}
	}
	public void ConsumeMp(float Consume)
	{
		if (Mp < Consume)
		{
			Debug.Log("스킬 실패, MP부족");
			playerSound.PlayerSound(PlayerSoundSetting.soundPack.MPmiss);
		}

		else
			Mp -= Consume;
	}
	private IEnumerator HpRecovery()
	{
		while (true)
		{
			if (MyState != State.Talk)
			{
				if (Hp <= 100.0f)
				{
					++Hp;
				}
				else
				{
					Hp = 100.0f;
				}
			}
			yield return new WaitForSeconds(3.0f);
		}
	}
	private IEnumerator MpRecovery()
	{
		while (true)
		{
			if (MyState != State.Talk)
			{
				if (Mp <= 100.0f)
				{
					++Mp;
				}
				else
				{
					Mp = 100.0f;
				}
			}
			yield return new WaitForSeconds(3.0f);
		}
	}
	public void CharginTimeReset() { ChargingTime = 0.0f; }
}
