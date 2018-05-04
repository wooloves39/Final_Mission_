using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Dia_Play : MonoBehaviour
{
	private bool Play = true;
	private bool TalkEnd = false;
	//public MouseLook mouseLook;
	public GameObject TalkCanvas;
	// Use this for initialization
	void Start()
	{
		//mouseLook.enabled = false;
		TalkCanvas.SetActive(false);
		StartCoroutine(TalkCoroutine());
	}
	public bool getPlay() { return Play; }
	public void setPlay(bool val) { Play = val; }
	public bool getEnd() { return TalkEnd; }
	public void setEnd(bool val) { TalkEnd = val; }
	// Update is called once per frame
	void Update()
	{
		//test;
		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log("눌림");
			Singletone.Instance.Load("/save1.txt");
			Play = !Play; }
	}
	private IEnumerator TalkCoroutine()
	{
		while (true)
		{
			TalkCanvas.SetActive(false);
			yield return new WaitUntil(() =>!Play);
			TalkCanvas.SetActive(true);
			yield return new WaitUntil(() => Play);
		}
	}
}
