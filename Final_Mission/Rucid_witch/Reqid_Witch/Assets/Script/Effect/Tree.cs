using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
	public GameObject particle;
	public int NumBranch = 5;
	public int Max= 5;
	public int Split = 2;
	public float Time = 4.0f;

	// Use this for initialization
	void Start () 
	{
		NumBranch--;
		if (NumBranch > 0)
		{
			StartCoroutine ("PrectalTree");
		}
		if (NumBranch == 0) {
			particle.gameObject.transform.position = this.transform.position;
			Instantiate (particle).transform.parent = this.transform.parent.transform;
		}
	}
	IEnumerator PrectalTree()
	{
		yield return new WaitForSeconds (Time / (float)Max);
		for (int i = 0; i < Split; ++i) 
		{
			var copy = Instantiate(gameObject);
			copy.transform.parent = this.transform.parent.transform;
		//	copy.tag = ("Branch");
			var reBranch = copy.GetComponent<Tree> ();
			reBranch.SendMessage ("ChildBranch", i);
		}
	}
}
