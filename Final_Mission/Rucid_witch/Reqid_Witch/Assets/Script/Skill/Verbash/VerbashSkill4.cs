using System.Collections;
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
		if(left)
			this.transform.position = target.transform.position + Vector3.left * 5 + Vector3.up * 0.5f;
		else
			this.transform.position = target.transform.position + Vector3.right * 5 + Vector3.up * 0.5f;

		this.gameObject.SetActive(true);
		StartCoroutine("shooting",target);
    }
    IEnumerator shooting(GameObject target)
    {
		int cnt = 0;
        while(cnt < 200)
        {
			if (left)
				this.transform.Translate(Vector3.right * 5 /200);
			else
				this.transform.Translate(Vector3.left * 5 / 200);

			cnt++;
			yield return new WaitForSeconds(deltatime);
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
