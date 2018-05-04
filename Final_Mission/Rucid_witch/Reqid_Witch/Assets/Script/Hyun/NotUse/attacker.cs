using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacker : MonoBehaviour {
	private int Damege;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetDamege(int power)
	{
		Damege = power;
	}
	public int GetDamege() { return Damege; }
	public int attack(int Hp)
	{
		Hp -= Damege;
		Damege -= (int)(Damege * 0.5f);
		if (Damege < 0)
		{
			Debug.Log("삭제");
		}
		return Hp;
	}
}
