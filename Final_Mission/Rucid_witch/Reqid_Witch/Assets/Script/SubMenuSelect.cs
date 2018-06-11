using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuSelect : MonoBehaviour {
	public GameObject[] EFF;
	public GameObject[] BGM;
	private void OnEnable()
	{
		for (int i = 0; i < 3; ++i)
		{
			EFF[i].SetActive(false);
			BGM[i].SetActive(false);
		}
		if (Singletone.Instance.BGMSound < 0.25f)
		{
			BGM[0].SetActive(true);
		}
		else if (Singletone.Instance.BGMSound < 0.75f)
		{
			BGM[1].SetActive(true);
		}
		else
		{
			BGM[2].SetActive(true);
		}
		if (Singletone.Instance.Sound < 0.25f)
		{
			EFF[0].SetActive(true);
		}
		else if (Singletone.Instance.Sound < 0.75f)
		{
			EFF[1].SetActive(true);
		}
		else
		{
			EFF[2].SetActive(true);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Menu")
		{
			Vector3 temp = other.GetComponent<RectTransform>().localScale;

			if(temp.z > 0)
			{
				if(temp.z < 1.5f)
				{
					for(int i = 0; i < 3; ++i)
						BGM[i].SetActive(false);
					BGM[0].SetActive(true);
					Singletone.Instance.BGMSound = 0.0f;
				}
				else if( temp.z < 2.5f)
				{
					for (int i = 0; i < 3; ++i)
						BGM[i].SetActive(false);
					BGM[1].SetActive(true);
					Singletone.Instance.BGMSound = 0.5f;
				}
				else
				{
					for (int i = 0; i < 3; ++i)
						BGM[i].SetActive(false);
					BGM[2].SetActive(true);
					Singletone.Instance.BGMSound = 1.0f;
				}

			}
			else
			{
				if (temp.z > -1.5f)
				{
					for (int i = 0; i < 3; ++i)
						EFF[i].SetActive(false);
					EFF[0].SetActive(true);
					Singletone.Instance.Sound = 0.0f;
				}
				else if (temp.z > 2.5f)
				{
					for (int i = 0; i < 3; ++i)
						EFF[i].SetActive(false);
					EFF[1].SetActive(true);
					Singletone.Instance.Sound = 0.5f;
				}
				else
				{
					for (int i = 0; i < 3; ++i)
						EFF[i].SetActive(false);
					EFF[2].SetActive(true);
					Singletone.Instance.Sound = 1.0f;
				}
			}
		}
	}
}
