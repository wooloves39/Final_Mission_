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
			Instantiate (particle);
		}
	}
	IEnumerator PrectalTree()
	{
		yield return new WaitForSeconds (Time / (float)Max);
		for (int i = 0; i < Split; ++i) 
		{
			var copy = Instantiate (gameObject);
		//	copy.tag = ("Branch");
			var reBranch = copy.GetComponent<Tree> ();
			reBranch.SendMessage ("ChildBranch", i);
		}

	//if(NumBranch == Max-1)
	//{
	//	yield return new WaitForSeconds ((float)Max+0.5f);
	//	GameObject[] temp = GameObject.FindGameObjectsWithTag ("Branch");
	//	for (int i = 0; i < temp.Length; ++i) {
	//		temp [i].transform.SetParent (this.transform);
	//	}
	//}
	}
}
