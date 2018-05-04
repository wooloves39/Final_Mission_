using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkPoint : MonoBehaviour
{
	public Dia_Play player;
	private PlayerState MyState;
	public NextStage next;
	public GameObject nextParticle;
	//private PlayerState MyState;
	private void Awake()
	{
		MyState = player.transform.parent.GetComponent<PlayerState>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (player.getPlay())
			{
				MyState.SetMyState(PlayerState.State.Talk);
				player.setPlay(false);

			}
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (player.getEnd())
			{
				if (next)
					next.setNextOn(true);

				if (nextParticle)
					nextParticle.SetActive(true);

				MyState.SetMyState(PlayerState.State.Nomal);
				player.setPlay(true);
				gameObject.SetActive(false);
			}
		}
	}
}
