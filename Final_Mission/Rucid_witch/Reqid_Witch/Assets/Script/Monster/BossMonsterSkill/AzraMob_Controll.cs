using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraMob_Controll : MonoBehaviour {
    public GameObject[] Skill;
    public float[] Delay_Time;
    private Transform target;
    private PlayerState player;
    private int num = 0;
    void Awake()
    {
        player = FindObjectOfType<PlayerState>();
        target = player.transform;
    }
    void Targetting_Myself(bool check)
    {
        if(check)
            target.transform.position = this.transform.position;
        else
            target.transform.position = player.transform.position;
    }
    void Skill1()//AzraBall
    {
        num = 0;
        StartCoroutine("Attack", num);
    }
    void Skill2()//StarFall
    {
        num = 1;
        StartCoroutine("Attack", num);
    }
    void Skill3()//Blast
    {
        num = 2;
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill4()//Meteo
    {
        num = 3;
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    } 
    void Skill5()//FallenDown
    {
        num = 4 ;
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill6()//Bluemagic
    {
        num = 5;
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill7()//CheckMagic
    {
        num = 6;
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill8()
    {
        num = 7;
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill9()
    {
        num = 8;
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    IEnumerator Attack(int num)
    {
        yield return new WaitForSeconds(Delay_Time[num]);
        Skill[num].SetActive(true);
    }

}
