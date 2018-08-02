using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraMob_Controll : MonoBehaviour {
    public GameObject[] Skill;
    public float[] Delay_Time;
    private Transform target;
    private PlayerState player;
	private Transform azra;
    private int num = 0;
    void Awake()
    {
		azra = FindObjectOfType<AzraMob_Controll>().transform;
        player = FindObjectOfType<PlayerState>();
        target = player.transform;
    }
    void Skill1()//AzraBall
    {
        num = 0;
        Skill[num].transform.position = azra.transform.position ;
        StartCoroutine("Attack", num);
    }
    void Skill2()//StarFall
    {
        num = 1;
        Skill[num].transform.position = azra.transform.position + new Vector3(0,-azra.transform.position.y,0);
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
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill7()//CheckMagic
    {
        num = 6;
        StartCoroutine("Attack", num);
    }
    void Skill8()
    {
        num = 7;
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    void Skill9()
    {
        num = 8;
        Skill[num].transform.position = target.transform.position;
        StartCoroutine("Attack", num);
    }
    IEnumerator Attack(int num)
    {
        yield return new WaitForSeconds(Delay_Time[num]);
        Skill[num].SetActive(true);
        if (num == 0)
        {
            yield return new WaitForSeconds(4.0f);
            Skill[num].SetActive(false);
        }
		if (num == 1)
		{
			yield return new WaitForSeconds(10.0f);
			Skill[num].SetActive(false);
		}

	}

}
