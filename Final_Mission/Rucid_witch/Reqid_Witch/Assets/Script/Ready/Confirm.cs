using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
	private SceneChange sceneChange;
	public GameObject[] ui_arr;
	private bool choice = false;
	private void Awake()
	{
		sceneChange = FindObjectOfType<SceneChange>();
	}
	private void OnEnable()
	{
		StartCoroutine(KeyPad());
	}
	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (choice)
			{
				Debug.Log(Singletone.Instance.stage + 3);
				sceneChange.sceneChange(Singletone.Instance.stage + 3);
			}
			else
			{
				//그냥 다시 원래 상태
				transform.parent.GetComponent<SelectMenu_Ready>().confirm = false;
				choice = false;
				gameObject.SetActive(false);
			}
		}
		if (InputManager_JHW.BButtonDown())
		{
			//그냥 원래 상태
			transform.parent.GetComponent<SelectMenu_Ready>().confirm = false;
			choice = false;
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
				choice = false;
			}

			else if (Stick.x < 0)
			{
				choice = true;
			}
			if (choice)
			{
				ui_arr[0].gameObject.SetActive(true);
				ui_arr[1].gameObject.SetActive(false);
			}
			else
			{
				ui_arr[1].gameObject.SetActive(true);
				ui_arr[0].gameObject.SetActive(false);

			}
			yield return new WaitForSeconds(0.05f);
		}

	}
}
