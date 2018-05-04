using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RotationText : MonoBehaviour
{
    RectTransform text;
    int choice;
    // Use this for initialization
    void Start()
    {
       choice = 0;
    }
    void KeyState()
    {
        if (Input.GetKeyDown("a"))
        {
            this.transform.Rotate(new Vector3(0, 72, 0));
            ++choice;
            if (choice > 5) choice = 0;
        }
        if (Input.GetKeyDown("d"))
        {
            this.transform.Rotate(new Vector3(0, -72, 0));
            --choice;
            if (choice < 0) choice = 4;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool max = false;
            int[] skills = Singletone.Instance.skill;
            for (int i = 0; i < skills.Length; ++i)
            {
                if (skills[i] == -1)
                {
                   skills[i] = choice;
                    Singletone.Instance.skill[i] = skills[i];
                    max = true;
                    break;
                }
            }
            if (max == false)
            {
                //Test 설정 다하면 씬 전환
                //
                SceneManager.LoadScene(1);
                Singletone.Instance.skill[Singletone.Instance.La_skill] = choice;
                ++Singletone.Instance.La_skill;
                if (Singletone.Instance.La_skill > 2)
                {
                    Debug.Log("0으로");
                    Singletone.Instance.La_skill = 0;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //if (time > 0.1f)
        //{
        //    time = 0.0f;
        //    Debug.Log(1);
        //    this.transform.Rotate(new Vector3(0, 6, 0));
        //}
        KeyState();
    }
}
