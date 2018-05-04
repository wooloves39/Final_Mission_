using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack :  MonoBehaviour  {
	public bool attack = false;
	public float Speed = 5.0f;
	public int Power = 10;
	Vector3 prevposition;
	FollowCamera followCamera;
	CharacterStatus characterStatus;
	// Update is called once per frame
	void Start () {
		followCamera = FindObjectOfType<FollowCamera>();
	}
	void Update () {
		//마우스 오른쪽 버튼을 누르면 시작 + bool 함수 attack
		if (Input.GetButtonDown ("Fire2")&& !attack) 
		{
			attack = true;
			//카메라 방향과 위치를 불러온다.
			transform.rotation =followCamera.transform.rotation;
			transform.position =  followCamera.transform.position;
			prevposition = new Vector3(transform.position.x,transform.position.y,transform.position.z);

		}
		if (attack) {
			//정면으로 발사
			transform.Translate (Vector3.forward * Speed * Time.deltaTime * 2, Space.Self);
			if (Vector3.Distance (prevposition, transform.position) > Speed * 4) {
				attack = false;
				//끝나고 캐릭터 y -100으로 이동(동적으로 생성X)
				transform.position = prevposition + new Vector3(0,-100,0);
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		Hit ();
		if (other.tag == "Enemy") 
		{
			characterStatus = other.GetComponent<CharacterStatus> ();
			characterStatus.HP -= Power;
		}
	}

	void Hit()
	{
		//중간에 충돌 발생시 사라지게 만듬.
		attack = false;
		transform.position = prevposition + new Vector3(0,-100,0);
	}
}
