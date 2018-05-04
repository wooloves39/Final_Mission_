using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFBottomTrigger : MonoBehaviour {
    public GameObject Particle;
    public GameObject TubeManager;
    float delayTime = 0;
    // Use this for initialization
    void Start()
    {

    }

    public void ActiveTube()
    {
        if (delayTime == 0)
        {
            Destroy(Instantiate(Particle, transform.position, Quaternion.identity), 0.5f);
            delayTime += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTime != 0)
        {
            delayTime += Time.deltaTime;
        }
        if (delayTime >= 2)
        {
            delayTime = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RidingObject")
        {
            TubeManager.GetComponent<WFTubeManager>().DeleteTube(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
