using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraUlti1 : MonoBehaviour {
    private TreeSkill[] tree;
	// Use this for initialization
	void Start () {
        tree = GetComponentsInChildren<TreeSkill>();
	}
    void OnEnable()
    {
        StartCoroutine("Skill");
    }
    IEnumerator Skill()
    {
		return null;
    }
}
