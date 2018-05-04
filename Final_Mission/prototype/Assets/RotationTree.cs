using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTree : MonoBehaviour {
	public float EulerX = 20.0f;
	public float EulerY = 20.0f;
	public void ChildBranch(int n)
	{
		this.transform.rotation *= Quaternion.Euler (EulerX * ((n * 2) - 1), EulerY, 0);
	}
}
