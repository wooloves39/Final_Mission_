using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skilcontroller : MonoBehaviour {
    public GameObject boxes;
    private GameObject[] box_point = new GameObject[10];//생성한 박스의 설정 변경하는 변수
    private int true_index = 1;
    private GameObject lastchoice;
    private int start = 0;
    // Use this for initialization
    void Start () {
        //모든 오브젝트를 미리 셋팅한다.
        Vector3 pos = this.transform.position;
        //첫점
        box_point[0] = Instantiate(boxes, pos, boxes.transform.rotation, this.transform);
        box_point[0].GetComponent<boxcheck>().Set_index(0);
        //1차선택
        pos.x += 4;
        box_point[1] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[0].transform);
        box_point[1].GetComponent<boxcheck>().Set_index(1);
        pos.x -= 8;
        box_point[2] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[0].transform);
        box_point[2].GetComponent<boxcheck>().Set_index(1);
        pos.x += 4;
        pos.y += 4;
        box_point[3] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[0].transform);
        box_point[3].GetComponent<boxcheck>().Set_index(1);

        //2차선택
        //1-
        pos = box_point[1].transform.position;
        pos.y += 4;
        box_point[4] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[1].transform);
        box_point[4].GetComponent<boxcheck>().Set_index(2);
        box_point[4].GetComponent<boxcheck>().SetSkill() ;
        pos.x += 4;
        pos.y -= 4;
        box_point[5] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[1].transform);
        box_point[5].GetComponent<boxcheck>().Set_index(2);
        box_point[5].GetComponent<boxcheck>().SetSkill();
        //2-
        pos = box_point[2].transform.position;
        pos.x -= 4;
        box_point[6] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[2].transform);
        box_point[6].GetComponent<boxcheck>().Set_index(2);
        box_point[6].GetComponent<boxcheck>().SetSkill();
        pos.x += 4;
        pos.y += 4;
        box_point[7] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[2].transform);
        box_point[7].GetComponent<boxcheck>().Set_index(2);
        box_point[7].GetComponent<boxcheck>().SetSkill();
        pos.y -= 8;
        box_point[8] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[2].transform);
        box_point[8].GetComponent<boxcheck>().Set_index(2);
        box_point[8].GetComponent<boxcheck>().SetSkill();
        //3-
        pos = box_point[3].transform.position;
        pos.x += 4;
        box_point[9] = Instantiate(boxes, pos, boxes.transform.rotation, box_point[3].transform);
        box_point[9].GetComponent<boxcheck>().Set_index(2);
        box_point[9].GetComponent<boxcheck>().SetSkill();

    }

    // Update is called once per frame
    void Update () {
        box_point[0].GetComponent<boxcheck>().turnon();
        if (start != 2)//유니티는 자식이 start하기전에 부모에서 update까지 한번 돈 후에 start함수가 돈다. 때문에 2번 if문을 돌린다.
        {
            ++start;
            box_point[0].GetComponent<boxcheck>().touchon();
        }
    }
    //input으로 부터 래이케스트로 충돌된 오브젝트의 index번호를 체크한 후, 적당한 자식인덱스를 활성화하고,
    //나머지 동급 오브젝트들은 가린다.
    public void rec_in(int index,GameObject coll)
    {
        Debug.Log(index);
        if (true_index == index)
        {
            lastchoice = coll.gameObject;
            ++true_index;
            coll.GetComponent<boxcheck>().touchon();
            for(int i = 0; i < box_point.Length; ++i)
            {
                if (coll != box_point[i])
                {
                   if(coll.GetComponent<boxcheck>().Get_index() == box_point[i].GetComponent<boxcheck>().Get_index())
                    {
                        box_point[i].GetComponent<boxcheck>().turnoff();
                    }
                }
            }
        }
        else if (index == 0)
        {//Index 0의 경우는 특별 케이스로 무시한다.

        }
        else
            Destroy(gameObject);
        
    }
    //스킬이 성립되었는지 확인 후 전체 오브젝트를 활성화한다.
    public bool skillon()
    {
        if (lastchoice)
        {
            if (lastchoice.GetComponent<boxcheck>().GetSkill())
            {
                for (int i = 0; i < box_point.Length; ++i)
                {
                    box_point[i].GetComponent<boxcheck>().gameObject.
                        transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                    box_point[i].GetComponent<boxcheck>().gameObject.SetActive(true);
                }
                Debug.Log("스킬 발동!!!");

            }
            return true;
        }
        else
        {
            Destroy(this.gameObject);
            return false;
        }
    }
}
