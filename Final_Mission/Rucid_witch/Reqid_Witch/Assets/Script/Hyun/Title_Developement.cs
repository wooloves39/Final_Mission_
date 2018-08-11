using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Developement : MonoBehaviour
{
	public GameObject Title;
	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.BButtonDown() || InputManager_JHW.YButtonDown())
		{
			gameObject.SetActive(false);
			Title.SetActive(true);
		}
	}
}
