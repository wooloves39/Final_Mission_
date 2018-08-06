using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kali_Skill_Attack : MonoBehaviour {

	private float damage = 0.0f;
	public float skillBalance;
	public bool dot = false;
	public float delay = 0.0f;
	PlayerState Player;
	bool ranged = false;
    int num = 0;
    public int dotTime = 10;
    public bool Azra = false;
    public bool QuickDel = false;
    public bool groundCheck = false;
	private void OnEnable()
	{
		num = 0;
		damage = skillBalance;
		ranged = false;
        if (QuickDel)
            Invoke("EndScripts", 0.5f);
	}
    void EndScripts()
    {
        this.gameObject.SetActive(false);
    }
	void OnTriggerEnter(Collider other)
	{
		if(!dot)
			if (other.CompareTag("Player"))
			{
				Player = other.GetComponentInParent<PlayerState>();
				if (Player != null)
				{
					Invoke("DelayDamage",delay);
				}
			}
        if (groundCheck)
        if (other.CompareTag("Ground"))
            Invoke("del", 1.0f);
	}
    void del()
    {
        this.gameObject.SetActive(false);
    }
	void DelayDamage()
	{
		Player.DamageHp(damage);
	}
	void OnTriggerStay(Collider other)
	{
		if (dot)
			if (other.CompareTag("Player"))
			{
				{
					Player = other.GetComponentInParent<PlayerState>();
					if (Player != null)
					{
						ranged = true;
					}
				}
			}
	}
	void OnTriggerExit(Collider other)
	{
		if (dot)
			if (other.CompareTag("Player"))
			{
				{
					Player = other.GetComponentInParent<PlayerState>();
					if (Player != null)
					{
						ranged = false;
					}
				}
			}
	}
	private void Update()
	{
        if (Azra)
            this.transform.Rotate(new Vector3(0, 10.0f, 0));
		if(dot)
		{
			if (ranged)
			{
				num++;
                if (num > dotTime)
				{
					Player.DamageHp(damage);
					num = 0;
				}
			}
		}
	}
}
