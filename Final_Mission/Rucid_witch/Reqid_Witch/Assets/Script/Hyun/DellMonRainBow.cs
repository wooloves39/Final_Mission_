using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellMonRainBow : MonoBehaviour {

	public float angle;
	private float deltaTime;
	public Transform[] RainBow;
	public Transform RainBowTarget;

	public Transform mainPoint;
	private Vector3[] CurPos;
	private Vector3 CurRainBowTarget;
	private Vector3 CurMainPoint;
	// Use this for initialization
	void Start () {
		CurPos = new Vector3[RainBow.Length];
		deltaTime = Time.deltaTime;
		for(int i = 0; i < CurPos.Length; ++i)
		{
			CurPos[i] = RainBow[i].position;
		}
		CurRainBowTarget = RainBowTarget.position;
		CurMainPoint = mainPoint.position;
	}
	private void OnEnable()
	{
		Invoke("resetAll", 6.0f);
	}
	// Update is called once per frame
	void Update () {
		for(int i=0;i< RainBow.Length; ++i)
		{
			Vector3 YPos = RainBow[i].position;
			YPos.y = RainBowTarget.position.y;
			RainBow[i].position = YPos;
			RainBow[i].LookAt(RainBowTarget);
			RainBow[i].Translate(Vector3.forward * 3*deltaTime);
			RainBow[i].RotateAround(RainBowTarget.position, Vector3.up, deltaTime * angle);
		}
		RainBowTarget.Translate(Vector3.Normalize(mainPoint.localPosition) *3* deltaTime,Space.World );
		if (Vector3.Distance(RainBowTarget.position, mainPoint.position) < 0.1f) {
			resetAll();
		}
	}
	void resetAll()
	{
		for (int i = 0; i < CurPos.Length; ++i)
		{
			 RainBow[i].position= CurPos[i];
		}
		 RainBowTarget.position= CurRainBowTarget;
		mainPoint.position= CurMainPoint;
		gameObject.SetActive(false);
		CancelInvoke();
	}
}
