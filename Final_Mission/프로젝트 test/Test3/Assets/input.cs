using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public GameObject skillcontroller;
    private float timer = 0;
    private GameObject skill;

    private bool skillon;
  private float skill_timer;
    // Use this for initialization
    void Start()
    {
        skill_timer = 0;
        skillon = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //skill이 성립되었을경우 1초간 보여준다. 
        if (skillon == true)
        {
            skill_timer += Time.deltaTime;
            if (skill_timer > 1.0f)
            {
                skill_timer = 0.0f;
                Destroy(skill.gameObject);
                skillon = false;
            }
        }
        //마우스 클릭시
        if (Input.GetMouseButtonDown(0))
        {
            //skill 오브젝트를 좌표에 맞게 생성한다.
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            skill= Instantiate(skillcontroller, pos, Quaternion.identity, this.transform);
           
        }
        //마우스를 땟을때, 스킬이 발동했는지 확인한다.
        if (Input.GetMouseButtonUp(0))
        {
            if (skill)
            {
                if (skill.GetComponent<skilcontroller>().skillon())
                {
                    skillon = true;
                }
                else 
                Destroy(skill.gameObject);
            }
        }
        //마우스의 움직임을 0.2초 당 한번씩 레이캐스트를 통해 체크한다.
        if (Input.GetMouseButton(0) && timer > 0.2f)
        {
            timer = 0;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.SphereCastAll(ray, 1.0f);
            for (int i = 0; i < hit.Length; ++i)
            {//맞은 인덱스값을 스킬 오브젝트에 넘겨준다.
                if (!hit[i].collider.gameObject.GetComponent<boxcheck>().Getcheck())
                {
                   Debug.Log("터치터치팡팡");
                    skill.GetComponent<skilcontroller>().rec_in(hit[i].collider.GetComponent<boxcheck>().Get_index(), hit[i].collider.gameObject);
                   
                }
            }
        }
    }
}
