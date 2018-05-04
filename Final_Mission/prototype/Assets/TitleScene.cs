using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScene : MonoBehaviour
{
	public GameObject Title;
	public GameObject UIback;
	public GameObject UImain;
    Color object_Color;
    float opening_time = 0.0f;
    float Alpha_color = 0.0f;
    float Screen_width;
    float Screen_height;
	bool check = false;

	private IEnumerator opening;
	// Use this for initialization
	private void Awake()
    {
        // 스크린 해상도 맞추기
        //실제 플레이에선 3번째 인자 true
        Screen.SetResolution(Screen.width, Screen.width *( 9 / 5), false);
        Screen_width = Screen.width;
        Screen_height = Screen_width*(9/5);

    }
    void Start()
    {
        object_Color = Title.transform.GetComponent<MeshRenderer>().material.color;

        Vector3 scale=Title.transform.localScale;
        Title.gameObject.transform.localScale=new Vector3(scale.x*Screen_width*25/48*0.005f, scale.y*Screen_height * 25/48*0.005f,1);
        Title.transform.GetComponent<MeshRenderer>().material.color = new Color(object_Color.r, object_Color.g, object_Color.b, Alpha_color);
		opening = OpeningCourutine(Title);
		StartCoroutine(opening);
	}

    // Update is called once per frame
    void Update()
    {
		opening_time += Time.deltaTime;
		if (Input.anyKey)
		{
			if (check == false) {
				Title.gameObject.SetActive (false);
				UIback.gameObject.SetActive (true);
				UImain.gameObject.SetActive (true);
				check = true;
			}
		}
		if (Alpha_color == 1.0f)
		{
			Debug.Log(Alpha_color);
			StopCoroutine(opening);
		}
	}
	public IEnumerator OpeningCourutine(GameObject target)
	{
		while (true)
		{
			Alpha_color += 0.05f;
			if (Title.gameObject)
				target.transform.GetComponent<MeshRenderer>().material.color =
				new Color(object_Color.r, object_Color.g, object_Color.b, Alpha_color);
			if (Alpha_color >= 1.0f)
			{
				Alpha_color = 1.0f;
				Debug.Log("dd");
				yield break;
			}
			yield return new WaitForSeconds(0.2f);
			
		}
	}
}
