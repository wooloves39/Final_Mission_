using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFTubeManager : MonoBehaviour
{
    List<GameObject> TubeList;
    // Use this for initialization
    void Start()
    {
        TubeList = new List<GameObject>();

    }
    public void AddTube(GameObject tube)
    {
        TubeList.Add(tube);
    }
    public void DeleteTube(GameObject tube)
    {
        TubeList.Remove(tube);
    }
    public void InputMousePos(Vector3 pos)
    {
        float near=-1;

        int result = -1;

        for (int i=0; i< TubeList.Count; ++i)
        {
            Vector3 tubepos = TubeList[i].transform.position;
            tubepos.z = 0;
            float Distance = Vector3.Distance(pos, tubepos);
            if (Distance < 1.0f)
            {
                if (near == -1)
                {
                    near = Distance;
                    result = i;
                }
                else if (near>Distance)
                {
                    near = Distance;
                    result = i;
                }

            }
        }
        if (result!=-1)
        TubeList[result].transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
