using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionSound : MonoBehaviour {
	public float Volume = 0.66f;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = Singletone.Instance.Sound;
	}

	void OnLevelWasLoaded()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = Singletone.Instance.Sound;
	}
	void Awake()
	{
		DontDestroyOnLoad (this);
	}
	void ChangeVolume()
	{
		//Debug.Log ("sound");
		Singletone.Instance.Sound = audioSource.volume;
	}
	void Coroutin()
	{
	}
}

