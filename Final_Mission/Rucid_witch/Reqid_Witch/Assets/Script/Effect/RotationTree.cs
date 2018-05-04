using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTree : MonoBehaviour {
	public float EulerX = 20.0f;
	public float EulerY = 20.0f;

	public float height = 0.8f;
	public float size = 0.8f;
	public void ChildBranch(int n)
	{
		this.transform.rotation *= Quaternion.Euler (EulerX * ((n * 2) - 1), EulerY, 0);
		GetComponent<GrowerTree>().X *= height;
		this.transform.localScale = this.transform.localScale * size;
	}
}
