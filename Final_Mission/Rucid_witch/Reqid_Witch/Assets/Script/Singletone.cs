using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Singletone
{
	private static Singletone instance = null;

	public static Singletone Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Singletone();
			}
			return instance;
		}
	}

	private Singletone() { }

	//여기에 싱글톤 변수를 추가한다.
	//처음에 -1로 초기화 디파인이 안됨. 
    public float Sound = 0.5f;
    public float BGMSound = 0.5f;
	public string name= "Reqid_Witch";
	public int stage = 5;
	public string saveTime;
	public int[] Myskill = { 0 , 4, 3};
	public void Save(string FileName)
	{
		string saveTime = System.DateTime.Now.ToString("yyyy-MM-dd-HH");
		File_parser Files=new File_parser();
		Files.FileSave(FileName, name, stage, saveTime, Sound, Myskill[0], Myskill[1], Myskill[2]);
		Files.FileClose();
	}
	public void Load(string FileName)
	{
		string strPath = Application.dataPath + FileName;
		FileStream fs = new FileStream(strPath, FileMode.Open);
		StreamReader sr = new StreamReader(fs);
		string stage_str;
		string sound_str;
		string Myskill_str;
		name = sr.ReadLine();
		stage_str = sr.ReadLine();
		int.TryParse(stage_str, out stage);
		saveTime = sr.ReadLine();
		sound_str = sr.ReadLine();
		float.TryParse(sound_str, out Sound);
		for (int i = 0; i < Myskill.Length; ++i)
		{
			Myskill_str = sr.ReadLine();
			int.TryParse(Myskill_str, out Myskill[i]);
		}
		Debug.Log(name);
		Debug.Log(stage);
		Debug.Log(saveTime);
		fs.Close();
		sr.Close();
	}

	//사용 예
	//  int myPlayernumber = Singletone.Instance.Charnumber - 1;
	//  Singletone.Instance.Charnumber = choice;
	//    Application.LoadLevel(Singletone.Instance.Mapnumber + 4);
	// Use this for initialization
}
