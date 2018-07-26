using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmingLine : MonoBehaviour
{
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
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, this.transform.position);
	}
	private void OnEnable()
	{
		Add_time = 0.0f;
        StartCoroutine("Drawing");
	}

	IEnumerator Drawing()
	{
		yield return new WaitForSeconds(Delay_time);
        line.SetPosition(1, this.transform.position+this.transform.forward *4);
		while (true)
		{

			//line.SetPosition(0, line.GetPosition(0) + LineVector);
            line.SetPosition(1, line.GetPosition(1) + this.transform.forward *0.25f);

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
