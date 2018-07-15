using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaliMobControll : MonoBehaviour {
    public GameObject[] Skill;
    public float[] On_Time;
    public float[] Delay_Time;
    private Transform target;
    private PlayerState player;
    private int num = 0;
    void Awake()
    {
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
        StartCoroutine("Attack", num);
    }
    void Skill4()
    {
        num = 3;
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
        StartCoroutine("Shooting", num);
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
    IEnumerator Shooting(int num)
    {
        Rigidbody rigi = Skill[num].GetComponent<Rigidbody>();
        Vector3 Direction = Vector3.Normalize(new Vector3(player.transform.position.x, 0.0f, player.transform.position.z) - new Vector3(this.transform.position.x, 0.0f, this.transform.position.z));
        float time = 0.0f;
        float deltatime = 0.1f;
        while (time < 5.0f)
        {
            rigi.MovePosition(this.transform.position + Direction * 4.0f);
            time += deltatime;
            yield return new WaitForSeconds(deltatime);
        }
    }
}
