using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationHelper : MonoBehaviour {
	private SpriteRenderer[] Operations;
	private int count = 0;
	private Color operationColor=Color.white;
	private bool change = false;
	private bool Alpha = false;
	public float val = 1.0f;
	// Use this for initialization
	void Start () {
		operationColor.a = 0;
		count = 0;
		Operations = GetComponentsInChildren<SpriteRenderer>();
		for(int i=0;i< Operations.Length; ++i)
		{
			Operations[i].color = operationColor;
			Operations[i].gameObject.SetActive(false);
		}
		Operations[count].gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
		Operations[count].color = operationColor;
		operationColor.a += val / 255.0f;
		if (operationColor.a >= 1.0f)
		{
			Alpha = true;
			val *= -1;
		}
		if(operationColor.a <= 0.0f&&Alpha)
		{
			Operations[count].gameObject.SetActive(false);
			count++;
			if (count >= Operations.Length) count = 0;
			Alpha = false;
			val *= -1;
			Operations[count].gameObject.SetActive(true);
		}
		
	}
	
	void trueOn(int count)
	{
		Operations[count].gameObject.SetActive(true);
	}
}
