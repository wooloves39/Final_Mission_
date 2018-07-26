using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laiser : MonoBehaviour {
    PlayerState player;
    AzraSkillPos Pos;
    public Vector3 target;
    public GameObject Line;
    public GameObject Magic;
    public int num;
    void Awake()
    {
        player = FindObjectOfType<PlayerState>();
    }
    void OnEnable()
    {
        if (Pos == null)
        {
            Pos = FindObjectOfType<AzraSkillPos>();
        }
        this.transform.position = Pos.list[num].transform.position;
        Look_At();
    }
    void DisEnable()
    {
        Line.SetActive(false);
        Magic.SetActive(false);
    }
    public void Look_At()
    {
        this.transform.LookAt(player.transform);
        target = player.transform.position;
        StartCoroutine("Skilling");
    }
    IEnumerator Skilling()
    {
        Line.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Line.SetActive(false);
        Magic.SetActive(true);
    }
}
