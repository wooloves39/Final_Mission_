using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeJaeMonSkill : MonoBehaviour
{
	public GameObject[] magic;
	private int skill;
	private GameObject target;
	private GameObject MyCharacter;
	public GameObject MyCharacters { get { return MyCharacter; } set { MyCharacter = value; } }
	public bool handle2 = false;


	private void Awake()
	{
	}
	public void shoot(int skillIndex, GameObject targetPos)
	{
		target = targetPos;
		skill = skillIndex;
		switch (skill)
		{
			case 0:
			case 1:
				StartCoroutine(SkyThunder());
				break;
			case 2:
				StartCoroutine(Buff());
				break;
			case 3:
				StartCoroutine(ThunderShock());
				break;
			case 4:
				StartCoroutine(ThunderBall());
				break;
			case 5:
				StartCoroutine(BlackThunder());

				break;
		}
		Debug.Log(MyCharacter.transform.position);
	}
	IEnumerator SkyThunder()//1번스킬
	{
		magic[0].transform.position = target.transform.position;
		magic[0].SetActive(true);
		yield return new WaitForSeconds(0.45f);
	
		yield return new WaitForSeconds(0.30f);
		magic[0].SetActive(false);
	}

	IEnumerator Buff()//2번스킬
	{
		magic[1].transform.position = target.transform.position;
		magic[1].SetActive(true);
	
		yield return new WaitForSeconds(3.0f);
		magic[1].SetActive(false);
		
	}
	IEnumerator ThunderShock()//3번스킬
	{
		magic[2].transform.position = MyCharacter.transform.position;
		magic[2].SetActive(true);
		
		yield return new WaitForSeconds(3.0f);
		magic[2].SetActive(false);
		
	}
	IEnumerator ThunderBall()//4번스킬
	{
		magic[3].transform.position = target.transform.position;
		magic[3].SetActive(true);
		
		yield return new WaitForSeconds(2.0f);
		magic[3].SetActive(false);
	}
	IEnumerator BlackThunder()//5번스킬
	{
		magic[4].transform.position = target.transform.position;
		magic[4].SetActive(true);
		yield return new WaitForSeconds(3.0f);
		magic[4].SetActive(false);
	
	}
}
