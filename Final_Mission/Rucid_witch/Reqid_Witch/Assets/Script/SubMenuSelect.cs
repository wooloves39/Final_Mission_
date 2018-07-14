using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuSelect : MonoBehaviour {
	public GameObject[] EFF;
	public GameObject[] BGM;
	public GameObject[] SAVE;
	private Collider Col;
	private float mytime = 0.0f;
	
	private void OnEnable()
	{
		mytime = 0.0f;
		for (int i = 0; i < 3; ++i)
		{
			EFF[i].SetActive(false);
			BGM[i].SetActive(false);
			SAVE[i].SetActive(false);
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
		if (other.tag == "Menu")
		{
			Col = other;
			mytime = 0.0f;
			
		}	
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Menu")
		{
			Col = null;
			mytime = 0.0f;
		}
	}
	private void Update()
	{
		if (Col != null)
		{
			if (InputManager_JHW.AButtonDown())
			{
				mytime += 2.0f;
			}
			if (mytime >= 1.0f)
			{
				Vector3 temp = Col.GetComponent<RectTransform>().localScale;

				if (temp.z > 0)
				{
					if (temp.z < 1.5f)
					{
						for (int i = 0; i < 3; ++i)
							BGM[i].SetActive(false);
						BGM[0].SetActive(true);
						Singletone.Instance.BGMSound = 0.0f;
					}
					else if (temp.z < 2.5f)
					{
						for (int i = 0; i < 3; ++i)
							BGM[i].SetActive(false);
						BGM[1].SetActive(true);
						Singletone.Instance.BGMSound = 0.5f;
					}
					else if (temp.z < 3.5f)
					{
						for (int i = 0; i < 3; ++i)
							BGM[i].SetActive(false);
						BGM[2].SetActive(true);
						Singletone.Instance.BGMSound = 1.0f;
					}
					else if (temp.z < 100.5f)
					{
						SAVE[0].SetActive(true);
						StartCoroutine("Fade", 0);
						Singletone.Instance.Save("/Text/Save/save01.txt");
					}
					else if (temp.z < 101.5f)
					{
						SAVE[1].SetActive(true);
						StartCoroutine("Fade", 1);
						Singletone.Instance.Save("/Text/Save/save02.txt");
					}
					else if (temp.z < 102.5f)
					{
						SAVE[2].SetActive(true);
						StartCoroutine("Fade", 2);
						Singletone.Instance.Save("/Text/Save/save03.txt");
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
					else if (temp.z > -2.5f)
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
			mytime = 0.0f;
		}
	}
	IEnumerator Fade(int n)
	{
		yield return new WaitForSeconds(1.5f);
		SAVE[n].SetActive(false);
	}

}
