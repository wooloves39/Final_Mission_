using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSkill : MonoBehaviour {

    public float offset = -7.0f;
	public float glowTime = 1.0f;
	public Transform target;
	private Vector3 SetPos;
	// Use this for initialization
	void OnEnable ()
	{
		StartCoroutine("GrowUp");
    }
    void OnDisable()
	{
		StopCoroutine("GrowUp");
	}
    IEnumerator GrowUp()
    {
		this.transform.position += this.transform.up * offset;
        float cycle = 0.05f;
        float size = 7.0f / (glowTime / cycle);
        while (this.transform.position.y < -2.0f)
        {
            this.transform.Translate( target.up * size);
            yield return new WaitForSeconds(cycle);
            if(cycle > 0.01f)
                cycle -= 0.01f;
        }
    }
}
