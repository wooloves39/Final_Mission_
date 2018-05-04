using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {
	// status
	public int HP = 100;
	public int MaxHP = 100;
	public int Power = 10;
	public Vector3 position;
	bool Hit = false;
	Attack attack;
	void Start()
	{
		position = transform.position;
	}

	// name
	public string characterName = "Enemy1";
	//충돌 체크 
	void OnTriggerEnter(Collider Object)
	{
		if (!Hit) {
			Hit = true;
			//print ("Hit");
			Hit = false;
		}
	}
	
}
