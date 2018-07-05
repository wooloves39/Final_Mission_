using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI_Enable : MonoBehaviour {
	private PlayerState playerState;
	public GameObject ChargingSet;
	public GameObject SkillLine;
	// Use this for initialization
	private void Awake()
	{
		playerState = GetComponentInParent<PlayerState>();
		ChargingSet.SetActive(false);
		SkillLine.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (playerState.GetMyState() == PlayerState.State.Drawing)
		{
			SkillLine.SetActive(true);
			ChargingSet.SetActive(false);
		}
		else if(playerState.GetMyState() == PlayerState.State.Charging)
		{
			ChargingSet.SetActive(true);
			SkillLine.SetActive(false);
		}
		else
		{
			SkillLine.SetActive(false);
			ChargingSet.SetActive(false);
		}
	}
}
