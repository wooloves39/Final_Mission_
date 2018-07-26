using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAzraBalls : MonoBehaviour {

    public GameObject StartPlace;
    public float DelTime = 4.0f;
    public float Speed = 3.0f;
    public float damage = 0.0f;
    private Vector3 Direction = Vector3.zero;
    public Vector3 PlayerPos;
    private Laiser lai;
    private Rigidbody Rigi;
    private float LimitTime = 4.0f;
    private float MyTime = 0.0f;
    // Use this for initialization
    private void Awake()
    {
        lai = GetComponentInParent<Laiser>();
        Rigi = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        this.transform.position = StartPlace.transform.position;
        Direction = Vector3.Normalize(new Vector3(lai.target.x,0,lai.target.z)- new Vector3(this.transform.position.x, 0.0f, this.transform.position.z));
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
                this.gameObject.SetActive(false);
                LimitTime = 0.0f;
            }
        }
    }
}
