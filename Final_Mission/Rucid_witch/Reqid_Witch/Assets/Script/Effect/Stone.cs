using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    public int size;

    // Use this for initialization
    void OnEnable()
    {
        this.transform.position = new Vector3((float)(Random.Range(0, size * 2) - size)/10, 0, (float)(Random.Range(0, size * 2) - size)/10);
        this.transform.Rotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }
}
