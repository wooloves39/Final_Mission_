using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFall : MonoBehaviour {

	private Vector3[] Start = {Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero};
	public GameObject[] Line;
	public GameObject[] Magic;
    public int Size =3;
    private float time = 0.0f;
	void Awake()
	{

		for (int i = 0; i < 6; ++i) {
			Start [i] = Magic[i].transform.position;
		}
	}
	void OnEnable()
    {
        time = 0.0f;
        for (int i = 0; i < 6; ++i)
        {
            Magic [i].transform.position = Start[i]+this.transform.position;
            Magic[i].SetActive(true);
            Line[i].SetActive(false);
        }
        StartCoroutine("Skilling");
	}
	void DisEnable()
    {
        for (int i = 0; i < 6; ++i)
        {
            Line[i].SetActive(false);
           
        }
    }
	IEnumerator Skilling()
	{
        while (time < 3.0f)
        {
            this.transform.Rotate(new Vector3(0, 8.0f, 0));
            for (int i = 0; i < 6; ++i)
            {
                Magic[i].transform.position += Vector3.up * 0.1f;
            }
            time += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 6; ++i)
        {
            Line[i].transform.position = this.transform.position + new Vector3(Random.Range(-Size + 1, Size), -2.00f, Random.Range(-Size + 1, Size));
            Line[i].SetActive(true);
            yield return new WaitForSeconds(0.4f);
            Magic[i].GetComponent<StarFallChild>().SetTarget(Line[i].transform.position);
            yield return new WaitForSeconds(0.2f);
            Line[i].SetActive(false);
        }

	}
}
