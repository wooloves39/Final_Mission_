using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingMark : MonoBehaviour {
	public bool isCool = false;
	private Slider slider;
	public float MPGage;
	private PlayerState playerState;
	private SpriteRenderer spriteRenderer;
	//쿨타임 어딧는지 모름.
	// Use this for initialization
	private void Awake()
	{
		slider = GetComponentInChildren<Slider>();
		playerState = GetComponentInParent<PlayerState>();
		spriteRenderer = GetComponent<SpriteRenderer>();
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
}
