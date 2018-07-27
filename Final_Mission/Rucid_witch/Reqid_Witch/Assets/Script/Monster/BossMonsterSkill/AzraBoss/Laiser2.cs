using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laiser2 : MonoBehaviour {
    public Transform Start;
    public Transform End;
    public GameObject Line;
    public GameObject Magic;
    void OnEnable()
    {
        this.transform.position = Start.transform.position;
        Look_At();
    }
    void DisEnable()
    {
        Line.SetActive(false);
        Magic.SetActive(false);
    }
    public void Look_At()
    {
        this.transform.LookAt(End);
        StartCoroutine("Skilling");
    }
    IEnumerator Skilling()
    {
        Line.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Line.SetActive(false);
        Magic.SetActive(true);
    }
}
