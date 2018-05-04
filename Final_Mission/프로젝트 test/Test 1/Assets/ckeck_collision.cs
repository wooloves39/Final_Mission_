using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ckeck_collision : MonoBehaviour
{
    private int type = 1;
    private bool touch;
    private bool check = false;
    // Use this for initialization
    void Start()
    {
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "object")
        {
            this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void checkon()
    {
        type = 2;
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
    }
}