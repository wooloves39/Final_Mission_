using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NextStage : MonoBehaviour
{
	private SceneChange sceneChange;
	private bool NextOn = false;
	public bool isLast = false;
	public void setNextOn(bool val) { NextOn = val; }
	public bool getNextOn() { return NextOn; }
	private void Awake()
	{
		sceneChange = FindObjectOfType<SceneChange>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && NextOn)
		{
			if (!isLast)
			{
				if (Singletone.Instance.stage == -1)
					Singletone.Instance.stage = 1;
				else
				{
					++Singletone.Instance.stage;
				}//스테이지 정보, 속성 추가등 부가 요소 정리
                
				sceneChange.sceneChange("Ready");
			}
			else
			{
				sceneChange.sceneChange("GameEnd");
			}
		}
	}

}
