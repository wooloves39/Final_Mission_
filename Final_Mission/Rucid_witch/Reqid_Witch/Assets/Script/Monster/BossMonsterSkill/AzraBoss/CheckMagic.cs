using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMagic : MonoBehaviour {
    public bool X;
    public bool Z;
    public float damage = 9.0f;
    public float speed;
    private Vector3 prev;
    void OnEnable()
    {
        speed = Random.Range(50,80)/1.5f;
        prev = this.transform.position;
        StartCoroutine("Skill");
    }
    IEnumerator Skill()
    {
        float temp = Time.deltaTime;
        if (X)
            while(this.transform.position.x < 40)
            {
                this.transform.position += (new Vector3(speed,0,0)*temp);
                yield return new WaitForSeconds(temp);
            }
        if(Z)
            while(this.transform.position.z < 40)
            {
                this.transform.position += (new Vector3(0,0,speed)*temp);
                yield return new WaitForSeconds(temp);
            }
        if (!X && !Z)
        {

            while (this.transform.position.y < 2)
            {
                this.transform.position += (new Vector3(0, speed/2, 0) * temp);
                yield return new WaitForSeconds(temp);
            }
            while (this.transform.position.y > -3)
            {
                this.transform.position += (new Vector3(0, -speed/2, 0) * temp);
                yield return new WaitForSeconds(temp);
            }
        }
        this.transform.position = prev;
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
            }
        }
    }
}
