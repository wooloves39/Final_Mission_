using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Sound_Set : MonoBehaviour {

	private AudioSource sound;
	public float Wait_Time;
	public AudioClip play;

    public bool Shoot = false;
    public GameObject ShootSound;
    public bool check = false;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		sound.volume = Singletone.Instance.Sound;
	}
	void OnEnable()
	{
        check = false;
		sound = GetComponent<AudioSource> ();
		sound.volume = Singletone.Instance.Sound;
		Invoke ("PlaySound", Wait_Time);
	}
	void PlaySound()
	{
		sound.clip = play;
		sound.Play ();
        if (Shoot)
            StartCoroutine("PlayShoot");
	}
    IEnumerator PlayShoot()
    {
        while (!check)
        {
            if (!this.gameObject.activeInHierarchy)
                break;
            yield return null;
        }
        if (this.gameObject.activeInHierarchy)
        {
            AudioSource temp = ShootSound.GetComponent<AudioSource>();
            temp.Play();
        }
    }
}
