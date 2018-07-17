using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
	AudioSource[] Allsound;
	int BgmNum;
	// Use this for initialization
	void Start () {

		Allsound = Resources.FindObjectsOfTypeAll<AudioSource>();
		for (int i = 0; i < Allsound.Length; ++i)
		{
			Allsound[i].volume = Singletone.Instance.Sound;
			if (Allsound[i].GetComponent<BGMCheck>())
			{
				BgmNum = i;
				Allsound[BgmNum].volume = Singletone.Instance.BGMSound;
			}
		}
	}
	public void soundOptionChange()
	{
		for (int i = 0; i < Allsound.Length; ++i)
		{
			Allsound[i].volume = Singletone.Instance.Sound;
		}
		Allsound[BgmNum].volume = Singletone.Instance.BGMSound;
	}
	public void BGMOptionChange()
	{
		Allsound[BgmNum].volume = Singletone.Instance.BGMSound;
	}
}
