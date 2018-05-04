using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//트래킹 웨이의 길을 색으로 표현해준다.
public class WayPointTrack : MonoBehaviour {
	public Color lineColor = Color.yellow;
	private Transform[] points;
	private void OnDrawGizmos()
	{
		Gizmos.color = lineColor;

		points = GetComponentsInChildren<Transform>();
		int nextIdx = 1;

		Vector3 currPos = points[nextIdx].position;
		Vector3 nextPos;

		for(int i = 0; i <= points.Length; ++i)
		{
			nextPos = (++nextIdx >= points.Length) ? points[1].position : points[nextIdx].position;
			Gizmos.DrawLine(currPos, nextPos);
			currPos = nextPos;
		}
	}
}
