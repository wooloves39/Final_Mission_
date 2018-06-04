using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionSound : MonoBehaviour {

	AudioSource[] audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponents<AudioSource> ();
        for(int i = 0 ; i <audioSource.Length;++i)
            audioSource[i].volume = Singletone.Instance.Sound;
	}
    void SoundPatch()
    {
        for(int i = 0 ; i <audioSource.Length;++i)
            audioSource[i].volume = Singletone.Instance.Sound;
    }
	void OnLevelWasLoaded()
	{
        audioSource = GetComponents<AudioSource> ();
        for(int i = 0 ; i <audioSource.Length;++i)
            audioSource[i].volume = Singletone.Instance.Sound;
	}
	void Awake()
	{
	}
}
