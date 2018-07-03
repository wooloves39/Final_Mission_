using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour {
    LineRenderer lindRend;
    public Transform startPos;
    public Transform endPos;

    private float textureOffset = 0f;
	// Use this for initialization
	void Start () {
        lindRend = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        lindRend.SetPosition(0, startPos.position);
        lindRend.SetPosition(1, endPos.position);

        textureOffset -= Time.deltaTime*2f;
        if (textureOffset < -10f)
        {
            textureOffset += 10f;
        }
        lindRend.sharedMaterials[0].SetTextureOffset("_MainTex", new Vector2(textureOffset, 0f));
    }
}
