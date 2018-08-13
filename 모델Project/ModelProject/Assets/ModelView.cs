using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : MonoBehaviour {
	public GameObject Camera;
	public GameObject[] Unit;
	private int num = 0;
    public float speed=5;
    public float cycle = 0.002f;
    // Use this for initialization
    void Start () {
		StartCoroutine (Viewing ());
	}
	IEnumerator Viewing()
	{
		float degree = 0.0f;
		yield return new WaitForSeconds (2.0f);

		Unit [num].gameObject.SetActive (true);
		while (true) {
            Camera.transform.position += Vector3.right*speed;
			degree += speed;
				
			yield return new WaitForSeconds (cycle);
			if (degree >= 600.0f)
            {
                if (num != 6)
                    num++;
                else
                {
                    num = 0;
                    Camera.transform.position = new Vector3(-100, 240, -700);
                }
				degree = 0.0f;

				if (num != 0) {
					Unit [num - 1].gameObject.SetActive (false);
					Unit [num].gameObject.SetActive (true);
				} else {
					Unit [6].gameObject.SetActive (false);
					Unit [num].gameObject.SetActive (true);
				}
			}
		}
	}
}