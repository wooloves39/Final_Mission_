using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia_Play : MonoBehaviour
{
	private bool Play = true;
	public MouseLook mouseLook;
	public GameObject TalkCanvas;
	// Use this for initialization
	void Start()
	{
		mouseLook.enabled = false;
		TalkCanvas.SetActive(false);
	}
	public bool getPlay() { return Play; }
	public void setPlay(bool val) { Play = val; }
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P)) Play=!Play;
		if (Play) {
			mouseLook.enabled = true;
			TalkCanvas.SetActive(false);
		}
		else
		{
			mouseLook.enabled = false;
			TalkCanvas.SetActive(true);
		}
	}
}
