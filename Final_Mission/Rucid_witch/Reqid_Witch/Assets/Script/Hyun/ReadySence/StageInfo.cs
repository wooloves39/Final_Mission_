using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfo : MonoBehaviour {
	private Text textArea;
	private File_parser file_parser;
	public string[] FileName;
	private int stage;
	private string[] DialogueStrings;
	public float speed = 0.1f;
	int characterIndex = 0;
	int stringIndex = 0;
	public Image Confirm;
	// Use this for initialization
	void Start ()
	{
		textArea = GetComponent<Text>();
		stage = Singletone.Instance.stage;
		file_parser = new File_parser();
		file_parser.FileOpen(FileName[stage]);
		file_parser.Reading();
		DialogueStrings = file_parser.GetText();
		StartCoroutine(DisplayTimer());
		file_parser.FileClose();
		switch (stage)
		{
			case 0:
				textArea.color = new Color(1, 0, 1);
				break;
			case 1:
				textArea.color = new Color(1, 1, 0);
				break;
			case 2:
				textArea.color = new Color(0, 1, 0);
				break;
			case 3:
				textArea.color = new Color(1, 0, 0);
				break;
			case 4:
				textArea.color = new Color(0, 1, 1);
				break;
			case 5:
				textArea.color = new Color(1, 0, 1);
				break;
			case 6:
				textArea.color = new Color(1, 0, 1);
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager_JHW.AButtonDown()||Confirm.color.g==0||Input.GetKeyDown(KeyCode.K))
		{
			if (characterIndex < DialogueStrings[stringIndex].Length)
			{
				characterIndex = DialogueStrings[stringIndex].Length;
			}
		}
	}
	IEnumerator DisplayTimer()
	{
		bool endStory = false;
		while (!endStory)
		{
			yield return new WaitForSeconds(speed);
			if (characterIndex >= DialogueStrings[stringIndex].Length)
			{
				endStory = true;
			}
			textArea.text = DialogueStrings[stringIndex].Substring(0, characterIndex);
			++characterIndex;
		}
	}
}
