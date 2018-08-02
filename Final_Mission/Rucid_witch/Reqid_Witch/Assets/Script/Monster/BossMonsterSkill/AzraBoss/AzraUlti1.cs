using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraUlti1 : MonoBehaviour {
    public GameObject tree;
    public GameObject[] line;
    public GameObject[] Magic;
    private Transform player;
	// Use this for initialization
    void OnEnable()
    {
        player = FindObjectOfType<PlayerState>().transform;
        StartCoroutine("Skill");
    }
    IEnumerator Skill()
    {
        yield return new WaitForSeconds(1.0f);
        tree.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        for(int i = 0 ; i< 3 ;++i)
        {
            Vector3 temp = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            line[i].transform.position = temp + Vector3.up * 12.5f;
            line[i].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            line[i].SetActive(false);
            Magic[i].transform.position = temp + Vector3.up * -2.5f;
            Magic[i].SetActive(true);
        }
        yield return new WaitForSeconds(3.0f);
        this.gameObject.SetActive(false);
    }
}
