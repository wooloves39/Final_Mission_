using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveConfirm : MonoBehaviour
{
	public GameObject[] ui_arr;
	private int index = 0;
	// Use this for initialization
	void Start()
	{

	}
	private void OnEnable()
	{
		StartCoroutine(KeyPad());
		index = 0;
		ui_arr[index].SetActive(true);
	}
	private void OnDisable()
	{
		ui_arr[0].SetActive(false);
		ui_arr[1].SetActive(false);
		ui_arr[2].SetActive(false);
	}
	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			switch (index)
			{
				case 0:
					Singletone.Instance.Save("/Text/Save/save01.txt");
					break;
				case 1:
					Singletone.Instance.Save("/Text/Save/save02.txt");
					break;
				case 2:
					Singletone.Instance.Save("/Text/Save/save03.txt");
					break;
			}
			Debug.Log("저장완료");
			transform.parent.GetComponent<SelectMenu_Ready>().confirm = false;
			gameObject.SetActive(false);
		}
		if (InputManager_JHW.BButtonDown())
		{
			//그냥 원래 상태
			transform.parent.GetComponent<SelectMenu_Ready>().confirm = false;
			gameObject.SetActive(false);
		}
	}
	IEnumerator KeyPad()
	{
		while (gameObject.activeSelf)
		{
			Vector3 Stick;
			Stick = InputManager_JHW.MainJoystick();

			if (Stick.x > 0)
			{
				++index;
				if (index == 3) index = 0;
			}
			else if (Stick.x < 0)
			{
				--index;
				if (index == -1) index = 2;
			}
			if (Stick.x != 0)
			{
				for (int i = 0; i < ui_arr.Length; ++i)
				{
					if (i == index)
					{
						ui_arr[i].SetActive(true);
					}
					else
					{
						ui_arr[i].SetActive(false);
					}
				}
			}
			yield return new WaitForSeconds(0.09f);
		}
	}
}
