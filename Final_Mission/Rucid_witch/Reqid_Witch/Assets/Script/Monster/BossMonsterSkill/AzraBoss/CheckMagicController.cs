using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMagicController : MonoBehaviour 
{
    public GameObject box;
    public GameObject X;
    public GameObject Z;

    public GameObject OBJ_box;
    public GameObject OBJ_X;
    public GameObject OBJ_Z;
    public float Delay = 3.5f;
    public float Line = 1.0f;
    int[] arr =
        {
            0, 1, 2,
            0, 2, 1,
            1, 0, 2,
            1, 2, 0,
            2, 1, 0,
            2, 0, 1
        };
    

    void OnEnable()
    {
        X.SetActive(false);
        OBJ_X.SetActive(false);
        Z.SetActive(false);
        OBJ_Z.SetActive(false);
        box.SetActive(false);
        OBJ_box.SetActive(false);
        StartCoroutine("Skill");
    }
    IEnumerator Skill()
    {

        int num = Random.Range(0, 5);

        for (int i = 0; i < 3; ++i)
        {
            if (arr[num * 3  + i] == 0)
                X.SetActive(true);
            else if (arr[num * 3+ i] == 1)
                Z.SetActive(true);
            else
                box.SetActive(true);
            yield return new WaitForSeconds(Line);
            

            if (arr[num * 3 + i] == 0)
            {
                X.SetActive(false);
                OBJ_X.SetActive(true);
                yield return new WaitForSeconds(Delay);
            }
            else if (arr[num * 3 + i] == 1)
            {
                Z.SetActive(false);
                OBJ_Z.SetActive(true);
                yield return new WaitForSeconds(Delay);
            }
            else
            {
                box.SetActive(false);
                OBJ_box.SetActive(true);
                yield return new WaitForSeconds(Delay/2);
            }

            if (arr[num * 3 + i] == 0)
            {
                OBJ_X.SetActive(false);
            }
            else if (arr[num * 3 + i] == 1)
            {
                OBJ_Z.SetActive(false);
            }
            else
            {
                OBJ_box.SetActive(false);
            }
        }
        this.gameObject.SetActive(false);
    }
}
