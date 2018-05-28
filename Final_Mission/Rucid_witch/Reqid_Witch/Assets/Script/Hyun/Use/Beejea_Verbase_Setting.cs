﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beejea_Verbase_Setting : MonoBehaviour {

	public GameObject berbash;
	public GameObject beejae;
	public bool lefthand = false;
	private BeejaeSkill Bskill;
	public VerbashSkill Vskill;
	private Image PointImage;
	private Color cur_Color;//평소
	private Color touch_Color;//점끼리 마주쳤을때
	public bool isTouch = false;
	// Use this for initialization
	private void Awake()
	{
		Bskill = FindObjectOfType<BeejaeSkill>();
		PointImage = gameObject.transform.GetComponentInChildren<Image>();
		cur_Color = PointImage.color;
		touch_Color = new Color(0, 0, 0);
	}
	private void OnEnable()
	{
		isTouch = false;
	}
	private void Update()
	{
		if (isTouch)
		{
			PointImage.color = touch_Color;
		}
		else
		{
			PointImage.color = cur_Color;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		switch (LineDraw.curType)
		{
			case 2:
				{
					if (other.gameObject.CompareTag("Monster"))
					{
						Bskill.SetTarget(other.gameObject.GetComponentInParent<ObjectLife>().gameObject);
						Bskill.handle2 = true;

						isTouch = true;
					}
				}
				break;
			case 3:
				{
					if (other.gameObject.CompareTag("Monster"))
					{
						Vskill.SetTarget(other.gameObject.GetComponentInParent<ObjectLife>().gameObject);
						Vskill.handle2 = true;

						isTouch = true;
					}
				}
				break;
		}

	}
	private void OnTriggerExit(Collider other)
	{
		switch (LineDraw.curType)
		{
			case 2:
				{
					if (other.gameObject.CompareTag("Monster"))
					{
						Bskill.handle2 = false;
						isTouch = false;
					}
				}
				break;
			case 3:
				{
					if (other.gameObject.CompareTag("Monster"))
					{
						Vskill.handle2 = false;
						isTouch = false;
					}
				}
				break;
		}

	}
}
