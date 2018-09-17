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
    public GameObject KaliSkillprefab1;
    public GameObject KaliSkillprefab2;
    public GameObject KaliSkillprefab3;
    public GameObject Effect;
    private bool check = false;
    void Awake()
    {
        Effect.SetActive(false);
        Skill[3] = Instantiate(KaliSkillprefab1);
        Skill[5] = Instantiate(KaliSkillprefab2);
        Skill[6] = Instantiate(KaliSkillprefab3);
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
        EffectToggle();
        Invoke("EffectToggle", 0.8f);
    }
    void Lose_Sound()
    {

        Effect.SetActive(false);
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
        EffectToggle();
        sound.PlayerSound(2);
        num = 3;
        AI.CoolTime(num);
        Targetting_Myself(true);
        Skill[num].transform.position = this.transform.position;
        StartCoroutine("Attack", num);
        Invoke("EffectToggle", 1.7f);
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
        EffectToggle();
        Invoke("EffectToggle", 0.8f);
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
        if(num == 4)
        {
            Skill[0].GetComponent<Kali_Skill_Attack>().DamageUp();
            Skill[1].GetComponent<Kali_Skill_Attack>().DamageUp();
            Skill[2].GetComponent<Kali_Skill_Attack>().DamageUp();
            Skill[3].GetComponent<Kali_Skill_Attack>().DamageUp();
            Skill[5].GetComponentInChildren<Kali_Skill_Attack>().DamageUp();
            Skill[6].GetComponent<Kali_Skill_Attack>().DamageUp();
        }
        Skill[num].SetActive(true);
        yield return new WaitForSeconds(On_Time[num]);
        if (num == 4)
        {
            Skill[0].GetComponent<Kali_Skill_Attack>().DamageDown();
            Skill[1].GetComponent<Kali_Skill_Attack>().DamageDown();
            Skill[2].GetComponent<Kali_Skill_Attack>().DamageDown();
            Skill[3].GetComponent<Kali_Skill_Attack>().DamageDown();
            Skill[5].GetComponentInChildren<Kali_Skill_Attack>().DamageDown();
            Skill[6].GetComponent<Kali_Skill_Attack>().DamageDown();
        }
        Skill[num].SetActive(false);
    }
    void EffectToggle()
    {
        if (check)
            Effect.SetActive(false);
        else
            Effect.SetActive(true);
        check = !check;
    }
}
