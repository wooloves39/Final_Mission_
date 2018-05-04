using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour {

	private OVRScreenFade scenefade;
	// Use this for initialization
	void Start () {
		scenefade = FindObjectOfType<OVRScreenFade>();
		scenefade.fade(Color.white, 1, 0, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			sceneChange(0);
		}
	}
	public void sceneChange(int SceneNum)
	{
		scenefade.fade(Color.white, 0, 1, 2.0f);
		StartCoroutine(SceneChangeCor(2.0f, SceneNum));
	}
	IEnumerator SceneChangeCor(float timer,int SceneNum)
	{
		yield return new WaitForSeconds(timer - .3f);
		SceneManager.LoadScene(SceneNum);
	}
	public void sceneChange(string SceneName)
	{
		scenefade.fade(Color.white, 0, 1, 2.0f);
		StartCoroutine(SceneChangeCor(2.0f, SceneName));
	}
	IEnumerator SceneChangeCor(float timer, string SceneName)
	{
		yield return new WaitForSeconds(timer - .3f);
		SceneManager.LoadScene(SceneName);
	}
}
