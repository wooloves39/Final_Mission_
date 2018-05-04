using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public int UIMenuTitleWidht = 512;
	public int UIMenuTitleHeight = 400;

	public int UIWidth = 300;
	public int UIHeight = 70;
	public int UISpace = 20;

	public int UILoadWidth = 150;
	public int UILoadHeight = 270;
	public int UILoadSpace = 20;

	public GUIStyle TextBox;
	public float UIOptionSound = 50.0f;
	public int UIOptionWidth = 420;
	public int UIOptionHeight = 70;
	public int UIOptionSpace = 20;

	public int num = 1;
	void OnGUI()
	{
		if(num!=0)
			GUI.Box(new Rect(Screen.width / 2 - UIMenuTitleWidht/2,Screen.height / 2 - UIMenuTitleHeight/2,UIMenuTitleWidht,UIMenuTitleHeight),"");
		if (num == 1) {
			if (GUI.Button (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - ((UIHeight + UISpace)*3/2) - (UIHeight / 2), UIWidth, UIHeight), "새로시작")) {
				SceneManager.LoadScene ("map&player");
				num = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - ((UIHeight + UISpace)/2) - (UIHeight / 2), UIWidth, UIHeight), "이어하기")){
				num = 3;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 + ((UIHeight + UISpace)/2) - (UIHeight / 2), UIWidth, UIHeight), "멀티플레이")) {
				//num = 4;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 + ((UIHeight + UISpace)*3/2) - (UIHeight / 2), UIWidth, UIHeight), "옵션")) {
				num = 5;
			}
		}
		if (num == 3) {
			GUI.Box(new Rect(Screen.width / 2 -240,Screen.height / 2 - UILoadHeight/2 - 35 ,480,70),"\n이어하기");
			if (GUI.Button (new Rect (Screen.width / 2 - (UILoadWidth / 2) - UILoadWidth -UILoadSpace, Screen.height / 2 - UILoadHeight/2 + 45, UILoadWidth, UILoadHeight), "이어하기 1")) {
				SceneManager.LoadScene ("map&player");
				num = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - (UILoadWidth / 2), Screen.height / 2  - UILoadHeight/2+ 45, UILoadWidth , UILoadHeight), "이어하기 2")) {
				SceneManager.LoadScene ("map&player");
				num = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - (UILoadWidth / 2) + UILoadWidth +UILoadSpace,Screen.height / 2 -  UILoadHeight/2+ 45, UILoadWidth, UILoadHeight), "이어하기 3")) {
				SceneManager.LoadScene ("map&player");
				num = 2;
			}
			if (GUI.Button (new Rect (Screen.width -80 ,Screen.height -40 , 80, 40), "이전단계")) {
				num = 1;
			}
		}
		if (num == 5) {
			GUI.Box(new Rect(Screen.width / 2 -UIOptionWidth/2,Screen.height / 2 - UIOptionHeight/2 - (UIOptionHeight*3/2) - UIOptionSpace ,UIOptionWidth,UIOptionHeight),"\n설정");

			GUI.Box(new Rect(Screen.width / 2 -UIOptionWidth/2,Screen.height / 2 - UIOptionHeight ,UIOptionWidth,260),"");
			GUI.TextArea(new Rect(Screen.width / 2 -UIOptionWidth/2+UIOptionSpace,Screen.height / 2 - UIOptionHeight/2 - (UIOptionHeight/2) + UIOptionSpace,UIOptionWidth-UIOptionSpace*2,UIOptionHeight),"사운드",TextBox);
			UIOptionSound = GUI.HorizontalSlider(new Rect(Screen.width / 2 -UIOptionWidth/2+UIOptionSpace,Screen.height / 2 - UIOptionHeight/2- (UIOptionHeight/2) + UIOptionSpace*2 ,UIOptionWidth-UIOptionSpace*2,UIOptionHeight),UIOptionSound,0,100);
	
			if (GUI.Button (new Rect (Screen.width -80 ,Screen.height -40 , 80, 40), "적용하기")) {
				num = 1;
			}
		}
	}
}
