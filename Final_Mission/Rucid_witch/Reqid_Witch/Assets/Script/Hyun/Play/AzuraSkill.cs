﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzuraSkill : MonoBehaviour
{
    private int skill;
    private GameObject target;
    private float handDis;
    private PlayerState player;
    float deltaTime;
    public GameObject Blast;
    public GameObject[] witchsHone;
    public GameObject[] SoulExp;
    public float[] Speed = {25,20,15,25,25};
    private bool Shoot = false;
    private bool del_timer = false;

    private Collider collider;
    public GameObject AzuraBall;


    private void Awake()
    {
        player = FindObjectOfType<PlayerState>();
        deltaTime = Time.deltaTime;
        collider = GetComponent<Collider>();     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void shoot(int skillIndex, GameObject targets, float handDistance)
    {
        transform.localScale = transform.localScale * 3;
        target = targets;
        skill = skillIndex;
        handDis = handDistance;
        switch (skill)
        {
            case 1:
                WitchsHone();
                break;
            case 2:
                SoulExplosion(target.transform.position);
                break;
            case 3:
                witchAging( 10f);
                break;
            case 4:
                callofGad(target.transform.position,10f, 10f, 5f);
                break;
            case 5:
                LastBlast(target.transform.position);
                break;
        }
        if (skill > 1) UseOtherObject();
        Shoot = true;
        StartCoroutine(Shooting());
        target = null;
    }
    private void WitchsHone()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);//;
        r.velocity = TargettingDir * Speed[0] * handDis;

    }
    //########################################################
    void SoulExplosion(Vector3 target)//12개의 스킬 날리기
    {
        for (int i = 0; i < SoulExp.Length; ++i)
        {
            SoulExp[i].SetActive(true);
            //SoulExp[i].transform.Rotate(0, 0, 45);
            StartCoroutine(SoulExplosionCor(SoulExp[i], target));
        }
    }
    IEnumerator SoulExplosionCor(GameObject soul, Vector3 target) 
    {
        Vector3 normal = Vector3.Normalize( target - soul.transform.position);
        Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        float speed = Random.Range(5, 10);
        float Timer = 0.0f;
        float MaxTime = Vector3.Distance(soul.transform.position, target) / 20f;
        while (true)
        {
            Timer += deltaTime;
            if (Vector3.Distance(soul.transform.position, target) < 0.5f) 
            {
                break;
            }
            if (Vector3.Distance (soul.transform.position, target) < Vector3.Distance (soul.transform.position, target)/2) 
            {
                speed = Speed[1];
                soul.transform.LookAt (target);
                soul.transform.Translate(Vector3.forward * deltaTime * speed);
            }
            else 
            {
                speed = Speed[1]/2;
                soul.transform.LookAt (Vector3.Normalize (dir) + normal);
                soul.transform.Translate(Vector3.forward * deltaTime * speed);
            }
            if (Timer >= MaxTime)
                break;
            else
                yield return null;
        }
    }
    //########################################################
    void witchAging(float deltime)//12개
    {
        for (int i = 0; i < witchsHone.Length; ++i)
        {
            witchsHone[i].transform.position = player.transform.position;
            witchsHone[i].transform.Rotate(0, i * 30, 0);
            witchsHone[i].SetActive(true);
            StartCoroutine(witchAgingCour(witchsHone[i], deltime));
        }
    }
    IEnumerator witchAgingCour(GameObject hone, float deltime)
    {
        float timer = 0.0f;
        Rigidbody r = hone.GetComponent<Rigidbody>();
        r.velocity = hone.transform.forward * Speed[2] * handDis;
        while (true)//필요없을수도
        {
            hone.transform.Rotate(0, 1, 0);
            if (timer > deltime) 
                break;
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        hone.SetActive(false);
    }
    //########################################################
    void callofGad(Vector3 targetPos,float speed, float scale, float time)
    {
        SoulExp[0].SetActive(true);
        SoulExp[0].transform.LookAt(targetPos);
        StartCoroutine(callofGadCor(SoulExp[0],targetPos, speed, scale, time));
    }
    IEnumerator callofGadCor(GameObject Soul, Vector3 targetPos, float speed, float scale, float time)
    {
        float timer = 0.0f;
        float cur_Scale = 1.0f;
        while (true)
        {
            timer += deltaTime;
            cur_Scale = scale * (timer / time);
            Vector3 scaleVector = Vector3.one;
            if (cur_Scale < 1.0f) cur_Scale = 1.0f;
            Soul.transform.localScale = scaleVector * cur_Scale;
            Soul.transform.Translate(Vector3.forward * deltaTime * speed);
            if (timer > time) break;
            yield return null;
        }
    }
    //########################################################  
    private void LastBlast(Vector3 target)
    {
        Blast.SetActive(true);
        Blast.transform.position = target;
        StartCoroutine(LastBlastCor(Blast,2.0f));
    }
    IEnumerator LastBlastCor(GameObject Blast, float Timer)
    {
        float timer = 0.0f;
        while (true)
        {
            timer += deltaTime;
            Blast.transform.Rotate(0, 10 * timer, 0);
            if (timer >= Timer)
            {
                timer = 0;
                Blast.transform.rotation = Quaternion.identity;
                Blast.gameObject.SetActive(false);
                break;
                //내위치 변경
            }
            yield return null;
        }
    }
    IEnumerator Shooting(float delTime=5.0f)
    {
        yield return new WaitForSeconds(delTime);
        del_timer = true;
        Shoot = false;
    }
    public bool IsDelete() { return del_timer; }
    public bool IsShoot() { return Shoot; }
    public void resetDelete() {
        AzuraBall.SetActive(true);
        collider.enabled = true;
        Blast.transform.position = transform.position;
        Blast.transform.localScale = transform.localScale;
        Blast.transform.rotation = transform.rotation;
        Blast.SetActive(false);
        for (int i = 0; i < witchsHone.Length; ++i)
        {
            witchsHone[i].transform.position = transform.position;
            witchsHone[i].transform.localScale = transform.localScale;
            witchsHone[i].transform.rotation = transform.rotation;
            witchsHone[i].SetActive(false);
        }
        for (int i = 0; i < SoulExp.Length; ++i)
        {
            SoulExp[i].transform.position = transform.position;
            SoulExp[i].transform.localScale = transform.localScale;
            SoulExp[i].transform.rotation = transform.rotation;
            SoulExp[i].SetActive(false);
        }
        del_timer = false; }
    private void UseOtherObject()
    {
        AzuraBall.SetActive(false);
        collider.enabled = false;
    }
}
