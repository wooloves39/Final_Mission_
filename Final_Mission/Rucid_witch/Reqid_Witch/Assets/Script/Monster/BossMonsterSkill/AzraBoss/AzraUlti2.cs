using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraUlti2 : MonoBehaviour {
	public GameObject[] list;
	public float cycle;
	public float Delay;
	public float end;
	public float SizeX;
	public float SizeZ;
    public int tum = 5;
	void OnEnable()
	{
		StartCoroutine("Skilling");
	}
	void DisEnable()
	{
		for(int i = 0 ; i< list.Length;++i)
		{
			list[i].SetActive(false);
		}
	}
	IEnumerator Skilling()
	{
        Vector3 temp;
		yield return new WaitForSeconds(Delay);
		for(int i = 0 ; i< list.Length;++i)
		{
            temp = this.transform.position + new Vector3(Random.Range(0,SizeX*2) - SizeX,0.0f,Random.Range(0,SizeZ*2) - SizeZ);
            list[i].transform.position = list[i].transform.position + temp;
			list[i].SetActive(true);
            if (i % tum == 0)
            {
                yield return new WaitForSeconds(cycle);
            }
		}

		yield return new WaitForSeconds(end);
		this.gameObject.SetActive(false);
	}
}
