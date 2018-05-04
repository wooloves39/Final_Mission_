using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taget : MonoBehaviour {
	//FollowCamera followCamera;
	CharacterStatus characterStatus;
	public int HP;
	public int MaxHP;
	public string CharacterName;
	void Start () {
		//followCamera = FindObjectOfType<FollowCamera>();
	}

	void Update () {
		
	}
	//충돌 중일때는 정보를 가져온다.
	void OnTriggerStay(Collider other)
	{
		characterStatus = other.GetComponent<CharacterStatus> ();
		HP = characterStatus.HP;
		MaxHP = characterStatus.MaxHP;
		CharacterName = characterStatus.characterName;
	}
	//충돌을 벗어나면 초기화
	void OnTriggerExit(Collider other)
	{
		print ("taget exit");
		HP = 0;
		MaxHP = 0;
		CharacterName = null;
		characterStatus = null;

	}

}
