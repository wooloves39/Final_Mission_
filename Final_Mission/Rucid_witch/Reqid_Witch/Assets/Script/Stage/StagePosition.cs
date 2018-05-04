using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePosition : MonoBehaviour {
	public Vector2 Horizental;
	public Vector2 Vertical;

	public GameObject positVec;

	public int index = 0;
	private Vector3[] StagePos;
	private WayPoint[] Way;
	// Use this for initialization
	void Start ()
	{
		int temp = (int)(((Horizental.y - Horizental.x) / 5) * ((Vertical.y - Vertical.x) / 5));
		Way = new WayPoint[temp];
		StagePos = new Vector3[temp];
		for (int i = (int)Horizental.x; i < Horizental.y; i += 5)
		{
			for (int j = (int)Vertical.x; j < Vertical.y; j += 5)
			{
				StagePos.SetValue(new Vector3(i, 0, j),index);
				positVec.transform.position = StagePos[index];
				GameObject wp = (GameObject)(Instantiate(positVec));
				wp.transform.SetParent(this.transform);
				Way.SetValue(wp.GetComponent<WayPoint>(),index);
					
				index++;
			}
		}
	}
	public Vector3 GetRandomPos()
	{
		int temp = 0;
		int i;
		int cnt = 0;
		while (true)
		{
			i = Random.Range(0, index);
			if (Way[i].check == true)
			{
				temp = i;
				break;
			}
			cnt++;
			if (cnt > 100)
				break;
		}
		return StagePos[temp];
	}
}
