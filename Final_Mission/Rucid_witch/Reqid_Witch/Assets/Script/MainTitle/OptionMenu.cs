using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
	public GameObject[] Select;
	public GameObject[] Sound;
	public GameObject[] Sound2;
	public GameObject[] Grapic;
	public GameObject[] Box;
	public GameObject[] Box2;
	public GameObject[] GrapicBox;
	public GameObject Main;
	public int index = 0;
	int sound = 12;
	int sound2 = 22;
	int grapic = 31;
	public float timer = 0.0f;
	private AudioSource source;
	// Use this for initialization
	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void OnEnable()
	{
		index = 0;
		timer = 0.0f;
		StartCoroutine("KeyPad");
	}
	private void Update()
	{
		//KeyBoard - Enter
		if (InputManager_JHW.AButtonDown())
		{
			source.Play();

			if (11 <= index && index <= 13)
			{
				sound = index;
				for (int i = 0; i < 3; ++i)
				{
					Sound[i].SetActive(false);
				}
				Sound[sound - 11].SetActive(true);
			}

			if (21 <= index && index <= 23)
			{
				sound2 = index;
				for (int i = 0; i < 3; ++i)
				{
					Sound2[i].SetActive(false);
				}
				Sound2[sound2 - 21].SetActive(true);
			}

			if (30 <= index && index <= 33)
			{
				grapic = index;
				for (int i = 0; i < 4; ++i)
				{
					Grapic[i].SetActive(false);
				}
				Grapic[grapic - 30].SetActive(true);
			}

			if (index == 3)
				index = sound;
			if (index == 4)
				index = sound2;

			if (index == 0)
				index = 3;



			if (index == 1)
				index = grapic;

			if (index == 2)
			{
				this.gameObject.SetActive(false);
				Main.SetActive(true);
			}
		}
		else if (InputManager_JHW.BButtonDown())
		{
			source.Play();
			bool CheckB = false;
			if ((index == 0 || index == 1) &&
				CheckB == false)
			{
				index = 2;
				CheckB = true;
			}
			if ((index == 2) &&
				CheckB == false)
			{
				index = 0;
				CheckB = true;
			}
			if (index == 3 || index == 4)
				index = 0;
			if (11 <= index && index <= 13)
				index = 3;
			if (21 <= index && index <= 23)
				index = 4;
			if (30 <= index && index <= 33)
				index = 1;
		}
	}
	IEnumerator KeyPad()
	{
		Vector3 Stick;
		while (this.gameObject.activeInHierarchy == true)
		{
			if (timer < 1.0f)
				timer += Time.deltaTime * 25;
			Stick = InputManager_JHW.MainJoystick();
			if (index < 2)
			{
				if (Stick.z > 0)
				{
					index = 0;
					source.Play();
				}

				if (Stick.z < 0)
				{
					index = 1;
					source.Play();
				}
			}
			else if (index == 4 || index == 3)
			{
				if (Stick.z > 0)
				{
					index = 3;
					source.Play();
				}
				if (Stick.z < 0)
				{
					index = 4;
					source.Play();
				}
			}

			else if (11 <= index && index <= 13)
			{
				if (Stick.x > 0 && index < 13)
				{
					index++;
					source.Play();
				}

				if (Stick.x < 0 && index > 11)
				{ index--; source.Play(); }
			}

			else if (21 <= index && index <= 23)
			{
				if (Stick.x > 0 && index < 23)
				{ index++; source.Play(); }

				if (Stick.x < 0 && index > 21)
				{ index--; source.Play(); }
			}
			else if (30 <= index && index <= 33)
			{
				if (Stick.x > 0 && index < 33)
				{ index++; source.Play(); }

				if (Stick.x < 0 && index > 30)
				{ index--; source.Play(); }
			}

			for (int i = 0; i < Select.Length; ++i)
			{
				Select[i].SetActive(false);
			}

			if (index < 5)
			{
				Select[index].SetActive(true);
				for (int i = 0; i < 3; ++i)
				{
					Box[i].SetActive(false);
					Box2[i].SetActive(false);
				}
				for (int i = 0; i < 4; ++i)
				{
					GrapicBox[i].SetActive(false);
				}
			}
			for (int i = 0; i < 3; ++i)
			{
				Box[i].SetActive(false);
				Box2[i].SetActive(false);
			}
			for (int i = 0; i < 4; ++i)
			{
				GrapicBox[i].SetActive(false);
			}
			if (11 <= index && index <= 13)
			{
				Box[index - 11].SetActive(true);
			}
			if (21 <= index && index <= 23)
			{
				Box2[index - 21].SetActive(true);
			}
			if (30 <= index && index <= 33)
			{
				GrapicBox[index - 30].SetActive(true);
			}

			yield return new WaitForSeconds(0.125f);
		}
	}
}