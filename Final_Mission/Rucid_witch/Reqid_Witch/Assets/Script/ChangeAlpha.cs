using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour 
{

	public float StartAlpha = 0.0f;
	public float EndAlpha = 1.0f;
	public float PlusAlpha = 0.1f;
	public float WaitSecond = 0.1f;
	public bool isCanvas = false;
	CanvasRenderer Canvas;
	MeshRenderer Mesh;
	
	// Use this for initialization
	void OnEnable ()
	{
		if (isCanvas)
		{
			Canvas = this.GetComponent<CanvasRenderer>();
			Canvas.SetAlpha(StartAlpha);
		}
		else
		{
			Mesh = this.GetComponent<MeshRenderer>();
			Mesh.material.color = new Color(Mesh.material.color.r, Mesh.material.color.g, Mesh.material.color.b, StartAlpha);
		}

		StartCoroutine (Alpha());

	}

	IEnumerator Alpha()
	{
		if(isCanvas)
		{
			while (true)
			{
				Canvas.SetAlpha(Canvas.GetAlpha() + PlusAlpha);
				if (Canvas.GetAlpha() >= EndAlpha)
					break;
				yield return new WaitForSeconds(WaitSecond);
			}
		}
		else
		{
			while (true)
			{
				Mesh.material.color = new Color(Mesh.material.color.r, Mesh.material.color.g, Mesh.material.color.b, Mesh.material.color.a+PlusAlpha);
				if (Mesh.material.color.a >= EndAlpha)
					break;
				yield return new WaitForSeconds(WaitSecond);
			}
		}

	}
}
