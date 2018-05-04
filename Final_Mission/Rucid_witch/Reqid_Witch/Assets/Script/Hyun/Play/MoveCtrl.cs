using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
	public enum MoveType
	{
		WAY_POINT,
		LOOK_AT,
		DAYDREAM
	}
	public MoveType moveType;

	public float speed = 1.0f;
	public float damping = 3.0f;

	private Transform tr;
	private Transform camTr;
	private CharacterController cc;
	private Transform[] points;
	private int nextIdx = 1;
	private PlayerState MyState;
	//대화 스크립트 종속
	public Dia_Play myDia;
	public Animator body;
	//private Coroutine moveCoroutine;
	// Use this for initialization
	void Start()
	{
		MyState = GetComponent<PlayerState>();
		tr = GetComponent<Transform>();
		camTr = Camera.main.GetComponent<Transform>();
		cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (MyState.GetMyState()==PlayerState.State.Talk) {
			return;
		}
		switch (moveType)
		{
			case MoveType.WAY_POINT:
				MoveWayPoint();
				break;
			case MoveType.LOOK_AT:
				MoveLookAt();
				break;
			case MoveType.DAYDREAM:
				MoveTouchPad();
				break;
		}
		if (InputManager_JHW.BButtonDown())
		{
			turnBack();
		}
	}

	void MoveWayPoint()
	{
		Vector3 direction = points[nextIdx].position - tr.position;
		Quaternion rot = Quaternion.LookRotation(direction);
		tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

		tr.Translate(Vector3.forward * Time.deltaTime * speed);
	}
	void MoveLookAt()
	{
		Vector3 dir = camTr.TransformDirection(Vector3.forward);
		cc.SimpleMove(dir * speed);
	}
	//우리 방식
	void MoveTouchPad()
	{
		Vector3 touchDir = InputManager_JHW.MainJoystick() * 2;
		if (touchDir.magnitude > 0.0f)
		{
			Vector3 camdir = camTr.TransformDirection(Vector3.forward);
			Vector3 dir = camdir + touchDir;
			dir.Normalize();
			Vector3 moveDir = camTr.TransformDirection(dir);
			cc.SimpleMove(moveDir * speed);
			body.Play("Fastmove");
		}
	}
	private void turnBack()
	{
		Vector3 pos = Vector3.zero;
		MyState.Back();
		if (gameObject.transform.rotation.y == 0)
		{
			pos.y = 180;
		}
		else if (gameObject.transform.rotation.y == 180)
		{
			pos.y = 0;
		}
		gameObject.transform.rotation = Quaternion.Euler(pos);
		body.Play("turn");
	}
}
