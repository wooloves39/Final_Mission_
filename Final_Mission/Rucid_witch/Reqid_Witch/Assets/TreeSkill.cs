using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSkill : MonoBehaviour {

    public float offset = -7.0f;
    public float glowTime = 1.0f;
    public Transform target;
	// Use this for initialization
	
    void Awake () {
        this.transform.position = this.transform.position + Vector3.up * offset;
        StartCoroutine("GrowUp");
    }
    void Disable()
    {
        this.transform.position =Vector3.up * offset;
    }
    IEnumerator GrowUp()
    {
        float cycle = 0.05f;
        float size = 7.0f / (glowTime / cycle);
        while (this.transform.position.y < 0.1f)
        {
            this.transform.Translate( target.up * size);
            yield return new WaitForSeconds(cycle);
            if(cycle > 0.01f)
                cycle -= 0.01f;
        }
    }
}
