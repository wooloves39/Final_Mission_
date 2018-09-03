using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHelp : MonoBehaviour {

    float deltatime;
    TutorialSet T;
    float time = 0.0f;
    public GameObject[] Help;
    public bool ChangeHelp = false;
    public int myStep = -1;
    private void Awake()
    {
        T = GetComponentInParent<TutorialSet>();
        deltatime = Time.deltaTime;
    }
    void Update () {
        this.transform.LookAt(new Vector3(T.player.gameObject.transform.position.x, this.transform.position.y, T.player.gameObject.transform.position.z));
        if (ChangeHelp)
        {
            if (T.tutorialStep >= 0)
            {
                if (time < 3.5f)
                {
                    if(T.player.GetMyState() != PlayerState.State.Talk)
                        Help[T.tutorialStep].SetActive(true);

                }
                else
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        Help[i].SetActive(false);
                    }
                }
            }
        }
        else
        {
            if (T.tutorialStep == myStep)
            {
                if (time < 3.5f)
                {
                    if (T.player.GetMyState() != PlayerState.State.Talk)
                        Help[0].SetActive(true);
                }
                else
                {
                    Help[0].SetActive(false);
                }
            }
        }
        time += deltatime;
        if (time > 7.0f)
            time = 0;
	}
}
