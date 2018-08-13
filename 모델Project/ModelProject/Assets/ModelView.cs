using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : MonoBehaviour {
	public GameObject Camera;
	public GameObject[] Map;
	public GameObject[] Unit;
	private int num = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (Viewing ());
	}
	IEnumerator Viewing()
	{
		float degree = 0.0f;
		yield return new WaitForSeconds (2.0f);

			Map [num].gameObject.SetActive (true);
			Unit [num].gameObject.SetActive (true);
		while (true) {
			Camera.transform.Rotate (new Vector3 (0, 0.4f, 0));
			degree += 0.4f;
				
			yield return new WaitForSeconds (0.035f);
			if (degree >= 360.0f) {
				if (num != 6)
					num++;
				else
					num = 0;
				degree = 0.0f;

				if (num != 0) {
					Map [num - 1].gameObject.SetActive (false);
					Map [num].gameObject.SetActive (true);
					Unit [num - 1].gameObject.SetActive (false);
					Unit [num].gameObject.SetActive (true);
				} else {
					Map [6].gameObject.SetActive (false);
					Map [num].gameObject.SetActive (true);
					Unit [6].gameObject.SetActive (false);
					Unit [num].gameObject.SetActive (true);
				}
			}
		}
	}
}