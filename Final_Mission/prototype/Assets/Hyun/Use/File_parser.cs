using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class File_parser : MonoBehaviour
{
	private string strPath;
	private FileStream fs;
	private StreamReader strRead;
	private string[] textValue;//실제 대화
	private int[] textCharacter;//대화를 내뱉는 캐릭터
	int count = 0;
	public void FileOpen(string FileName)
	{
		strPath = Application.dataPath + FileName;
		textValue = System.IO.File.ReadAllLines(strPath);
		textCharacter = new int[textValue.Length];
		fs = new FileStream(strPath, FileMode.Open);
		strRead = new StreamReader(fs);
	}
	public void FileClose()
	{
		fs.Close();
		strRead.Close();
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
	public string[] GetText()
	{
		return textValue;
	}
	public int[] GetTextChar()
	{
		return textCharacter;
	}
}

