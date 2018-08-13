using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNew : MonoBehaviour
{
	private SceneChange sceneChange;
	private Image textimage;
	public Sprite[] images;
	public string SceneName = "Stage0";
	// Use this for initialization
	void Awake () {
		textimage = GetComponent<Image>();
		textimage.sprite = images[0];
		StartCoroutine(StartNewCor());
		sceneChange = FindObjectOfType<SceneChange>();
	}
	private void Update()
	{
		if (InputManager_JHW.MenuButton())
		{
			sceneChange.sceneChange(SceneName);
		}
	}
	IEnumerator StartNewCor()
	{ int textCount = 0;
		float colorAlpha = 0.0f;
		float plugNum = 2.5f;
		while (true)
		{
			textimage.color = new Color(textimage.color.r, textimage.color.g, textimage.color.b,colorAlpha/255);
			colorAlpha += plugNum;
			if(colorAlpha>=255|| colorAlpha <= 0)
			{
				if (colorAlpha >= 255)
				{
					yield return new WaitForSeconds(1.5f);
				}
				if (colorAlpha <= 0)
				{
					++textCount;
					if (textCount == images.Length) break;
					textimage.sprite = images[textCount];
				}
				plugNum *= -1;
			}
			yield return null;
		}
		sceneChange.sceneChange(SceneName);
	}
}
