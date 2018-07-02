using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRain : MonoBehaviour {
    private float time;
    public float height;
    public float UpSpeed;
    public float DownSpeed;
    void OnEnable()
    {
        this.transform.position = Vector3.zero;
        time = Time.deltaTime;
        StartCoroutine("stone");
    }
    IEnumerator stone()
    {
        while (true)
        {
            if (this.transform.position.y < height)
                this.transform.position += Vector3.up * UpSpeed;
            else
                break;
            yield return new WaitForSeconds(time);
        }
        while (true)
        {
            if (this.transform.position.y > 0)
                this.transform.position -= Vector3.up * DownSpeed;
            else
                break;
            yield return new WaitForSeconds(time);
        }
    }
}
