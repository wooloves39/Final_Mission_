using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGui : MonoBehaviour {
    bool toggle = true;
    int toolselect = 0;
    int gridSelect = 0;
    int gridcount = 2;
    private void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 40), "Label1");
        //GUI.Box(new Rect(100, 10, 100, 40), "box1");
        //if (GUI.Button(new Rect(10, 50, 100, 50), "Button"))
        //{
        //    Debug.Log("Push b");
        //}
        //if (GUI.RepeatButton(new Rect(10, 150, 100, 50), "Button"))
        //{
        //    Debug.Log("Push rb");
        //}
        //GUI.TextArea(new Rect(10, 50, 100, 80), "아브라카다브라");
        toggle=GUI.Toggle(new Rect(10, 10, 100, 30), toggle,"ss");
        string[] t = { "t1", "t2", "t3" };
        toolselect=GUI.Toolbar(new Rect(10,50,200,80),toolselect,t);
        gridSelect=GUI.SelectionGrid(new Rect(10, 140,200,80), gridSelect, t, gridcount);
    }
}
