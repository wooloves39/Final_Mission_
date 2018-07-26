using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour {

    public GameObject[] StartPlace;
    public float DelTime = 4.0f;
    public float Speed = 3.0f;
    public float damage = 0.0f;
    private Vector3 Direction = Vector3.zero;
    private Rigidbody Rigi;
    private float LimitTime = 4.0f;
    private float MyTime = 0.0f;
    public GameObject target;
    public GameObject Boom;
    void Awake()
    {
        Rigi = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {

        this.transform.position = StartPlace[Random.Range(0,3)].transform.position;
        Direction = Vector3.Normalize(target.transform.position- this.transform.position);
        MyTime = 0.0f;
        LimitTime = DelTime;
        StartCoroutine("ThrowOBJ");
    }
    IEnumerator ThrowOBJ()
    {
        float temp = Time.deltaTime;
        while (MyTime < LimitTime)
        {
            Rigi.MovePosition(this.transform.position + Direction * temp * Speed);
            MyTime += temp;
            yield return new WaitForSeconds(temp);
        }
        this.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerState Player = other.GetComponentInParent<PlayerState>();
            if (Player != null)
            {
                Player.DamageHp(damage);
                Boom.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                LimitTime = 0.0f;
            }
        }
        if(other.CompareTag("Ground"))
        {
            Boom.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
