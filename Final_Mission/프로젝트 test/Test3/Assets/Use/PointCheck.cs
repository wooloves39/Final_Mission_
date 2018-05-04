using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCheck : MonoBehaviour {
    private bool Skill;
    private bool check;
	// Use this for initialization
	void Start () {
        check = false;
        gameObject.SetActive(false);
	}
    public void touchon()
    {
        check = true;
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
      
    }
    public void reset()
    {
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        check = false;
        gameObject.SetActive(false);
    }
    public bool Getcheck()
    {
        return check;
    }
    public void turnon()
    {
        if(gameObject.activeSelf==false)
        gameObject.SetActive(true);
    }
    public void turnoff()
    {
        if(gameObject.activeSelf==true)
        gameObject.SetActive(false);
    }
    public void SetSkill(bool value)
    {
        Skill = value;
    }
    public bool GetSkill()
    {
        return Skill;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
