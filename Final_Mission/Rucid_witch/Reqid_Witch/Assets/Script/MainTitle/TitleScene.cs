using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScene : MonoBehaviour
{
	public SpriteRenderer Title;
	public GameObject Menu;
	Color object_Color;
	float opening_time = 0.0f;
	float Alpha_color = 0.0f;
	float Screen_width;
	float Screen_height;
	bool Loading = false;

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
        object_Color = Title.color;
		Vector3 scale = Title.transform.localScale;
		Title.gameObject.transform.localScale = new Vector3(scale.x * Screen_width * 25 / 48 * 0.005f, scale.y * Screen_height * 25 / 48 * 0.005f, 1);
		
		Title.color = new Color(object_Color.r, object_Color.g, object_Color.b, 1);
		opening = OpeningCourutine(Title);
		StartCoroutine(opening);
	}

    // Update is called once per frame
    void Update()
    {
		opening_time += Time.deltaTime;
		if (Input.anyKey&&Alpha_color==1.0f)
		{
			Title.gameObject.SetActive(false);
		}
		if (Alpha_color == 1.0f)
		{
			StopCoroutine(opening);
		}
		if (Loading) 
		{
			if (Input.anyKey) 
			{
				Menu.SetActive (true);
			}
		}
    }
	public IEnumerator OpeningCourutine(SpriteRenderer target)
	{
		while (true)
		{
			Alpha_color += 0.05f;
			if (Title.gameObject)
				target.color =
				new Color(object_Color.r, object_Color.g, object_Color.b, Alpha_color);
			if (Alpha_color >= 1.0f)
			{
				Alpha_color = 1.0f;
				Loading = true;
				yield break;
			}
			yield return new WaitForSeconds(0.2f);

		}
	}
}
