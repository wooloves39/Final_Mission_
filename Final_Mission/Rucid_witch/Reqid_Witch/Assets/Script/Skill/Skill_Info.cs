using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour {
	public bool OneHit = false;
	public float Power = 100.0f;

	public bool AreaHit = false;
	public float AreaDmg = 40.0f; // 0~100
	public float AreaCycle = 0.5f;

	public bool DotHit = false;
	public float DotDmg = 50.0f;
	public float DotTime = 5.0f;

    public float[] PowerMemory = { 0,0,0 }; 
	public int HitCount = 4;
	private float[] Minus  = { 0,0,0};
	private List<GameObject> ObjList = new List<GameObject>();


	public float Delete_Delay_Time = 0.0f;

	public bool ElecShock = false;
	public float ShockTime = 2.0f;
	private bool Once = false;
	public GameObject effect;

	public float chargingGage = 1.0f;
	private void OnEnable()
	{
		Once = false;
		PowerMemory[0] = Power* chargingGage;
		PowerMemory[1] = AreaDmg* chargingGage;
		PowerMemory[2] = DotDmg* chargingGage;
	}
	public void chargingSet(float Gage)
	{
		chargingGage = Gage;
		PowerMemory[0] = Power * chargingGage;
		PowerMemory[1] = AreaDmg * chargingGage;
		PowerMemory[2] = DotDmg * chargingGage;
	}
	private void OnDisable()
	{
		ObjList = new List<GameObject>();
		chargingGage = 1.0f;
	}
	void Start () {
		Minus[0] = (float)(Power / HitCount);
		Minus[1] = (float)(AreaDmg/ HitCount);
		Minus[2] = (float)(DotDmg / HitCount);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag( "Monster"))
		{
			ObjList.Add(other.gameObject);
			ObjectLife temp;
			temp = other.GetComponentInParent<ObjectLife>();
			Instantiate(effect,other.transform.position,Quaternion.identity);
			if (OneHit)
			{
				if (!temp.MomentInvincible)
				{
					if (PowerMemory[0] > 0)
						temp.SendMessage("SendDMG", PowerMemory[0]);
					if(ElecShock)
						temp.SendMessage("Shock",ShockTime);
					if(PowerMemory[0]>0)
					PowerMemory[0] -= Minus[0];
				}
			}
			if (AreaHit)
			{
				if (!temp.MomentInvincible)
				{
					if(!Once)
						StartCoroutine("Area_Skill");
					Once = true;
				}
			}
			if (DotHit)
			{
				if (!temp.MomentInvincible)
				{
					StartCoroutine("DotSkill", other.GetComponentInParent<ObjectLife>());
				}
			}
			
				
		}
	}
	void Delete()
	{
		this.gameObject.SetActive(false);
	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Monster"))
		{
			ObjList.Remove(other.gameObject);
		}
	}
	IEnumerator Area_Skill()
	{
		yield return new WaitForSeconds(0.1f);
		ObjectLife temp;
		while (PowerMemory [1] > 0) 
        {
            yield return new WaitForSeconds(AreaCycle);
			for (int j = 0; j < ObjList.Count; ++j)
			{
				if (ObjList[j].activeInHierarchy == false)
					continue;
				temp = ObjList [j].GetComponentInParent<ObjectLife> ();
				temp.SendMessage ("SendAreaDMG", Minus[1]);
				if (ElecShock)
					temp.SendMessage ("Shock", ShockTime);

			}
			PowerMemory[1] -= Minus[1];
		}
		yield return new WaitForSeconds(Delete_Delay_Time);
	}
	IEnumerator DotSkill(ObjectLife obj)
	{
        float DotCycle = DotTime / HitCount;
		
        obj.SendDotDMG(PowerMemory[2]/HitCount, DotTime, DotCycle);
        
        if (!Once)
        {
            Once = true;
            yield return new WaitForSeconds(Delete_Delay_Time);
			Once = false;
			this.gameObject.SetActive(false);
        }
	}
}
