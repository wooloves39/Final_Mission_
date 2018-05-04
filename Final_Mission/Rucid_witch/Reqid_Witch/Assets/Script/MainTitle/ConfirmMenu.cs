using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmMenu : MonoBehaviour {
	private SceneChange sceneChange;
	int index = 1;
	public GameObject[] Select;
	public GameObject load;
	public AudioClip[] clips;//0 OK 1 NO 2 Move 
	private AudioSource source;
	private void Awake()
	{
		sceneChange = FindObjectOfType<SceneChange>();
		source = GetComponent<AudioSource>();
	}
	void OnEnable ()
	{
		index = 1;
		StartCoroutine (KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (index == 1)
			{//파일입출력으로 파일 읽어오는 코드가 필요
				source.clip = clips[0];
				source.Play();
				sceneChange.sceneChange("Ready");
			}
			if (index == 0)
			{
				source.clip = clips[1];
				source.Play();
				load.GetComponent<LoadMenu>().confirm = false;
				this.gameObject.SetActive(false);
			}
		}
	}
	IEnumerator KeyPad(){

		Vector3 Stick;
		while(this.gameObject.activeInHierarchy == true)
		{
			Stick = InputManager_JHW.MainJoystick();

			if (Stick.x < 0)
			{
				index = 0;
				source.clip = clips[2];
				source.Play();
			}

			if (Stick.x > 0)
			{
				index = 1;
				source.clip = clips[2];
				source.Play();
			}

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);

		
			yield return new WaitForSeconds(0.125f);
		}
	}
}
