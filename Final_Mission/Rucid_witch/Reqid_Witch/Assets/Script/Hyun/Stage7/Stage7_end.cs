using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage7_end : MonoBehaviour {
	public GameObject[] curObj;
	public GameObject[] endObj;

private void EndOn()
	{
		for(int i = 0; i < curObj.Length; ++i)
		{
			curObj[i].SetActive(false);
			endObj[i].SetActive(true);
		}
	}
    public void EndOnInvoke()
    {
        Invoke("EndOn", 1.0f);
    }
}
