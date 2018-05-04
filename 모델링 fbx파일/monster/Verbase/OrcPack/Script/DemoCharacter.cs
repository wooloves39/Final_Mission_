using UnityEngine;
using System.Collections;

public class DemoCharacter : MonoBehaviour {


	public Transform T;
	public float speed = 10.0f;

	public GameObject[] Orc;
	public DemoOrc[] demoOrc;
	
	public int Class;
	public int curmat;

	bool spin;

	Camera cam;

	void Start () {
		cam = Camera.main;
		SetOrc(0);
		spin = false;
	}


	void SetOrc(int O){
		foreach (GameObject G in Orc){
			G.SetActive(false);
		}
		Orc[O].SetActive(true);
	}


	void OnGUI(){
		//models
		if (GUI.Button(new Rect(20, 20, 100, 40),"Orc Peon")){
			SetOrc(0);
			Class = 0;
			demoOrc[0].Idle();
		}

		if (GUI.Button(new Rect(20, 60, 100, 40),"Orc Grunt")){
			SetOrc(1);
			Class = 1;
			demoOrc[1].Idle();
		}

		if (GUI.Button(new Rect(20, 100, 100, 40),"Orc Shaman")){
			SetOrc(2);
			Class = 2;
			demoOrc[2].Idle();
		}

		if (GUI.Button(new Rect(20, 140, 100, 40),"Orc Lord")){
			SetOrc(3);
			Class = 3;;
			demoOrc[3].Idle();
		}

		if (GUI.Button(new Rect(20, 200, 100, 40),"Spin")){
			spin = !spin;
			T.eulerAngles = Vector3.zero;
		}
		if (GUI.Button(new Rect(20, 240, 100, 40),"Change Mat")){
			if(curmat == 0){
				curmat = 1;
			}else{
				curmat = 0;
			}
			//demoOrc[Class].CurMat = curmat;
			demoOrc[Class].mesh.material = demoOrc[Class].Mat[curmat];
		}

		/// animation
		if (GUI.Button(new Rect(150, 20, 100, 40),"idle")){
			demoOrc[Class].Idle();
		}
		if (GUI.Button(new Rect(250, 20, 100, 40),"walk")){
			demoOrc[Class].Walk();
		}
		if (GUI.Button(new Rect(350, 20, 100, 40),"run")){
			demoOrc[Class].Run();
		}
		if (GUI.Button(new Rect(450, 20, 100, 40),"hit01")){
			demoOrc[Class].hit();
		}
		if (GUI.Button(new Rect(550, 20, 100, 40),"taunt01")){
			demoOrc[Class].taunt();
		}
		if (GUI.Button(new Rect(650, 20, 100, 40),"attack01")){
			demoOrc[Class].attack01();
		}
		if (GUI.Button(new Rect(650, 60, 100, 40),"attack02")){
			demoOrc[Class].attack02();
		}

		if (GUI.Button(new Rect(750, 20, 100, 40),"die01")){
			demoOrc[Class].Die();
		}
	}

	void Update(){

		if(Input.GetMouseButton(0)){
			T.eulerAngles = new Vector3(T.eulerAngles.x,T.eulerAngles.y + Input.GetAxis("Mouse X") * -2,T.eulerAngles.z);
		}

		if (spin == false){
			return;
		}
		T.eulerAngles = new Vector3(T.eulerAngles.x,T.eulerAngles.y + speed * Time.deltaTime,T.eulerAngles.z);
	}
}
