using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowerTree : MonoBehaviour {
	public float X;
	public void ChildBranch(int n)
	{
		this.transform.position += this.transform.up*X;
	}
}
