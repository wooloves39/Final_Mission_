using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLineSeclet : MonoBehaviour {
	public LinePointChecker linePointChecker;
	private void OnEnable()
	{
		Vector3 secletPos = Vector3.zero;
		switch (linePointChecker.getCurrentSkill())
		{
			case 1:
				secletPos.x = 1.0f;
			transform.localPosition = secletPos;
				break;
			case 2:
				secletPos.x = 0.5f;
				transform.localPosition = secletPos;
				break;
			case 3:
				secletPos.x = 0.0f;
				transform.localPosition = secletPos;
				break;
			case 4:
				secletPos.x = -0.5f;
				transform.localPosition = secletPos;
				break;
			case 5:
				secletPos.x = -1.0f;
				transform.localPosition = secletPos;
				break;
		}
	}
}