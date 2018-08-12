using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetHamony : MonoBehaviour {

	public float UseMp = 10.0f;
	public float Cycle = 2.5f;
	public GameObject Coll;
	private PlayerState player;
	public float timer { get; set; }
    private CoolDown CoolTime;
	private void Awake()
	{
        CoolTime = GetComponentInParent<CoolDown>();
		timer = 0.0f;
		player = GetComponentInParent<PlayerState>();
	}
	private void OnEnable()
	{
		timer = 0.0f;
	}
	private void OnDisable()
	{
		Coll.SetActive(false);
	}
	private void Update()
	{
		timer += Time.deltaTime;
		if (timer > 2.5f)
		{
			timer = 0.0f;
			if (CoolTime.CheckMp(5,1))
				player.Mp -= UseMp;
			else
			{
				gameObject.SetActive(false);
				//MP부족
			}
			player.SetMyState(0);
			Coll.SetActive(false);
		}
		else
		{
			player.SetMyState(PlayerState.State.Charging, 2.5f);
			Coll.SetActive(true);
		}
	}
}
