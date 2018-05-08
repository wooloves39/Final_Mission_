using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_MonBuff : MonoBehaviour {

	ObjectLife mych;
	void Awake()
	{
		mych = transform.parent.GetComponent<BeeJaeMonSkill>().MyCharacters.GetComponent<ObjectLife>();
		
	}
	private void OnEnable()
	{
		StartCoroutine(buff());
	}
	IEnumerator buff()
	{
		float timer = 0.0f;
		while (timer >= 3.0f)
		{
			timer += .6f;
			if (mych.Hp < mych.MaxHp) mych.Hp += 1;
			yield return new WaitForSeconds(.6f);
		}
		gameObject.SetActive(false);
	}
}
