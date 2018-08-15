using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillView : MonoBehaviour {
    public GameObject[] Skill;
    public GameObject[] check;
    private int[] myskill = {0,0,0};
	// Update is called once per frame
    void Start()
    {

        int stage = Singletone.Instance.stage;
		if (stage == 10) stage = 6;
		if (stage  < 5)
        {
            for(int i = 0 ; i < 5 ; ++i)
                Skill[i].GetComponent<ChangeAlpha>().EndAlpha = 0.2f;
            for (int i = 0; i < stage; ++i)
                Skill[i].GetComponent<ChangeAlpha>().EndAlpha = 1.0f;
        }
        else
        {
            for(int i = 0 ; i < 5 ; ++i)
                Skill[i].GetComponent<ChangeAlpha>().EndAlpha = 1.0f;
        }
    }
	void Update () {

        myskill[0] = Singletone.Instance.Myskill[0];
        myskill[1] = Singletone.Instance.Myskill[1];
        myskill[2] = Singletone.Instance.Myskill[2];

        for (int i = 0; i < 5; ++i)
        {
            if(myskill[0]!= -1 )
                if (!check[myskill[0]].gameObject.activeInHierarchy)
                    check[i].SetActive(true);

            if (myskill[1] != -1)
                if (!check[myskill[1]].gameObject.activeInHierarchy)
                    check[i].SetActive(true);

            if (myskill[2] != -1)
                if (!check[myskill[2]].gameObject.activeInHierarchy)
                    check[i].SetActive(true);
        }

        for (int i = 0; i < 5; ++i)
        {
            if (i != myskill[0] && i != myskill[1] && i != myskill[2])
                if (check[i].activeInHierarchy)
                    check[i].SetActive(false);
        }
	}
}
