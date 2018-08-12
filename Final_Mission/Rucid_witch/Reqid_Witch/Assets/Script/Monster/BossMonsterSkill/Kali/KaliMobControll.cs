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
    private KaliBoss AI;
    private BossSoundSetting sound;
    private GameObject KaliSkill;
    public GameObject KaliSkillprefab;
    void Awake()
    {
        KaliSkill = Instantiate(KaliSkillprefab);
        Skill[3] = KaliSkill.GetComponent<KaliSkillIndex>().skill[0];
        Skill[5] = KaliSkill.GetComponent<KaliSkillIndex>().skill[1];
        Skill[6] = KaliSkill.GetComponent<KaliSkillIndex>().skill[2];
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        target = this.transform;
        player = FindObjectOfType<PlayerState>();
        AI = GetComponent<KaliBoss>();
        sound = GetComponent<BossSoundSetting>();
    }
    void Targetting_Myself(bool check)
    {
        if(check)
            target.transform.position = this.transform.position;
        else
            target.transform.position = player.transform.position;
    }  
    void Apprier()
    {
        sound.PlayerSound(0);
    }
    void Hit()
    {

        sound.PlayerSound(1);
    }
    IEnumerator Jump()
    {
        this.transform.LookAt(player.transform);
        for(int i = 0; i< 30; ++i)
        {
            this.transform.position += this.transform.forward * -3 * 0.1f;
            yield return new WaitForSeconds(1.0f / 40.0f);
        }
    }
    void Lose_Sound()
    {
        sound.PlayerSound(3);
    }
    void Skill1()
    {
        sound.PlayerSound(2);
        num = 0;
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill2()
    {
        sound.PlayerSound(2);
        num = 1;
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill3()
    {
        sound.PlayerSound(2);
        num = 2;
        AI.CoolTime(num);
        Targetting_Myself(true);
        StartCoroutine("Attack", num);
    }
    void Skill4()
    {
        sound.PlayerSound(2);
        num = 3;
        AI.CoolTime(num);
        Targetting_Myself(true);
        Skill[num].transform.position = this.transform.position;
        StartCoroutine("Attack", num);
    } 
    void Skill5()
    {
        sound.PlayerSound(2);
        num = 4 ;
        AI.CoolTime(num);
        StartCoroutine("Attack", num);
    }
    void Skill6()
    {
        sound.PlayerSound(2);
        num = 5;
        AI.CoolTime(num);
        Targetting_Myself(true);
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill7()
    {
        sound.PlayerSound(4);
        num = 6;
        AI.CoolTime(num);
        AI.Ulti = true;
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
