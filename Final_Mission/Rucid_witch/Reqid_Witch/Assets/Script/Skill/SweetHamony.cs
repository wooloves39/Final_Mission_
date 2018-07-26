using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetHamony : MonoBehaviour {

	public float UseMp = 10.0f;
	public float Cycle = 2.5f;
	public GameObject Coll;
	private PlayerState player;
	private void Awake()
	{
		player = GetComponentInParent<PlayerState>();
	}
	private void OnEnable()
	{
		StartCoroutine("Skilling");
	}
	private void OnDisable()
	{
		Coll.SetActive(false);
	}
	IEnumerator Skilling()
	{
		while(true)
		{
			if (player.Mp >= UseMp)
				player.Mp -= UseMp;
			else
			{
				Coll.SetActive(false);
				break;
			}
			Coll.SetActive(true);
			yield return new WaitForSeconds(Cycle);
			Coll.SetActive(false);
		}
	}
}
