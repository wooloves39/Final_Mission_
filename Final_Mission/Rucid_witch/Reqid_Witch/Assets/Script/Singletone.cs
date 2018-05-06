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
	public int Mapnumber = -1;
	public int Charnumber = -1;
	public float Sound = 1.0f;
	public string name;
	public int stage = 1;
	public string saveTime;
	public int[] Myskill = { 0 , 2, 1};
	public void Save()
	{
		string saveTime = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

	}
	public void Load(string FileName)
	{
		string strPath = Application.dataPath + FileName;
		FileStream fs = new FileStream(strPath, FileMode.Open);
		StreamReader sr = new StreamReader(fs);
		string stage_str;
		name = sr.ReadLine();
		stage_str = sr.ReadLine();
		int.TryParse(stage_str, out stage);
		saveTime = sr.ReadLine();
		Debug.Log(name);
		Debug.Log(stage);
		Debug.Log(saveTime);
	}
	//사용 예
	//  int myPlayernumber = Singletone.Instance.Charnumber - 1;
	//  Singletone.Instance.Charnumber = choice;
	//    Application.LoadLevel(Singletone.Instance.Mapnumber + 4);
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

}
