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
	private bool AwakeFlug = false;
	private MeshRenderer meshRenderer;
	// Use this for initialization
	private void Awake()
	{
		ArrowCount = 0;
		PlayerViberation = gameObject.transform.GetComponentInParent<Viberation>();
		meshRenderer = transform.GetComponent<MeshRenderer>();
		particle.SetActive(false);
		myArrows = GetComponentsInChildren<PointDirectionArrow>();

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
		meshRenderer.material.color = new Color(0, 0, 0);
		if (!particleOn)
		{
			particleOn = true;
			particle.SetActive(true);
		}
		
	}
	public void reset()
	{
		if (gameObject.activeSelf)
		{
			ArrowOff();
			meshRenderer.material.color = new Color(1, 1, 1);
		}
		check = false;
		particle.SetActive(false);
		gameObject.SetActive(false);
		particleOn = false;
		ArrowCount = 0;
	}
	public bool Getcheck()
	{
		return check;
	}
	public void turnon(Transform nextIndex)
	{

		if (gameObject.activeSelf == false)
			gameObject.SetActive(true);
		if (!myArrows[ArrowCount].gameObject.activeSelf)
		{
			myArrows[ArrowCount].TargetTr = nextIndex;
			myArrows[ArrowCount++].gameObject.SetActive(true);
		}

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
		ArrowCount = 0;
	}
	public void ArrowOff()
	{
		for (int i = 0; i < myArrows.Length; ++i)
		{
			myArrows[i].gameObject.SetActive(false);
		}
	}
}
