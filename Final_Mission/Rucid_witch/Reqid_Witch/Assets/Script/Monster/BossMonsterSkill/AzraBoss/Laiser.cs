using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laiser : MonoBehaviour {
    Transform player;
    Transform azra;
    public Vector3 target;
    public GameObject Line;
    public GameObject Magic;
    public int num;
    private Vector3[] Pos = { new Vector3(8, 2, -4), new Vector3(3, 2, -4), new Vector3(-3, 2, -4), new Vector3(-8, 2, -4) };
    
    void Awake()
    {
        player = FindObjectOfType<PlayerState>().transform;
        azra = FindObjectOfType<AzraMob_Controll>().transform;
    }
    void OnEnable()
    {
        switch(num)
        {
            case 0:
                this.transform.position = azra.right * -8 + azra.forward * -4 + azra.position + Vector3.up * +2;
                break;

            case 1:
                this.transform.position = azra.right * -3 + azra.forward * -4 + azra.position + Vector3.up * +2;
                break;

            case 2:
                this.transform.position = azra.right * 3 + azra.forward * -4 + azra.position + Vector3.up * +2;
                break;
            case 3:
                this.transform.position = azra.right * 8 + azra.forward * -4 + azra.position + Vector3.up * +2;
                break;
        }
        Look_At();
    }
    private void OnDisable()
    {

        Line.SetActive(false);
        Magic.SetActive(false);
    }
    public void Look_At()
    {
        target = player.transform.position;
        Magic.transform.LookAt( target);
        this.transform.LookAt( target);
        StartCoroutine("Skilling");
    }
    IEnumerator Skilling()
    {
        Line.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Line.SetActive(false);
        Magic.SetActive(true);
    }
}
