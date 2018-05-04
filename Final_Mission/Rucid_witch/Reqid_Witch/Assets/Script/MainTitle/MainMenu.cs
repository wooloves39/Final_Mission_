using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject[] Select;
	public GameObject Load;
	public GameObject Option;
	public GameObject newConfirm;
	public bool confirm = false;
	int index = 0;
	private AudioSource source;
	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	void OnEnable()
	{
		confirm = false;
		StartCoroutine(KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			source.Play();
			if (index == 0)
			{
				confirm = true;
				newConfirm.SetActive(true);
				//SceneManager.LoadScene("Stage0");
			}
			if (index == 1)
			{
				Load.SetActive(true);
				this.gameObject.SetActive(false);
			}
			if (index == 2)
			{
			}//멀티플레이
			if (index == 3)
			{
				Option.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
	IEnumerator KeyPad()
	{

		Vector3 Stick;
		while (this.gameObject.activeInHierarchy == true)
		{
			if (!confirm)
			{
				Stick = InputManager_JHW.MainJoystick();

				if (Stick.z < 0)
					if (index != 3)
					{
						index++;
						source.Play();
					}
				if (Stick.z > 0)
					if (index != 0)
					{
						index--;
						source.Play();
					}

				for (int i = 0; i < Select.Length; ++i)
				{
					Select[i].SetActive(false);
				}
				Select[index].SetActive(true);
				
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}