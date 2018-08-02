using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFallChild : MonoBehaviour {
    public GameObject Boom;
    private Rigidbody Rigi;
    private Vector3 target;
    private float time = 0.0f;
    private bool collision = false;
    public void SetTarget(Vector3 v)
    {
        target = v;
        collision = true;
        StartCoroutine("Shoot");
    }
    void Awake()
    {
        Rigi = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        time = 0.0f;
        collision = false;
        Boom.gameObject.SetActive(false);
    }
    void DisEnable()
    {
        Boom.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (collision)
        {
            if (other.CompareTag("Player"))
            {
                PlayerState Player = other.GetComponentInParent<PlayerState>();
                if (Player != null)
                {
                    Boom.transform.position = target;
                    Boom.gameObject.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
            if (other.CompareTag("Ground"))
            {
                Boom.transform.position = target;
                Boom.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator Shoot()
    {
        float temp = 0.05f;
        Vector3 Direction = Vector3.Normalize(target- this.transform.position );

        while (time < 4.0f)
        {
            Rigi.MovePosition(this.transform.position + Direction * temp * 15);
            time += temp;
            yield return new WaitForSeconds(temp);
        }
        this.gameObject.SetActive(false);
    }
}
