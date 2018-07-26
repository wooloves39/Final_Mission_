using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmingLine : MonoBehaviour
{
	public Vector3 StartVector = Vector3.forward * 4;
	public Vector3 LineVector = new Vector3(0,0,0.05f);
	public float Delay_time = 0.0f;
	public float Cycle_time = 0.02f;
	public float End_time = 0.0f;
	public float Add_time = 0.0f;
	public LineRenderer line;
	// Use this for initialization
	void Awake ()
	{
		line = GetComponent<LineRenderer>();
		
	}
	private void OnDisable()
	{
		line.SetPosition(0, Vector3.zero);
		line.SetPosition(1, Vector3.zero);
	}
	private void OnEnable()
	{
		Add_time = 0.0f;
		StartCoroutine("Drawing");
	}
	public void SetLineVector(float f)
	{
		LineVector = new Vector3(0, 0, f);
	}

	IEnumerator Drawing()
	{
		yield return new WaitForSeconds(Delay_time);
		line.SetPosition(1, StartVector);
		while (true)
		{

			//line.SetPosition(0, line.GetPosition(0) + LineVector);
			line.SetPosition(1, line.GetPosition(1) + LineVector);

			if (Add_time > End_time)
			{
				this.gameObject.SetActive(false);
				break;
			}
			else
			{
				Add_time += Cycle_time;
				yield return new WaitForSeconds(Cycle_time);
			}
		}
	}
}
