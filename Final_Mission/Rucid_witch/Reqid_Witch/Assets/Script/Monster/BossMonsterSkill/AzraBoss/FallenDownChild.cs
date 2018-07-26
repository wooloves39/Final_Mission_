using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenDownChild : MonoBehaviour {
    public GameObject Point;
    public GameObject Magic;
    public float Delay = 1.5f;
    void OnEnable()
    {
        Point.transform.localScale = Vector3.one * 0.5f;
        Point.SetActive(true);
        StartCoroutine("Skilling");
    }
    void DisEnable()
    {
        Magic.gameObject.SetActive(false);
        Point.gameObject.SetActive(false);        
    }
    IEnumerator Skilling()
    {
        yield return new WaitForSeconds(Delay);
        Point.gameObject.SetActive(false);   
        Magic.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        this.gameObject.SetActive(false);
    }
}
