using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KaliMobControll : MonoBehaviour {
    public GameObject[] Skill;
    public float[] On_Time;
    public float[] Delay_Time;
    private Transform target;
    private PlayerState player;
    private Animator ani;
    private NavMeshAgent nav;
    private int num = 0;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        target = this.transform;
        player = FindObjectOfType<PlayerState>();
    }
    void Targetting_Myself(bool check)
    {
        if(check)
            target.transform.position = this.transform.position;
        else
            target.transform.position = player.transform.position;
    }
    void Skill1()
    {
        num = 0;
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill2()
    {
        num = 1;
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill3()
    {
        num = 2;
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill4()
    {
        num = 3;
        Targetting_Myself(true);
        Skill[num].transform.position = this.transform.position;
        StartCoroutine("Attack", num);
    } 
    void Skill5()
    {
        num = 4 ;
        StartCoroutine("Attack", num);
    }
    void Skill6()
    {
        num = 5;
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill7()
    {
        num = 6;
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    IEnumerator Attack(int num)
    {
        yield return new WaitForSeconds(Delay_Time[num]);
        Skill[num].SetActive(true);
        yield return new WaitForSeconds(On_Time[num]);
        Skill[num].SetActive(false);
    }
    
}
