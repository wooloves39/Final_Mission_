using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingMark : MonoBehaviour {
	public bool isCool = false;
	private Slider slider;
	private float MPGage;
	private PlayerState playerState;
	private SpriteRenderer spriteRenderer;
	private float CoolTime;
	public float CurCoolTime;
	private float deltaTime;
	//쿨타임 어딧는지 모름.
	// Use this for initialization
	private void Awake()
	{
		slider = GetComponentInChildren<Slider>();
		playerState = GetComponentInParent<PlayerState>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		deltaTime = Time.deltaTime;
		slider.value = 0;
	}
	public void CheckCoolTime(float time)
	{
		
		if (time > 0.0f)
		{
			isCool = true;
			CurCoolTime = time;
			StartCoroutine(SlideCool());
		}

	}
	public void setSkillData(float Mp, float coolTime)
	{
		MPGage = Mp;
		CoolTime = coolTime;
	}
	private void OnEnable()
	{
		if (playerState.Mp < MPGage) { StartCoroutine(MpLack()); }
	}
	private void OnDisable()
	{
		Color color = spriteRenderer.color;
		color.a = 1;
		spriteRenderer.color= color;
		slider.value = 0;
		CurCoolTime = 0.0f;
	}
	IEnumerator MpLack()
	{
		Color color = spriteRenderer.color;
		float Alpha = -10.0f;
		while(playerState.Mp < MPGage)
		{
			color.a += Alpha/255.0f;
			spriteRenderer.color = color;
			if (color.a <= 0.0f|| color.a >= 1.0f)
				Alpha *= -1;
			yield return null;
		}
	}
	IEnumerator SlideCool()
	{
		
		float timer = CurCoolTime;
		while (CurCoolTime <= CoolTime)
		{
			CurCoolTime += 0.1f;
			slider.value = CurCoolTime / CoolTime;
			yield return new WaitForSeconds(0.1f);
		}
		slider.value = 0;
	}
}
