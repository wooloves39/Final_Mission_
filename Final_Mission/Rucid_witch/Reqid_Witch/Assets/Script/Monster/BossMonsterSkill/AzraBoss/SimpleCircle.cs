using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCircle : MonoBehaviour {
	public GameObject Line;
	public GameObject Magic;
    public float Delay = 0.5f;
    public float End = 4.5f;

	// Use this for initialization

	void OnEnable()
	{
        StartCoroutine("Skill");
	}
	void DisEnable()
	{
		Line.SetActive(false);
		Magic.SetActive(false);
	}
	IEnumerator Skill()
	{
        Line.SetActive(true);
        yield return new WaitForSeconds(Delay);
        Line.SetActive(false);
        Magic.SetActive(true);
        yield return new WaitForSeconds(End);
        this.gameObject.SetActive(false);

	}
}
