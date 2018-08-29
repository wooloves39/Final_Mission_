using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffectControler : MonoBehaviour {
    public GameObject[] Eff;
    // 0-Attack
    // 1-Move
    // 2-Hit
    public void EffSet(int n)
    {
        Eff[n].SetActive(true);
        Invoke("EffDel", 5.0f);
    }
    public void EffDel()
    {
        Eff[0].SetActive(false);
        Eff[2].SetActive(false);
    }
    
}
