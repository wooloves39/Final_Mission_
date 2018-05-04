using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Ready : MonoBehaviour {
	public GUIStyle Back;
	public GUIStyle skill1;
	public GUIStyle skill2;
	public GUIStyle skill3;
	public GUIStyle skill4;
	public GUIStyle skill5;
	public GUIStyle SELECT;
	public GUIStyle next;
	int num =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnGUI(){
		GUI.Box (new Rect (0, 0, Screen.width ,Screen.height), "", Back);
		GUI.Box (new Rect (Screen.width/2+10, 0+10, 370 ,390), "", Back);
		if(GUI.Button (new Rect (Screen.width / 2 +210, Screen.height - 130, 140 ,90), "Ready", next))
			SceneManager.LoadScene("stage1");
		bool check = false;
		if (GUI.Button (new Rect (Screen.width / 2 - 240 - 60, Screen.height / 2 - 100, 110, 80), "", skill1)) {
			for (int i = 0; i < 3; ++i)
				if (Singletone.Instance.skill [i] == 0) {
					check = true;
				}
			if (check == false) {
				Singletone.Instance.skill [num] = 0;
				++num;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 2 - 120 - 60, Screen.height / 2 - 100, 110, 80), "", skill2)) {
			for (int i = 0; i < 3; ++i)
				if (Singletone.Instance.skill [i] == 1) {
					check = true;
				}
			if (check == false) {
				Singletone.Instance.skill [num] = 1;
				++num;
			}
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 0 - 60, Screen.height / 2 - 100, 110, 80), "", skill3)) {
			for (int i = 0; i < 3; ++i)
				if (Singletone.Instance.skill [i] == 2) {
					check = true;
				}
			if (check == false) {
				Singletone.Instance.skill [num] = 2;
				++num;
			}
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 120, Screen.height / 2, 110, 80), "", skill4)) {
			for (int i = 0; i < 3; ++i)
				if (Singletone.Instance.skill [i] == 3) {
					check = true;
				}
			if (check == false) {
				Singletone.Instance.skill [num] = 3;
				++num;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 2 - 240, Screen.height / 2, 110, 80), "", skill5)){
			for (int i = 0; i < 3; ++i)
				if (Singletone.Instance.skill [i] == 4) {
					check = true;
				}
			if (check == false) {
				Singletone.Instance.skill [num] = 4;
				++num;
			}
		}
		if(num>2)
			num=0;
		for(int i=0;i<3;++i)
		{
			if(Singletone.Instance.skill [i]==0)
				GUI.Box (new Rect (Screen.width / 2 - 240 -60, Screen.height / 2-100, 115, 80), "", SELECT);
			if(Singletone.Instance.skill [i]==1)
				GUI.Box (new Rect (Screen.width / 2 - 120-60, Screen.height / 2-100, 115, 80), "", SELECT);
			if(Singletone.Instance.skill [i]==2)
				GUI.Box (new Rect (Screen.width / 2 - 0-60, Screen.height / 2-100, 115, 80), "", SELECT);
			if(Singletone.Instance.skill [i]==3)
				GUI.Box (new Rect (Screen.width / 2 - 120, Screen.height / 2, 115, 80), "", SELECT);
			if(Singletone.Instance.skill [i]==4)
				GUI.Box (new Rect (Screen.width / 2 - 240, Screen.height / 2, 115, 80), "", SELECT);
		}
	}
}
