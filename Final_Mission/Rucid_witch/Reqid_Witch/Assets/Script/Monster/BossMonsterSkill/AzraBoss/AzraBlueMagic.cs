using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraBlueMagic : MonoBehaviour {

    public GameObject[] Magic;
    public float Delay = 1.5f;
    public float End = 4.5f;

    // Use this for initialization

    void OnEnable()
    {
        for (int i = 0; i < 4; ++i)
        {
            Magic[i].SetActive(false);
        }
        StartCoroutine("Skill");
    }
    IEnumerator Skill()
    {
        yield return new WaitForSeconds(Delay);
        Magic[0].SetActive(true);
        yield return new WaitForSeconds(Delay);
        Magic[2].SetActive(true);
        yield return new WaitForSeconds(Delay);
        Magic[3].SetActive(true);
        yield return new WaitForSeconds(Delay);
        Magic[1].SetActive(true);
        yield return new WaitForSeconds(End);
        this.gameObject.SetActive(false);
    }
}
