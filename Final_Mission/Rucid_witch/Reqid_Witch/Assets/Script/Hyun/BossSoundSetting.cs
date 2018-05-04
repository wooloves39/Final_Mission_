using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundSetting : MonoBehaviour {
	public enum BosssoundPack { Appearance,Defance, AttackSkill, Die };
	private BosssoundPack sound;
	public AudioClip[] sounds;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		sound = BosssoundPack.Appearance;
		audio = GetComponent<AudioSource>();
	}
	public void PlayerSound(int soundNum)
	{
		if (!audio.isPlaying)
		{
			audio.clip = sounds[soundNum];
			audio.Play();
		}
	}
	public void PlayerSound(BosssoundPack sound)
	{
		if (!audio.isPlaying)
		{
			audio.clip = sounds[(int)sound];
			audio.Play();
		}
	}
}
