using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuSelect : MonoBehaviour {
	public GameObject[] EFF;
	public GameObject[] BGM;
	public GameObject[] SAVE;
	private SubMenu sub;
	private SoundController SoundController;
    private void Awake()
    {
        sub = FindObjectOfType<SubMenu>();
        SoundController = FindObjectOfType<SoundController>();
    }
    private void OnEnable()
	{
	
		for (int i = 0; i < 3; ++i)
		{
			EFF[i].SetActive(false);
			BGM[i].SetActive(false);
			SAVE[i].SetActive(false);
		}
		if (Singletone.Instance.BGMSound < 0.25f)
		{
			BGM[0].SetActive(true);
		}
		else if (Singletone.Instance.BGMSound < 0.75f)
		{
			BGM[1].SetActive(true);
		}
		else
		{
			BGM[2].SetActive(true);
		}
		if (Singletone.Instance.Sound < 0.25f)
		{
			EFF[0].SetActive(true);
		}
		else if (Singletone.Instance.Sound < 0.75f)
		{
			EFF[1].SetActive(true);
		}
		else
		{
			EFF[2].SetActive(true);
		}
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			Vector3 temp;
			int layerMask = ((-1) - (1 << LayerMask.NameToLayer("Default")| 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Monster")));
			Ray ray = new Ray(this.transform.position,this.transform.up);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 20, layerMask))
			{
				if (hit.collider.CompareTag("Menu"))
				{
					temp = hit.collider.GetComponent<RectTransform>().localScale;
					if (temp.z > 0)
					{
						if (temp.z < 1.5f)
						{
							for (int i = 0; i < 3; ++i)
								BGM[i].SetActive(false);
							BGM[0].SetActive(true);
							Singletone.Instance.BGMSound = 0.0f;
							SoundController.BGMOptionChange();
						}
						else if (temp.z < 2.5f)
						{
							for (int i = 0; i < 3; ++i)
								BGM[i].SetActive(false);
							BGM[1].SetActive(true);
							Singletone.Instance.BGMSound = 0.5f;
							SoundController.BGMOptionChange();
						}
						else if (temp.z < 3.5f)
						{
							for (int i = 0; i < 3; ++i)
								BGM[i].SetActive(false);
							BGM[2].SetActive(true);
							Singletone.Instance.BGMSound = 1.0f;
							SoundController.BGMOptionChange();
						}
						else if (temp.z < 100.5f)
						{
							SAVE[0].SetActive(true);
							SAVE[1].SetActive(false);
							SAVE[2].SetActive(false);
							Singletone.Instance.Save("/Text/Save/save01.txt");
						}
						else if (temp.z < 101.5f)
						{
							SAVE[1].SetActive(true);

							SAVE[0].SetActive(false);
							SAVE[2].SetActive(false);
							Singletone.Instance.Save("/Text/Save/save02.txt");
						}
						else if (temp.z < 102.5f)
						{
							SAVE[1].SetActive(false);
							SAVE[0].SetActive(false);
							SAVE[2].SetActive(true);
							Singletone.Instance.Save("/Text/Save/save03.txt");
						}
					}
					else
					{
						if (temp.z > -1.5f)
						{
							for (int i = 0; i < 3; ++i)
								EFF[i].SetActive(false);
							EFF[0].SetActive(true);
							Singletone.Instance.Sound = 0.0f;
							SoundController.soundOptionChange() ;
						}
						else if (temp.z > -2.5f)
						{
							for (int i = 0; i < 3; ++i)
								EFF[i].SetActive(false);
							EFF[1].SetActive(true);
							Singletone.Instance.Sound = 0.5f;
							SoundController.soundOptionChange();
						}
						else
						{
							for (int i = 0; i < 3; ++i)
								EFF[i].SetActive(false);
							EFF[2].SetActive(true);
							Singletone.Instance.Sound = 1.0f;
							SoundController.soundOptionChange();
						}
					}
				
				}
			}
		}
		   
	}
}
