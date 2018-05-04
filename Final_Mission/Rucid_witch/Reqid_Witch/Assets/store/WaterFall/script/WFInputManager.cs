using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFInputManager : MonoBehaviour {

    public GameObject SampleParticle;
    public GameObject TubeManager;
    public Camera MainCamera;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHit = Physics.SphereCastAll(ray, 1.0f);
            for (int i = 0; i < raycastHit.Length; ++i)
            {
                if (raycastHit[i].transform.tag == "BackGround")
                {
                    Destroy(Instantiate(SampleParticle, raycastHit[i].point, Quaternion.identity), 0.5f);
                }
                else if (raycastHit[i].transform.tag == "BottomObject")
                {
                    raycastHit[i].transform.GetComponent<WFBottomTrigger>().ActiveTube();
                }
                else if (raycastHit[i].transform.tag == "TopObject")
                {
                    raycastHit[i].transform.GetComponent<WFTopTrigger>().SetTube();
                }
            }
            Vector3 mousePosition= new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            mousePosition = MainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            TubeManager.GetComponent<WFTubeManager>().InputMousePos(mousePosition);

        }
    }
}
