using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
	public enum State { Nomal, Drawing, Charging, Attack, Damage, Talk, Die, ChargingOver, Pause }
    public bool Cheat = false;
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
	public GameObject chraging;
	private float recoveryTime = 3.0f;
	public float RecoveryTime { get { return recoveryTime; } set {recoveryTime=value; } }
	public GameObject PlayerHitEffect;
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

		fade = FindObjectOfType<OVRScreenFade>();
	}
	private void Update()
	{
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
	public int GetMyStateInt()
	{
		return (int)MyState;
	}
	public void SetMyState(State state)
	{
		MyState = state;
		if (MyState != State.Charging) {
			ChargingTime = 0.0f;
			chraging.SetActive(false); }
		else
		{
			chraging.SetActive(true);
		}

	}
	public float chargingRate()
	{
		return ChargingTime / MaxChargingTime;
	}
	public void SetMyState(State state, float time)
	{
		MyState = state;
		MaxChargingTime = time;
		if (MyState != State.Charging) { ChargingTime = 0.0f; chraging.SetActive(false); }
		else
		{
			chraging.SetActive(true);
		}

	}
	public void SetMyState(int state)
	{
		MyState = (State)state;
		if (MyState != State.Charging) { ChargingTime = 0.0f; chraging.SetActive(false); }
		else
		{
			chraging.SetActive(true);
		}
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
		for (int i = 0; i < 5 - checkHpFull; ++i)
		{
			HpMaterial[i].SetColor("_EmissionColor", HpColor * 0.0f);
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
		for (int i = 0; i < 5 - checkMpFull; ++i)
		{
			MpMaterial[i].SetColor("_EmissionColor", MpColor*0.0f);
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
		playerSound.PlayerSound(PlayerSoundSetting.soundPack.Defance);
		Hp -= Damage;
		PlayerHitEffect.SetActive(true);
		if (Hp <= 0)
		{
			playerSound.PlayerSound(PlayerSoundSetting.soundPack.Die);
			Hp = 0;
			MyState = State.Die;
			//죽는 사운드 필요
			GetComponent<SceneChange>().sceneChange("Ready", Color.red);
		}
		else if (!fade.fadeOnStart)
		{
			fade.fadeSmoth(new Color(.3f, 0, 0), 0, .5f, .3f, 1.0f, 0.5f);
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.2f, 1.0f-Hp / 100.0f, OVRInput.Controller.RTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.2f, 1.0f-Hp/100.0f, OVRInput.Controller.LTouch));
		}

        if (Cheat)
            Hp = 100;
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
			yield return new WaitForSeconds(recoveryTime);
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
			yield return new WaitForSeconds(recoveryTime);
		}
	}
	public void CharginTimeReset() { ChargingTime = 0.0f; }
}
