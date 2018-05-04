using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour {
    public OVRInput.Controller controller;
    public string buttonname;
    public LayerMask grabMask;
    public float grabRadius;
    private GameObject grabbedObject;
    private bool grabbing;
    private Quaternion lastRotation, currentRotation;
    void Grabobject()
    {
        grabbing = true;
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        if (hits.Length > 0)
        {
            int cloasestHit = 0;
            for(int i = 0; i < hits.Length; ++i)
            {
                if (hits[i].distance > hits[cloasestHit].distance) cloasestHit = i;
            }
            grabbedObject = hits[cloasestHit].transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.transform.position = transform.position;
            grabbedObject.transform.parent = transform;
        }






    }
    void Dropobject()
    {
        grabbing = false;
        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = GetAngularVelocity();

            grabbedObject = null;

        }
    }
    Vector3 GetAngularVelocity()
    {
        Quaternion deltaRotation = currentRotation * Quaternion.Inverse(lastRotation);
        return new Vector3(Mathf.DeltaAngle(0, deltaRotation.eulerAngles.x), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.y), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.z));
    }
    // Update is called once per frame
    void Update() {
        if (grabbedObject != null)
        {
            lastRotation = currentRotation;
            currentRotation = grabbedObject.transform.rotation;
        }
        if (!grabbing && Input.GetAxis(buttonname) == 1) { Debug.Log("ok"); Grabobject(); }
        if (grabbing && Input.GetAxis(buttonname) < 1) { Debug.Log("Nok"); Dropobject(); }
    }
}
