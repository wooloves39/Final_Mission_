using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwanSkill : MonoBehaviour
{

    // Use this for initialization
    private int skill;
    private GameObject target;
    private float handDis;
    public float HandeDis { get { return handDis; } set { handDis = value; } }
    float deltaTime;
    public GameObject Gate;
    public GameObject[] sky_Arraws;
    public GameObject arrow_trab_particle;

    private bool Shoot = false;
    private bool del_timer = false;
    public bool Del_timer { get { return del_timer; } set { del_timer = value; } }
    //private Collider collider;
    public GameObject SeiKwanArrow;
    private CoolDown CoolTime;

    private Vector3 curScale;
	private Rigidbody rigi;
    private void Awake()
    {
        deltaTime = Time.deltaTime;
        CoolTime = FindObjectOfType<CoolDown>();
		rigi = GetComponent<Rigidbody>();

	}
    public void shoot(int skillIndex, GameObject targets, float handDistance, float del_time = 10.0f)
    {
        bool Mp = false;
        bool Cool = false;
        transform.localScale = transform.localScale * 3;
        target = targets;
        skill = skillIndex;
        handDis = handDistance;
        if (CoolTime.CheckCool(3,skill))
        {
            Cool = true;
        }
        if (CoolTime.CheckMp(3,skill))
        {
            Mp = true;
        }
        if (!Cool && !Mp)
        {
            CoolTime.SetCool(3, skill);
            switch (skill)
            {
                case 1:
                    BraveArrow();
                    break;
                case 2:
                    ArrowTrab();
                    break;
                case 3:
                    SkyArrow(targets.transform.position);
                    break;
                case 5:
                    HavensGate(targets.transform.position);
                    break;
            }
            if (skill == 5) del_time += 20f;
            //if (skill > 1) UseOtherObject();
            Shoot = true;
            StartCoroutine(Shooting(del_time));
        }
        else
        {
            if (Mp)
                Debug.Log("Mp부족 처리 부분");
            if (Cool)
                Debug.Log("쿨타임 중 처리 부분");
        }
        target = null;
    }
    //#### #### #### #### 기본
    private void BraveArrow()
    {
        GetComponentInChildren<Skill_Sound_Set>().check = true; 
        Vector3 Arrowforward = transform.forward;
        Vector3 TargettingDir = Vector3.zero;
        if (target)
        {
            TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
        }
        if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
        {
			rigi.velocity = Arrowforward * 15f * handDis;
        }
        else
        {
            TargettingDir += Arrowforward;
			rigi.velocity = TargettingDir * 15f * handDis;
        }
    }
    //#### #### #### #### 
    private void ArrowTrab()
    {
        Vector3 Arrowforward = transform.forward;
        Vector3 TargettingDir = Vector3.zero;
        if (target)
        {
            TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
        }
        if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
        {
			rigi.velocity = Arrowforward * 15f * handDis;
        }
        else
        {
            TargettingDir += Arrowforward;
			rigi.velocity = TargettingDir * 15f * handDis;
        }
        Debug.Log(handDis);
        StartCoroutine(ArrowTrabCor(.5f));
    }
    IEnumerator ArrowTrabCor(float timer)
    {
        yield return new WaitForSeconds(timer);
        arrow_trab_particle.SetActive(true);
        //arrow_trab_particle.transform.LookAt(SeiKwanArrow.transform);
    }
    //#### #### #### #### 
    private void SkyArrow(Vector3 targetPoint)
    {
        Vector3 Arrowforward = transform.forward;
		rigi.velocity = (Vector3.up / .5f + Arrowforward) * 15f * handDis;
        StartCoroutine(SkyArrowCor( targetPoint, 2.0f));
    }
	IEnumerator SkyArrowCor(Vector3 target, float timer)
	{
		float speed = 22.5f;
		this.transform.localScale = Vector3.one;
		this.transform.rotation = Quaternion.identity;
		yield return new WaitForSeconds(timer);
		SeiKwanArrow.SetActive(false);
		rigi.velocity = Vector3.zero;

		Vector3 dir;
		for (int i = 0; i < sky_Arraws.Length; ++i)
		{
			dir = new Vector3(Random.Range(-3, 4), Random.Range(-8, 9), Random.Range(-3, 4));
			sky_Arraws[i].transform.position = target + dir + new Vector3(0, 20, 0);
			sky_Arraws[i].transform.LookAt(target + dir);
			sky_Arraws[i].SetActive(true);
		}

		while(this.transform.position.y > -8)
		{
			this.transform.Translate(Vector3.down * speed * deltaTime);
			yield return null;
		}
		Debug.Log("Sound 땅에 닿음");
		SeiKwanArrow.SetActive(true);
	}
    //#### #### #### #### 
    private void HavensGate(Vector3 targetPoint)
    {
        SeiKwanArrow.SetActive(false);
        Vector3 Arrowforward = transform.forward;
        Vector3 TargettingDir = Vector3.Normalize(targetPoint - transform.position);
		rigi.velocity = TargettingDir * 15f * handDis;
        StartCoroutine(HavensGateCor(targetPoint));
    }
    IEnumerator HavensGateCor(Vector3 targetPoint)
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
                break;
            yield return null;
        }
		rigi.velocity = Vector3.zero;
        transform.LookAt(Vector3.up);
        Gate.SetActive(true);
    }
    //#### #### #### #### 
    IEnumerator Shooting(float delTime = 2.0f)
    {
        yield return new WaitForSeconds(delTime);
        del_timer = true;
        Shoot = false;
    }
    public bool IsShoot() { return Shoot; }
    public void resetDelete()
    {
		rigi.velocity = Vector3.zero;

		transform.localScale = Vector3.one;
        SeiKwanArrow.SetActive(true);
        //collider.enabled = true;
        Gate.transform.position = transform.position;
        Gate.transform.localScale = transform.localScale;
        Gate.transform.rotation = transform.rotation;
        Gate.SetActive(false);
        arrow_trab_particle.transform.position = transform.position;
        arrow_trab_particle.transform.localScale = transform.localScale;
        arrow_trab_particle.transform.rotation = transform.rotation;
        arrow_trab_particle.SetActive(false);
        for (int i = 0; i < sky_Arraws.Length; ++i)
        {
            sky_Arraws[i].transform.position = transform.position;
            sky_Arraws[i].transform.localScale = transform.localScale;
            sky_Arraws[i].transform.rotation = transform.rotation;
			sky_Arraws[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
			sky_Arraws[i].SetActive(false);
			
        }
        del_timer = false;
    }
    private void UseOtherObject()
    {
        SeiKwanArrow.SetActive(false);
        //collider.enabled = false;
    }
}
