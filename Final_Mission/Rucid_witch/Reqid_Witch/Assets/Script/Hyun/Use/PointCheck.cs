using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCheck : MonoBehaviour
{
	private bool check;
	private Viberation PlayerViberation;
	public GameObject particle;
	private bool particleOn = false;
	private PointDirectionArrow[] myArrows;
	private int ArrowCount;
	// Use this for initialization
	private void Awake()
	{
		ArrowCount = 0;
		myArrows = GetComponentsInChildren<PointDirectionArrow>();
		PlayerViberation = gameObject.transform.GetComponentInParent<Viberation>();
		particle.SetActive(false);
		for (int i = 0; i < myArrows.Length; ++i)
		{
			myArrows[i].gameObject.SetActive(false);
		}
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
		if (!particleOn)
		{
			particleOn = true;
			particle.SetActive(true);
		}
	}
	public void reset()
	{
		for(int i = 0; i < myArrows.Length; ++i)
		{
			myArrows[i].gameObject.SetActive(false);
		}
		this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
		check = false;
		particle.SetActive(false);
		gameObject.SetActive(false);
		particleOn = false;
	}
	public bool Getcheck()
	{
		return check;
	}
	public void turnon(Transform nextIndex)
	{
		if (!myArrows[ArrowCount].gameObject.activeSelf)
		{
			myArrows[ArrowCount].gameObject.SetActive(true);
			myArrows[ArrowCount++].TargetTr = nextIndex;
		}

		if (gameObject.activeSelf == false)
			gameObject.SetActive(true);
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
