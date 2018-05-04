using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_script : MonoBehaviour
{
    public OVRInput.Controller controller;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = OVRInput.GetLocalControllerPosition(controller);
        // pos.z = -pos.z;
        Quaternion orient = OVRInput.GetLocalControllerRotation(controller);
        transform.localPosition = pos;
        transform.localRotation = orient;
    }
}
