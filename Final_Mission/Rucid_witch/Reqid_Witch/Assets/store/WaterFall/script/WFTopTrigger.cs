using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFTopTrigger : MonoBehaviour {
    public GameObject[] tube;
    public GameObject TubeManager;

    bool TubeReady = true;
    float SetTime;
	// Use this for initialization
	void Start () {
		
	}
	public void SetTube()
    {
        if (TubeReady)
        {
            TubeReady = false;
            GameObject obj = Instantiate(tube[Random.Range(0, tube.Length)], transform.position, Quaternion.identity, TubeManager.transform);
            TubeManager.GetComponent<WFTubeManager>().AddTube(obj);
        }
        SetTime =  0;
    }
    // Update is called once per frame
    void Update()
    {

        if (!TubeReady)
        {
            SetTime += Time.deltaTime;
            if (SetTime > 1)
            {
                SetTime = 0;
                TubeReady = true;
            }
        }
    }
}
