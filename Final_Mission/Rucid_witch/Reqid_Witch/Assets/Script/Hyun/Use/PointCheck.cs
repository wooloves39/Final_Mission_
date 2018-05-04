using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCheck : MonoBehaviour
{
	private bool check;
	private Viberation PlayerViberation;
	// Use this for initialization
	private void Awake()
	{
		PlayerViberation = gameObject.transform.parent.parent.parent.GetComponent<Viberation>();
	}
	void Start()
	{
		check = false;
	}
	public void touchon()
	{
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.1f, 0.1f, OVRInput.Controller.RTouch));
		check = true;
		this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
	}
	public void reset()
	{
		this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
		check = false;
		gameObject.SetActive(false);
	}
	public bool Getcheck()
	{
		return check;
	}
	public void turnon()
	{
		if (gameObject.activeSelf == false)
			gameObject.SetActive(true);
	}
	public void turnoff()
	{
		if (gameObject.activeSelf == true)
			gameObject.SetActive(false);
	}
}
