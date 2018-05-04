using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private bool isAttached = false;
    private bool isFired = false;
    private void OnTriggerStay()
    {
        AttackArrow();
    }
    private void OnTriggerEnter()
    {
        AttackArrow();
      //  ArrowManager.Instance.attackBowToArrow();
    //    Debug.LogError("Entered Bow");
    }
    private void Update()
    {
        if (isFired)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }
    public void Fired()
    {
        isFired = true;
    }
    private void AttackArrow()
    {
        //키입력, 키안에 접촉한 오브젝트가 없을때 라는 코드 추가 필요
        ArrowManager.Instance.attackBowToArrow();
        isAttached = true;
    }
}
