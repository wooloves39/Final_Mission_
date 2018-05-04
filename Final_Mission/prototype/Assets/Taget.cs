using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taget : MonoBehaviour {
	//FollowCamera followCamera;
	public GameObject point;
	CharacterStatus characterStatus;
	public int HP;
	public int MaxHP;
	public string CharacterName;
	public Vector3 Position;
	void Start () {
		//followCamera = FindObjectOfType<FollowCamera>();
	}

	void Update () {
		
	}
	//충돌 중일때는 정보를 가져온다.
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Enemy")
		{
			characterStatus = other.GetComponent<CharacterStatus> ();
			point.transform.position = new Vector3 (characterStatus.position.x,characterStatus.position.y+characterStatus.size,characterStatus.position.z);
			Position = characterStatus.position;
			HP = characterStatus.HP;
			MaxHP = characterStatus.MaxHP;
			CharacterName = characterStatus.characterName;
		}
	}
	//충돌을 벗어나면 초기화
	void OnTriggerExit(Collider other)
	{
		point.transform.position = new Vector3 (0, -500, 0);
		Position = transform.position;
		HP = 0;
		MaxHP = 0;
		CharacterName = null;
		characterStatus = null;
	}

}
