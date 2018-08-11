using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MplessImage : MonoBehaviour {
	private Image image;
	private Color imageColor;
	private void Awake()
	{
		image = GetComponent<Image>();
		imageColor = image.color;
	}
	private void OnEnable()
	{
		imageColor.a = 0.0f;
		image.color = imageColor;
		StopAllCoroutines();
		StartCoroutine(imageOn());
		}
	IEnumerator imageOn()
	{
		int count = 0;
		float ColorOver= 25.5f / 255.0f;
		while (true)
		{
			imageColor.a += ColorOver;
			if(imageColor.a>1.0f|| imageColor.a < 0.0f)
			{
				ColorOver = -ColorOver;
				++count;
				if (count == 6) break;
			}
			image.color = imageColor;
			yield return null;
		}
		gameObject.SetActive(false);
	}
}
