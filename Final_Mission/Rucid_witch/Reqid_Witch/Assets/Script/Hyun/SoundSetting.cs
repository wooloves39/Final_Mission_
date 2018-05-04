using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour {

	private AudioSource CompleteSound;
	public float volumeBalance=1.0f;
	private void Awake()
	{
		CompleteSound = GetComponent<AudioSource>();
		CompleteSound.volume = Singletone.Instance.Sound*volumeBalance;
	}
}
