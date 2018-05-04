using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour {
    // public Transform tt;
    // Use this for initialization
    public GameObject player;
    float time = 0.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        //Vector3 vec = test.transform.position - transform.position;
        //vec.Normalize();
        //Quaternion rotate = Quaternion.LookRotation(vec);

        //transform.rotation = rotate;
       
        //transform.LookAt(test.transform);
        //  transform.Translate(InputManager_JHW.MainJoystick() * Time.deltaTime);
        Vector3 pos = InputManager_JHW.MainJoystick();
        Vector3 right;
        Vector3 moveDir = new Vector3();
        Vector3 forword;
        //if (InputManager_JHW.AButton())
        //{
        //   transform.Rotate(0, 10, 0);
        //}
       //Vector3 rota = InputManager_JHW.SubJoystick();
       //rota.y = rota.x;
       //rota.x = 0.0f;
       //rota.z = 0.0f;

       // Vector3 char_pos = transform.position;
       // transform.Translate(new Vector3(0.0f,0.0f,0.0f));
       // transform.Rotate(rota);
       // transform.Translate(char_pos);
        if (Singletone.Instance.Hor != 0 || Singletone.Instance.Ver != 0)
        {
            forword = player.transform.TransformDirection(Vector3.forward);
            forword.y = 0;
            forword = forword.normalized;
            right = new Vector3(forword.z, 0, -forword.x);
            moveDir = Singletone.Instance.Hor * right + Singletone.Instance.Ver * forword;
            //Dir = Vector3.forward * Singletone.Instance.Ver + Vector3.right * Singletone.Instance.Hor;
            //transform.rotation = Quaternion.LookRotation(Dir);
            Singletone.Instance.Hor = 0;
            Singletone.Instance.Ver = 0;

        }

        if (moveDir != Vector3.zero)
        {
            time = 0.0f;
            moveDir = moveDir.normalized;
            transform.position -= moveDir*Time.deltaTime*6.5f;

        }

        //Vector3 pos = tt.position;
        //pos.y = 0;
        //transform.position=pos;
    }
}
