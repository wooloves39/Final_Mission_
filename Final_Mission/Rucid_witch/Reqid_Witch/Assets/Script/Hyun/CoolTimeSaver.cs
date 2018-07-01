using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTimeSaver : MonoBehaviour
{
	public float[] Azu_Timer { get; set; }
	public float[] Sei_Timer { get; set; }
	public float[] Bee_Timer { get; set; }
	public float[] Ver_Timer { get; set; }
	public float[] Dell_Timer { get; set; }
	// Use this for initialization
	void Awake()
	{
		Azu_Timer = new float[5];
		Sei_Timer = new float[5];
		Bee_Timer = new float[5];
		Ver_Timer = new float[5];
		Dell_Timer = new float[5];
		for (int i = 0; i < 5; ++i)
		{
			Azu_Timer[i] = 0;
			Sei_Timer[i] = 0;
			Bee_Timer[i] = 0;
			Ver_Timer[i] = 0;
			Dell_Timer[i] = 0;
		}
	}
	public void startCool(int cha, int index, float EndTime)
	{
		StartCoroutine(CoolTimeSave(cha, index, EndTime));
	}
	IEnumerator CoolTimeSave(int cha, int index, float EndTime)
	{
		float timer = 0.0f;
		while (EndTime > timer)
		{
			timer += Time.deltaTime;
			switch (cha)
			{
				case 1:
					Azu_Timer[index] = timer;
					break;
				case 2:
					Sei_Timer[index] = timer;
					break;
				case 3:
					Bee_Timer[index] = timer;
					break;
				case 4:
					Ver_Timer[index] = timer;
					break;
				case 5:
					Dell_Timer[index] = timer;
					break;
			}
			yield return null;
		}
		switch (cha)
		{
			case 1:
				Azu_Timer[index] = 0.0f;
				break;
			case 2:
				Sei_Timer[index] = 0.0f;
				break;
			case 3:
				Bee_Timer[index] = 0.0f;
				break;
			case 4:
				Ver_Timer[index] = 0.0f;
				break;
			case 5:
				Dell_Timer[index] = 0.0f;
				break;
		}
	}
}
