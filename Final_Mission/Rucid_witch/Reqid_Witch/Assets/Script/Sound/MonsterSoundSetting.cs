using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSoundSetting : MonoBehaviour {

	public AudioClip[] sounds;
	public float AttackDelay = 0.0f;
	public float PlusSound = 1.0f;
	private AudioSource[] audio;
	private float sound = Singletone.Instance.Sound;
	// Use this for initialization
	void OnEnable () {
		audio = GetComponents<AudioSource>();
	}
	// idle = 0
	// hit = 1
	// attack = 2
	// die = 3
	// electronic = 4
	// Update is called once per frame
	void Update () {
	}
	IEnumerator attack(int num)
	{
		yield return new WaitForSeconds(AttackDelay);
		audio[1].clip = sounds[num];
		audio[1].volume = sound;
		audio[1].Play();
	}
	public void PlaySound(int num)
	{
		if (num < sounds.Length)
		{
			if (num == 0 || num == 3)
			{
				audio[0].clip = sounds[num];
				audio[0].volume = sound;
				if (num == 0)
				{
					audio[0].volume = sound*PlusSound;
					audio[0].loop = true;
				}
				else
					audio[0].loop = false;
				audio[0].Play();
			}
			if (num == 2 || num == 1)
			{
				if (num == 2)
					StartCoroutine("attack", num);
				else
				{
					audio[1].clip = sounds[num];
					audio[1].volume = sound;
					audio[1].Play();
				}
			}
			if (num == 4)
			{
				audio[2].clip = sounds[num];
				audio[2].volume = sound;
				audio[2].Play();
			}
		}
	}

}
