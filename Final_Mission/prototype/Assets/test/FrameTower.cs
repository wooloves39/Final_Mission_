using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTower : towerSC {
	
	public GameObject Frame;
	public float DmgCoolDown = 0.4f;
	float time = 0.0f;

	// Use this for initialization
	void Start()
	{
		StartCoroutine ("OnFrame");
	}

	IEnumerator OnFrame()
	{
		while (true) 
		{
			//getNewTarget ();
			if (target != null) {
				Frame.SetActive (true);
				this.transform.LookAt (target);
			}
			else 
			{
				Frame.SetActive (false);
			}



			time += 0.1f;
			if (time >= DmgCoolDown) {
				foreach(MoveMob e in Frame.GetComponent<FrameDmg> ().DmgArr)
				{
					//e.giveDmg ();
				}

				time = 0.0f;
			}

			yield return new WaitForSeconds (0.1f);
		}
	}
}
