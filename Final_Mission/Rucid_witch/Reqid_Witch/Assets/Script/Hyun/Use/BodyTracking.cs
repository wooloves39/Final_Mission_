using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking : MonoBehaviour {
	public GameObject tracker;
	private GameObject body;
	private Vector3 pos=Vector3.zero;
	private PlayerState player;
	// Use this for initialization
	void Start () {
		body = gameObject.transform.Find("under_body").gameObject;
		player = gameObject.transform.parent.GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.IsBack())
		{
			if (tracker.transform.rotation.eulerAngles.y <= 100 || tracker.transform.rotation.eulerAngles.y >= 260) { body.SetActive(false); }
			else body.SetActive(true);
		}
		else
		{
			if (tracker.transform.rotation.eulerAngles.y <= 260 && tracker.transform.rotation.eulerAngles.y >= 100) { body.SetActive(false); }
			else body.SetActive(true);
		}

		pos = tracker.transform.position;
		transform.position = pos;
		transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
	}
}
