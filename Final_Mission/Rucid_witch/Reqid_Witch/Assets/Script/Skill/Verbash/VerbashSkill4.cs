﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbashSkill4 : MonoBehaviour {
    public bool left = false;
    public float speed = 9.0f;
    private float deltatime;
    private void start()
    {
        deltatime = Time.deltaTime;
    }
    public void shoot(GameObject target)
    {
        while(Vector3.Distance(target.transform.position,transform.position) > 0.2f)
        {
            this.transform.TransformPoint(target.transform.position * deltatime * speed);
        }
        this.gameObject.SetActive(false);
    }
    public void reset()
    {
        if (left)
            this.transform.position = Vector3.left * 5;
        else
            this.transform.position = Vector3.right * 5;
        this.gameObject.SetActive(true);
    }
}
