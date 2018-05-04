using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//박스에 맞았을 경우 다음 문양을 생성시킨다.
//박스에 맞았을 경우 박스의 색을 변경시킨다.
//
enum Direction{left,right,top,bottom};
public class boxcheck : MonoBehaviour {
   private bool check;
   private int index;
    private bool skill=false;
	// Use this for initialization
	void Start () {
        check = false;
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	}
    //터치가 이루어졌을때 자신의 자식 오브젝트들을 활성화시킨다.
    public void touchon()
    {
        check = true;
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<boxcheck>().turnon();
       
    }
    //현재는 사용 X
    public void touchdown()
    {
        check = true;
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
    }
    public void Set_index(int num)
    {
        index = num;
    }
    public bool Getcheck()
    {
        return check;
    }
    public int Get_index()
    {
        return index;
    }
    public void turnon()
    {
       gameObject.SetActive(true);
    }
    public void turnoff()
    {
        gameObject.SetActive(false);
    }
    public void SetSkill()
    {
        skill = true;
    }
    public bool GetSkill()
    {
        return skill;
    }
}
