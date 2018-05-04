using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
	private List<GameObject> TargetMonster = new List<GameObject>();
	private int TargetCount;
	private GameObject Mytarget;
	private bool firstCheck = false;
	//public GameObject targetPoint;
	// Use this for initialization
	void Start()
	{
		TargetCount = 0;
		StartCoroutine(targetChange());
	}

	// Update is called once per frame
	void Update()
	{
		for(int i = 0; i< TargetMonster.Count;++i)
		{
			if (TargetMonster[i].GetComponentInParent<ObjectLife>().Hp <= 0)
			{
				if (Mytarget == TargetMonster[i])
				{
					//targetPoint.SetActive(false);
					Mytarget = null;
				}
				TargetMonster.Remove(TargetMonster[i]);
				TargetCount--;
				checkTarget();
				break;
			}
		}
		if (Mytarget)
		{
			//if (!targetPoint.activeSelf)
			//	targetPoint.SetActive(true);
			Vector3 pos = Mytarget.transform.position;
			pos.y += 4;
			//targetPoint.transform.position = pos;
			for (int i = 0; i < TargetCount; ++i)
			{
				if(TargetMonster[i].GetComponentInChildren<HPBar>() != null)
					TargetMonster[i].GetComponentInChildren<HPBar>().taget= false;
			}
			Mytarget.GetComponentInChildren<HPBar>().taget = true;
		}
		//else
		//{
		//	targetPoint.SetActive(false);
		//}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Monster"))
		{
			Debug.Log("Add Mon");
			TargetMonster.Add(other.gameObject);
			if (!firstCheck)
			{
				firstCheck = true;
				Mytarget = other.gameObject;
			}
			TargetCount++;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Monster"))
		{
			other.GetComponentInChildren<HPBar>().taget= false;
			Debug.Log("Del Mon");
			if (Mytarget == other.gameObject)
			{
				Mytarget = null;
				TargetMonster.Remove(other.gameObject);
				TargetCount--;
				checkTarget();
			}
			else
			{
				TargetMonster.Remove(other.gameObject);
				TargetCount--;
			}

		}

	}
	public void checkTarget()
	{
		GameObject target = null;
		Vector3 mypos = transform.position;
		if (TargetCount == 0)
		{
			firstCheck = false;
			return;
		}
		for (int i = 0; i < TargetCount; ++i)
		{
			if (target == null)
			{
				target = TargetMonster[0];
			}
			else
			{
				if (Vector3.Distance(mypos, target.transform.position) > Vector3.Distance(mypos, TargetMonster[i].transform.position))
				{
					target = TargetMonster[i];
				}
			}
		}
		Mytarget = target;
	}
	private IEnumerator targetChange()
	{
		Vector3 Stick;
		int index = 5;
		while (true)
		{
			Stick = InputManager_JHW.SubJoystick();
			if (Stick.x < 0)
				index = 0;
			else if (Stick.x > 0)
				index = 1;
			Vector3 RorL=Vector3.zero;
			if (index != 5)
			{
				SortTargetList();
				for (int i = 0; i < TargetCount; ++i)
				{
					if (TargetMonster[i].gameObject != Mytarget.gameObject)
						RorL = transform.InverseTransformPoint(TargetMonster[i].transform.position);
					if (index == 0)
					{
						if (RorL.x < 0f)
						{
							Mytarget = TargetMonster[i];
							break;
						}
					}
					else if (index == 1)
					{
						if (RorL.x > 0f)
						{
							Mytarget = TargetMonster[i];
							break;
						}
					}
				}

			}
			yield return new WaitForSeconds(0.5f);
			index = 5;
		}
	}
	private void SortTargetList()
	{
		TargetMonster.Sort(delegate (GameObject A, GameObject B)
		{
			if (Vector3.Distance(transform.position, A.transform.position) > Vector3.Distance(transform.position, B.transform.position)) return 1;
			else if (Vector3.Distance(transform.position, A.transform.position) > Vector3.Distance(transform.position, B.transform.position)) return -1;
			return 0;
		});
	}
	public GameObject getMytarget() {
		Debug.Log(Mytarget);
		if (Mytarget == null) return null;
		return Mytarget.gameObject;
	}
}
