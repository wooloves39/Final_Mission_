using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NatureCommand : MonoBehaviour
{
	float TimeLimit;
	bool state = false;
	float time = 0.0f;
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	public void StateChange(bool check)
	{
		if (check)
			state = true;
		else
			state = false;
	}
	public void NatureMove(MoveMsg msg)
	{

		if (this.gameObject.activeInHierarchy == true)
		{
			agent.destination = msg.destination;
			agent.speed = msg.Speed;
			TimeLimit = msg.time;
			time = 0.0f;
			StartCoroutine("NMove");
		}
	}

	IEnumerator NMove()
	{
		while (true)
		{
			float temp = Time.deltaTime;
			if (time >= TimeLimit)
			{
				agent.speed = 0.0f;
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
}
