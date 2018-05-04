using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSkill_index : MonoBehaviour {
    public GameObject[] typeBox;
    public GameObject[] skilltype;
    private int[] ChoiceSkill;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChoiceSkill = Singletone.Instance.skill;
		for(int i = 0; i < ChoiceSkill.Length; ++i)
        {
            //중첩된것 처리 안함 코루틴 사용시 방식 바뀔수있으므로 구현 x
            if (ChoiceSkill[i] != -1)
            {
                skilltype[ChoiceSkill[i]].transform.position = typeBox[i].transform.position;
                skilltype[ChoiceSkill[i]].SetActive(true);
            }
        }
	}
}
