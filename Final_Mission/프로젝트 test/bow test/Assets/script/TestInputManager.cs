
using UnityEngine;
using System.Collections.Generic;

public class TestInputManager : MonoBehaviour
{
    public GameObject test;
    public Vector3 Dir;
    private void Awake()
    {
    }
    private void Start()
    {
    }
    void Update()
    {
        ////Vector3 vec = test.transform.position - transform.position;
        ////vec.Normalize();
        ////Quaternion rotate = Quaternion.LookRotation(vec);

        ////transform.rotation = rotate;
        //if (InputManager_JHW.AButton())
        //{
        //    transform.Rotate(0, 30, 0);
        //}
        ////transform.LookAt(test.transform);
        ////  transform.Translate(InputManager_JHW.MainJoystick() * Time.deltaTime);
        //Vector3 pos = InputManager_JHW.MainJoystick();
        //Vector3 right;
        //Vector3 moveDir=new Vector3();
        //Vector3 forword;
        //if (Singletone.Instance.Hor != 0 || Singletone.Instance.Ver!=0)
        //{
        //  forword = transform.TransformDirection(Vector3.forward);
        //    forword.y = 0;
        //    forword = forword.normalized;
        //   right = new Vector3(forword.z, 0, -forword.x);
        //   moveDir = Singletone.Instance.Hor * right + Singletone.Instance.Ver * forword;
        //    //Dir = Vector3.forward * Singletone.Instance.Ver + Vector3.right * Singletone.Instance.Hor;
        //    //transform.rotation = Quaternion.LookRotation(Dir);
        //    Singletone.Instance.Hor = 0;
        //    Singletone.Instance.Ver = 0;

        //}
      
        //if (moveDir != Vector3.zero)
        //{
        //    moveDir = moveDir.normalized;
        //    transform.position = moveDir;
        //}
        transform.position= InputManager_JHW.MainJoystick();
    }

}
