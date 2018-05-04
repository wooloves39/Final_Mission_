using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSetting : MonoBehaviour { 
	public enum soundPack { DrawComplete,Defance, MPmiss, AttackSkill,BuffSkill,Die};
	private soundPack sound;
	public AudioClip[] sounds;
	private AudioSource audio;
	private void Start()
	{
		sound = soundPack.AttackSkill;
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
	public void PlayerSound(soundPack sound)
	{
		if (!audio.isPlaying)
		{
			audio.clip = sounds[(int)sound];
			audio.Play();
		}
	}
}
