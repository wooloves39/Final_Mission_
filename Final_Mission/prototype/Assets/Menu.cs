using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Menu : MonoBehaviour {

	//UI 스타일 - 텍스트 박스
	public GUIStyle TextBox;
	//UI 스타일 - 버튼 박스
	public GUIStyle Button;
	public GUIStyle Load;
	public GUIStyle Background;
	public GUIStyle UITitle;
	public GUIStyle Back;
	public GUIStyle SELECT;

	//뒷 배경 크기
	public int UIMenuTitleWidht = 512;
	public int UIMenuTitleHeight = 400;

	//첫화면 메뉴 크기 + 간격
	public int UIWidth = 300;
	public int UIHeight = 70;
	public int UISpace = 20;

	//메뉴 소제목 타이틀
	public int UINameWidth = 480;
	public int UINameHeight = 70;

	//이어하기 메뉴 크기 + 간격
	public int UILoadWidth = 150;
	public int UILoadHeight = 270;
	public int UILoadSpace = 20;

	//옵션 초기 값
	public float UIOptionSound = 0.5f;
	//옵션 크기 + 간격
	public int UIOptionWidth = 420;
	public int UIOptionHeight = 70;
	public int UIOptionSpace = 20;

	public int UIBackWidth = 100;
	public int UIBackHeight = 40;

	//메뉴 1 = 처음화면
	//메뉴 2 = 처음하기
	//메뉴 3 = 이어하기
	//메뉴 4 = 멀티플레이
	//메뉴 5 = 옵션
	public int num = 1;
	int keynum = 0;
	public GameObject Title;
	public AudioSource audioSource;
	void Start()
	{
		audioSource = FindObjectOfType<AudioSource> ();
		audioSource.volume = UIOptionSound;
		Singletone.Instance.Sound = UIOptionSound;
        string FilePath = Application.dataPath + "/save1.txt";
        FileStream fs = new FileStream(FilePath, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("Reqid_Witch");
        sw.WriteLine("4");
        sw.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
        sw.Close();
        fs.Close();
    }
	void Update()
	{
		if (keynum == 0) {
			if (Input.GetKeyUp (KeyCode.S)) {
				keynum=1;
			}
		} 
		else {
			if (Input.GetKeyUp (KeyCode.W)) {
				if (keynum != 1)
					keynum--;
			}
			if (Input.GetKeyUp (KeyCode.S)) {
				if(keynum!=4)
					keynum++;
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				num = keynum+1;
				if(num == 2)
					SceneManager.LoadScene("ready");
			}
		}

	}
    void OnGUI()
    {
        if (Title.activeSelf==false) 
		{

            if (num != 0)
                GUI.Box(new Rect(Screen.width / 2 - UIMenuTitleWidht / 2, Screen.height / 2 - UIMenuTitleHeight / 2, UIMenuTitleWidht, UIMenuTitleHeight), "",Background);
            if (num == 1) {
				if (GUI.Button(new Rect(Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - ((UIHeight + UISpace) * 3 / 2) - (UIHeight / 2), UIWidth, UIHeight), "새로시작",Button)) {
                    //다음 씬으로 넘어감
                    SceneManager.LoadScene("ready");
                    num = 2;
					keynum = 0;
                }
				if (GUI.Button(new Rect(Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - ((UIHeight + UISpace) / 2) - (UIHeight / 2), UIWidth, UIHeight), "이어하기",Button)) {
                    num = 3;
					keynum = 0;
                }
				if (GUI.Button(new Rect(Screen.width / 2 - (UIWidth / 2), Screen.height / 2 + ((UIHeight + UISpace) / 2) - (UIHeight / 2), UIWidth, UIHeight), "멀티플레이",Button)) {
                    //num = 4;
					keynum = 0;
                }
				if (GUI.Button(new Rect(Screen.width / 2 - (UIWidth / 2), Screen.height / 2 + ((UIHeight + UISpace) * 3 / 2) - (UIHeight / 2), UIWidth, UIHeight), "옵션",Button)) {
					num = 5;
					keynum = 0;
                }
				if (keynum == 1)
					GUI.Box (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - ((UIHeight + UISpace) * 3 / 2) - (UIHeight / 2), UIWidth+10, UIHeight+5), "", SELECT);
				if (keynum == 2)
					GUI.Box (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - ((UIHeight + UISpace) / 2) - (UIHeight / 2), UIWidth+10, UIHeight+5), "", SELECT);
				if (keynum == 3)
					GUI.Box(new Rect(Screen.width / 2 - (UIWidth / 2), Screen.height / 2 + ((UIHeight + UISpace) / 2) - (UIHeight / 2), UIWidth+10, UIHeight+5), "", SELECT);
				if (keynum == 4)
					GUI.Box(new Rect(Screen.width / 2 - (UIWidth / 2), Screen.height / 2 + ((UIHeight + UISpace) * 3 / 2) - (UIHeight / 2), UIWidth+10, UIHeight+5), "", SELECT);
			}
            if (num == 3) {
				GUI.Box(new Rect(Screen.width / 2 - UINameWidth/2, Screen.height / 2 - UILoadHeight / 2 - UINameHeight/2, UINameWidth, UINameHeight), "이어하기",UITitle);
                if (GUI.Button(new Rect(Screen.width / 2 - (UILoadWidth / 2) - UILoadWidth - UILoadSpace, Screen.height / 2 - UILoadHeight / 2 + 45, UILoadWidth, UILoadHeight), "이어하기 1",Load)) {
                    //다음 씬으로 넘어감
                    string FilePath = Application.dataPath + "/save1.txt";
                    FileStream fs = new FileStream(FilePath, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
					Singletone.Instance.Load(sr);
					SceneManager.LoadScene("ready");
                    num = 2;
                }
				if (GUI.Button(new Rect(Screen.width / 2 - (UILoadWidth / 2), Screen.height / 2 - UILoadHeight / 2 + 45, UILoadWidth, UILoadHeight), "이어하기 2",Load)) {
					//다음 씬으로 넘어감
					SceneManager.LoadScene("ready");
                    num = 2;
                }
				if (GUI.Button(new Rect(Screen.width / 2 - (UILoadWidth / 2) + UILoadWidth + UILoadSpace, Screen.height / 2 - UILoadHeight / 2 + 45, UILoadWidth, UILoadHeight), "이어하기 3",Load)) {
					//다음 씬으로 넘어감
					SceneManager.LoadScene("ready");
                    num = 2;
                }
				if (GUI.Button(new Rect(Screen.width / 2 - UIBackWidth/2, Screen.height / 2 + UIMenuTitleHeight / 2-UIBackHeight, UIBackWidth, UIBackHeight), "이전단계",Back)) {
                    num = 1;
                }
            }
			if (num == 5) {
				GUI.Box(new Rect(Screen.width / 2 - UIOptionWidth / 2, Screen.height / 2 - UIOptionHeight / 2 - (UIOptionHeight * 3 / 2) - UIOptionSpace, UIOptionWidth, UIOptionHeight), "설정",UITitle);
				GUI.Box(new Rect(Screen.width / 2 - UIOptionWidth / 2 + UIOptionSpace, Screen.height / 2 - UIOptionHeight / 2 - (UIOptionHeight / 2) + UIOptionSpace, UIOptionWidth - UIOptionSpace * 2, UIOptionHeight), "사운드", TextBox);

				UIOptionSound = GUI.HorizontalSlider(new Rect(Screen.width / 2 - UIOptionWidth / 2 + UIOptionSpace, Screen.height / 2 - UIOptionHeight / 2 - (UIOptionHeight / 2) + UIOptionSpace * 2, UIOptionWidth - UIOptionSpace * 2, UIOptionHeight), UIOptionSound, 0, 1);
				Singletone.Instance.Sound = UIOptionSound;
				audioSource.volume = UIOptionSound;
				if (GUI.Button(new Rect(Screen.width / 2-UIBackWidth/2, Screen.height / 2 + UIMenuTitleHeight / 2-UIBackHeight , UIBackWidth, UIBackHeight), "이전단계",Back))  {
                    num = 1;
                }
            }
        } 
	}
}
