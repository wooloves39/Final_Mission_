using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadData : MonoBehaviour {
	public string fileName;
	public string Sound;
	public string name;
	public string stage ;
	public string saveTime;
	public string[] Myskill = { "-1","-1","-1" };
	public Text text;
	// Use this for initialization
	void Start () {
		LoadSaveDate(fileName);
		textOutput();
	}
	public void LoadSaveDate(string fileName)
	{
		File_parser file_parser = new File_parser();
		file_parser.FileOpen(fileName);
		file_parser.Reading();
		name = file_parser.getTextOne(0);
		stage = file_parser.getTextOne(1);
		saveTime = file_parser.getTextOne(2);
		Sound = file_parser.getTextOne(3);
		for (int i = 0; i < Myskill.Length; ++i)
		{
			Myskill[i] = file_parser.getTextOne(4+i);
		}
		file_parser.FileClose();
	}
	public void textOutput()
	{
		text.text = "\nName:\n "+name+"\n";
		text.text += "Stage: "+ stage + "\n";
		text.text += "사운드 옵션: " + Sound + "\n";
		text.text += "현재 스킬: " + Myskill[0] + " " + Myskill[1] + " " + Myskill[2]+"\n";
		text.text += "저장시간:\n" + saveTime + "\n";
	}
	// Update is called once per frame
	void Update () {
		
	}
}
