using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class File_parser : MonoBehaviour
{
	private string strPath;
	private FileStream fs;
	private FileStream Ws;
	private StreamReader strRead;
	private StreamWriter strWrite;
	private string[] textValue;//실제 대화
	private int[] textCharacter;//대화를 내뱉는 캐릭터
	int count;
	private void Awake()
	{
		count = 0;
	}
	public void FileOpen(string FileName)
	{
		strPath = Application.dataPath + FileName;
		textValue = System.IO.File.ReadAllLines(strPath);
		textCharacter = new int[textValue.Length];
		fs = new FileStream(strPath, FileMode.Open);
		strRead = new StreamReader(fs);
	}
	public void FileOpen(string FileName,int val=1)
	{
		strPath = Application.dataPath + FileName;
		fs = new FileStream(strPath, FileMode.Create);
		fs.Flush();
		strWrite = new StreamWriter(fs);
	}
	public void FileSave(string FileName, string name, int stage, string saveTime, float sound, int skill1, int skill2, int skill3)
	{
		FileOpen(FileName,2);
		strWrite.Flush();
		strWrite.WriteLine(name);
		strWrite.WriteLine(stage);
		strWrite.WriteLine(saveTime);
		strWrite.WriteLine(sound);
		strWrite.WriteLine(skill1);
		strWrite.WriteLine(skill2);
		strWrite.WriteLine(skill3);
	}
	public void FileClose()
	{

		if (strRead != null)
		{
			fs.Close();
			strRead.Close();
		} 
		if (strWrite != null)
			strWrite.Close();

	}
	public void Parse()
	{
		string source = strRead.ReadLine();
		while (source != null)
		{
			textValue[count] = source.Split('|')[0];
			int.TryParse(source.Split('|')[1], out textCharacter[count++]);
			source = strRead.ReadLine();
		}
	}
	public void Reading()
	{
		string source = strRead.ReadLine();
		while (source != null)
		{
			textValue[count++] = source;
			source = strRead.ReadLine();
		}
	}
	public string[] GetText()
	{
		return textValue;
	}
	public string getTextOne(int count)
	{
		return textValue[count];
	}
	public int[] GetTextChar()
	{
		return textCharacter;
	}
}

