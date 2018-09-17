using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellMonAttackSkill : MonoBehaviour {
	public Transform Target{ get; set; }
	private Rigidbody rigi;
	private void Awake()
	{
		rigi = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 270 * Time.deltaTime);
	}
	public void shoot(Transform tr,float charging)
	{
		Target = tr;
		transform.LookAt(Target);
		rigi.velocity = this.transform.forward * charging*5;
        Invoke("SetOff", 4.0f);
	}
    void SetOff()
    {
        gameObject.SetActive(false);
    }
}
