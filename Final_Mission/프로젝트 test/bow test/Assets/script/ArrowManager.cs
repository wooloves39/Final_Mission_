using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance;
    public GameObject controller;
    private GameObject currentArrow;
    public GameObject arrowPrefab;
    public GameObject stringAttackPoint;//화살의 줄역활
    public GameObject arrowStartPoint;

    private bool isAttached = false;
    public GameObject stringStartPoint;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        AttackArrow();
        PullString();
    }
    private void AttackArrow()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = controller.transform;
            currentArrow.transform.localPosition = new Vector3(0, 0, .342f);//화살의 오른손 위치를 정한다.
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }
    private void PullString()
    {
        if (isAttached) {
            float dist =( stringStartPoint.transform.position - controller.transform.position).magnitude;
            stringAttackPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(0, 0,  dist);

            //키입력, 키안에 접촉한 오브젝트가 없을때 라는 코드 추가 필요
            Fire();
        }
    }
    private void Fire()
    {
        float dist = (stringStartPoint.transform.position - controller.transform.position).magnitude;

        currentArrow.transform.parent = null;
        currentArrow = Instantiate(arrowPrefab);
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 15f*dist;
        r.useGravity = true;
        currentArrow.GetComponent<Collider>().isTrigger = false;
        stringAttackPoint.transform.position = stringStartPoint.transform.position;
        currentArrow = null;
        isAttached = false;

    }
    public void attackBowToArrow()
    {
        currentArrow.transform.parent = stringAttackPoint.transform;
        currentArrow.transform.position = arrowStartPoint.transform.position;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isAttached = true;
    }
}
