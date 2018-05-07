using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Sound_Set : MonoBehaviour {

	private AudioSource sound;
	public float Wait_Time;
	public AudioClip play;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		sound.volume = Singletone.Instance.Sound;
	}
	void OnEnable()
	{
		sound = GetComponent<AudioSource> ();
		sound.volume = Singletone.Instance.Sound;
		Invoke ("PlaySound", Wait_Time);
	}
	void PlaySound()
	{
		sound.clip = play;
		sound.Play ();
	}
}
