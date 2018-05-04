using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1_1 :  MonoBehaviour  {
	public bool attack;
	public float MagicSpeed = 50.0f;
	public int Power = 10;
	public int mynum = 0;
	public Vector3 prevposition;
	public Vector3 moveposition;
	Taget taget;
	public GameObject GetTaget;
	CharacterStatus characterStatus;


	public Vector3 Skill = Vector3.zero;


	void Start () {
	}
	void Update () {
		//마우스 오른쪽 버튼을 누르면 시작 + bool 함수 attack
		if (Input.GetButtonDown ("Jump") &&!attack && (Singletone.Instance.skill[Singletone.Instance.setskill]==mynum)) 
		{
			attack = true;
			taget = GetTaget.GetComponent<Taget> ();
			//카메라 방향과 위치를 불러온다.
			prevposition = taget.transform.position;
			moveposition = taget.Position;
			transform.position = taget.Position + Skill;
		}
		if (attack) 
		{
			// 타겟으로 발사
			transform.LookAt (moveposition);
			transform.Translate (Vector3.forward * MagicSpeed * Time.deltaTime);
			if (Vector3.Distance (this.transform.position, moveposition) < 0.25f) {
				Hit ();
			}
		}
	}
	void OnTriggerStay(Collider other)
	{
		print ("hit");
		if (other.tag == "Enemy") 
		{
			characterStatus = other.GetComponent<CharacterStatus> ();
			characterStatus.HP -= Power;
			Hit ();
		}
	}

	void Hit()
	{
		//중간에 충돌 발생시 사라지게 만듬.
		attack = false;
		transform.position = new Vector3(0,-500,0);
	}
}
