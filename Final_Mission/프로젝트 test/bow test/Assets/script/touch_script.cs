using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_script : MonoBehaviour
{
    public OVRInput.Controller controller;
    //public GameObject player;
    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = OVRInput.GetLocalControllerPosition(controller);
        //pos.x += transform.parent.gameObject.transform.position.x;
        //pos.z += transform.parent.gameObject.transform.position.z;
        Quaternion orient = OVRInput.GetLocalControllerRotation(controller);
         OVRInput.SetControllerVibration(1.0f, 1.0f, OVRInput.Controller.Touch);
        transform.localPosition = pos;
        transform.localRotation = orient;

     //   transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime);
    }
}
