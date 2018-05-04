using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	public GameObject TeleportMarker;
	public Transform Player;
	public float RayLength = 50f;
	// Use this for initialization
	void Start () {
		OVRTouchpad.Create();
		//OVRTouchpad.TouchHandler += TouchPadHandler;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, RayLength))
		{
			if (hit.collider.CompareTag("Ground"))
			{
				if (!TeleportMarker.activeSelf)
				{
					TeleportMarker.SetActive(true);
				}
				TeleportMarker.transform.position = hit.point;
			}
			else
			{
				TeleportMarker.SetActive(false);
			}
		}
	}
	void TouchPadHandler(Object sender,System.EventArgs e)
	{
		OVRTouchpad.TouchArgs args = (OVRTouchpad.TouchArgs)e;
		if (args.TouchType == OVRTouchpad.TouchEvent.SingleTap)
		{
			if (TeleportMarker.activeSelf)
			{
				Vector3 markerPosition= TeleportMarker.transform.position;
				Player.position = new Vector3(markerPosition.x, markerPosition.y, markerPosition.z);
					
			}
		}
	}
}
