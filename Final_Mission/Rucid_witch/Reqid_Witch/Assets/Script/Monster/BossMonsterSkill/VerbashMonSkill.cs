using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbashMonSkill : MonoBehaviour {
	public GameObject[] magic;
	private int skill;
	private GameObject target;
	private GameObject MyCharacter;
	public GameObject MyCharacters { get { return MyCharacter; } set { MyCharacter = value; } }
	public bool handle2 = false;
	private VerbashSkill4[] V4 = { null, null };
    private Stage5Boss AI;

    private void Awake()
	{
		V4 = magic[3].GetComponentsInChildren<VerbashSkill4>();
        AI = GetComponent<Stage5Boss>();
    }
	public void shoot(int skillIndex, GameObject targetPos)
	{
		target = targetPos;
		skill = skillIndex;
		switch (skill)
		{
			case 0:
			case 1:
				StartCoroutine(skill1());
				break;
			case 2:
				StartCoroutine(skill2());
				break;
			case 3:
				StartCoroutine(skill3());
				break;
			case 4:
				StartCoroutine(skill4());
				break;
			case 5:
				StartCoroutine(skill5());

				break;
		}
		Debug.Log(MyCharacter.transform.position);
	}
	IEnumerator skill1()//1번스킬
	{
        
		magic[0].transform.position = target.transform.position;

		magic[0].SetActive(true);
		yield return new WaitForSeconds(1.5f);

		magic[0].SetActive(false);
	}

	IEnumerator skill2()//2번스킬
	{
		magic[1].transform.position = target.transform.position + Vector3.down* 0.7f;

        AI.CoolTime(1);
        magic[1].SetActive(true);
		yield return new WaitForSeconds(5.0f);

		magic[1].SetActive(false);

	}
	IEnumerator skill3()//3번스킬
	{
		magic[2].transform.position = target.transform.position;

        AI.CoolTime(2);
        magic[2].SetActive(true);
		yield return new WaitForSeconds(1.5f);

		magic[2].SetActive(false);

	}
	IEnumerator skill4()//4번스킬
    {
        AI.CoolTime(3);
        magic[3].transform.position = target.transform.position;
		magic[3].SetActive(true);
		yield return new WaitForSeconds(0.2f);
		V4[0].shoot(target);
		yield return new WaitForSeconds(0.1f);
		V4[1].shoot(target);
		yield return new WaitForSeconds(7.7f);

		magic[3].SetActive(false);
	}
	IEnumerator skill5()//5번스킬
    {
        AI.CoolTime(4);
        AI.Ulti = true;
        magic[4].transform.position = target.transform.position;
		magic[4].SetActive(true);

		yield return new WaitForSeconds(4.0f);

		magic[4].SetActive(false);

	}
}
