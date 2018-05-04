using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionSound : MonoBehaviour {

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
	}
}
