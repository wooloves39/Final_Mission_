using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenDown : MonoBehaviour {

    public GameObject[] list;
    public float cycle;
    public float Delay;
    public float end;
    public float SizeX;
    public float SizeZ;
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
        yield return new WaitForSeconds(Delay);
        for(int i = 0 ; i< list.Length;++i)
        {
            if(i% 15 == 0)
                list[i].transform.position = new Vector3(0,-3.1f,0);
            else
                list[i].transform.position = new Vector3(Random.Range(0,SizeX*2) - SizeX,-3.1f,Random.Range(0,SizeZ*2) - SizeZ);
            list[i].SetActive(true);
            yield return new WaitForSeconds(cycle);
        }

        yield return new WaitForSeconds(end);
        this.gameObject.SetActive(false);
    }
	
}
