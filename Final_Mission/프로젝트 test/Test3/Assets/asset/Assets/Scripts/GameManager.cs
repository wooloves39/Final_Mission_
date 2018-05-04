using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject BallPrefab;
    public SpriteManager SM;

    private ArrayList Balls = new ArrayList(10);
    private ArrayList Sprites = new ArrayList();

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            AddSMBall(new Vector3(-2f, 7f + i * 2f, 0));
        }
    }

    void Update()
    {
        for (int i = 0; i < Sprites.Count; i++)
        {
            SM.Transform((Sprite)Sprites[i]);
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 20), "Restart"))
            Application.LoadLevel(0);
    }

    private void AddSMBall(Vector3 pos)
    {
        GameObject ballObj = (GameObject)Instantiate(BallPrefab, pos, Quaternion.identity);
        Sprites.Add(SM.AddSprite((GameObject)ballObj, 1f, 1f, 256, 0, 256, 256, false));
        Balls.Add(ballObj);
    }
}
