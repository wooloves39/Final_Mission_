
using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(CharacterController))]
public class TestInputManager : MonoBehaviour
{
    public bool HmdResetsY = true;

    /// <summary>
    /// If true, tracking data from a child OVRCameraRig will update the direction of movement.
    /// </summary>
    public bool HmdRotatesY = true;

 
    protected CharacterController Controller = null;
    protected OVRCameraRig CameraRig = null;
    private OVRCameraRig cc = null;
     private float InitialYRotation = 0.0f;
    public Transform mCamera;
    // Use this for initialization
    // Update is called once per frame
    private void Awake()
    {
        //Controller = gameObject.GetComponent<CharacterController>();

        //if (Controller == null)
        //    Debug.LogWarning("OVRPlayerController: No CharacterController attached.");

        ////// We use OVRCameraRig to set rotations to cameras,
        ////// and to be influenced by rotation
        //OVRCameraRig[] CameraRigs = gameObject.GetComponentsInChildren<OVRCameraRig>();

        //if (CameraRigs.Length == 0)
        //    Debug.LogWarning("OVRPlayerController: No OVRCameraRig attached.");
        //else if (CameraRigs.Length > 1)
        //    Debug.LogWarning("OVRPlayerController: More then 1 OVRCameraRig attached.");
        //////else
        //////    CameraRig = CameraRigs[0];

        //cc = CameraRigs[0];
        //InitialYRotation = transform.rotation.eulerAngles.y;
    }
    private void Start()
    {
        //mCamera = transform.FindChild("CenterEyeAnchor");
        //Vector3 p = CameraRig.transform.localPosition;
        //p.z = OVRManager.profile.eyeDepth;
        //CameraRig.transform.localPosition = p;
    }
    void Update()
    {
        // mCamera.transform.LookAt(transform.position);
        //mCamera.transform.RotateAround(transform.position, Vector3.up, transform.rotation.z);

        //transform.rotation = CameraRig.transform.rotation;
        //Transform root =cc.trackingSpace;
        //Transform centerEye =cc.centerEyeAnchor;

        //if (HmdRotatesY)
        //{
        //    Vector3 prevPos = root.position;
        //    Quaternion prevRot = root.rotation;

        //    transform.rotation = Quaternion.Euler(0.0f, centerEye.rotation.eulerAngles.y, 0.0f);
        //    root.position = prevPos;
        //    root.rotation = prevRot;
        //}
        transform.Translate(InputManager_JHW.MainJoystick() * Time.deltaTime);
        //transform.position = CameraRig.transform.position;
        // transform.Translate(Time.deltaTime * 1, 0, 0);

    }
//    public void UpdateTransform(OVRCameraRig rig)
//    {
//        Transform root = CameraRig.trackingSpace;
//        Transform centerEye = CameraRig.centerEyeAnchor;

//        if (HmdRotatesY)
//        {
//            Vector3 prevPos = root.position;
//            Quaternion prevRot = root.rotation;

//            transform.rotation = Quaternion.Euler(0.0f, centerEye.rotation.eulerAngles.y, 0.0f);
//              root.position = prevPos;
//            root.rotation = prevRot;
//        }
//    }

//    public void ResetOrientation()
//    {
//        if (HmdResetsY)
//        {
//            Vector3 euler = transform.rotation.eulerAngles;
//            euler.y = InitialYRotation;
//            transform.rotation = Quaternion.Euler(euler);
//        }
//    }
}
