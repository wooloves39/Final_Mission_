using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToSkill : MonoBehaviour {
    public GameObject[] list;
    private bool[] OneTime = {false,false,false,false,false};
    private float del_Time = 5.0f;
    private int num = -1;
	
	// Update is called once per frame
	void Update () {
        if (num != LineDraw.curType)
        {
            num = LineDraw.curType;
            list[LineDraw.curType].SetActive(true);
            StopAllCoroutines();
            StartCoroutine("del", del_Time);
            del_Time = 2.5f;
        }
	}
    IEnumerator del(float f)
    {
        for (int i = 0; i < 5; ++i)
        {
            list[i].SetActive(false);
        }
        if (OneTime[LineDraw.curType] == false)
            list[num].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        if (f < 4.0)
            OneTime[num] = true;
        yield return new WaitForSeconds(f-1.0f);
        for (int i = 0; i < 5; ++i)
        {
            list[i].SetActive(false);
        }
    }
}
