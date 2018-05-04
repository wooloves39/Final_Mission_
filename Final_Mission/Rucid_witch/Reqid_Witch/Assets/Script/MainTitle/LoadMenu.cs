using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
	public GameObject[] Select;
	public GameObject Main;
	public GameObject Confirm;
	public bool confirm = false;
	int index = 0;
	// Use this for initialization
	public AudioClip[] clips;//0 OK 1 NO 2 Move 
	private AudioSource source;
	// Update is called once per frame
	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	void OnEnable()
	{
		confirm = false;
		index = 0;
		StartCoroutine(KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			source.clip = clips[0];
			source.Play();
			if (index == 0)
			{
				confirm = true;
				Confirm.SetActive(true);
			}
			if (index == 1)
			{
				confirm = true;
				Confirm.SetActive(true);
			}
			if (index == 2)
			{
				confirm = true;
				Confirm.SetActive(true);
			}
			if (index == 3)
			{
				this.gameObject.SetActive(false);
				Main.SetActive(true);
			}
		}
		if (InputManager_JHW.BButtonDown())
		{
			source.clip = clips[1];
			source.Play();
			if (index == 0)
			{
				index = 3;
			}
			if (index == 1)
			{
				index = 3;
			}
			if (index == 2)
			{
				index = 3;
			}
			if (index == 3)
			{
				this.gameObject.SetActive(false);
				Main.SetActive(true);
			}

		}
	}
	IEnumerator KeyPad()
	{
		if (!confirm)
		{
			Vector3 Stick;
			while (this.gameObject.activeInHierarchy)
			{
				//KeyBoard	
				Stick = InputManager_JHW.MainJoystick();

				if (Stick.x > 0)
					if (index != 2 && index != 3)
					{
						index++;
						source.clip = clips[2];
						source.Play();
					}

				if (Stick.x < 0)
					if (index != 0 && index != 3)
					{
						index--;
						source.clip = clips[2];
						source.Play();
					}
				for (int i = 0; i < Select.Length; ++i)
				{
					Select[i].SetActive(false);
				}
				Select[index].SetActive(true);
				yield return new WaitForSeconds(0.125f);
			}
		}
	}
}