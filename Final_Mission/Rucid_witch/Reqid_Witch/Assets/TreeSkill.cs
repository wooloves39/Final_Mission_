using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSkill : MonoBehaviour {

    public float offset = -7.0f;
	public float glowTime = 1.0f;
    public float upsize = -2.0f;
	public Transform target;
	private Vector3 SetPos;
	// Use this for initialization
	void OnEnable ()
    {
        if (Singletone.Instance.stage == 3)
            upsize = -2.0f;
        else  if (Singletone.Instance.stage == 4)
            upsize = 0.0f;
		else if (Singletone.Instance.stage == 5)
            upsize = -4.0f;
		else if (Singletone.Instance.stage == 6)
        {
            offset = -7.0f;
            upsize = -4.0f;
        }
        else
        {
            offset = -7.0f;
            upsize = -4.0f;
        }
        StartCoroutine("GrowUp");
    }
    IEnumerator GrowUp()
    {
		this.transform.position += this.transform.up * offset;
        float cycle = 0.05f;
        float size = 7.0f / (glowTime / cycle);
        while (this.transform.position.y < upsize)
        {
            this.transform.Translate( target.up * size);
            yield return new WaitForSeconds(cycle);
            if(cycle > 0.01f)
                cycle -= 0.01f;
        }
    }
}
