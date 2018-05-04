using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : IEnumerable, System.IDisposable {
	class Item
	{
		public bool active;
		public GameObject gameObject;
	}
	Item[] table;
	//열거자 기본 재정의
	public IEnumerator GetEnumerator()
	{
		if (table == null) yield break;

		int count = table.Length;
		for(int i = 0; i < count; ++i)
		{
			Item item = table[i];
			if (item.active)
				yield return item.gameObject;
		}
	}
	//메모리 풀 생성
	//original: 미리 생성될 원본 소스
	//count: 풀 최고 갯수

	public void Create(Object original, int count)
	{
		Dispose();
		table = new Item[count];
		for(int i = 0; i < count; ++i)
		{
			Item item = new Item();
			item.active = false;
			item.gameObject = GameObject.Instantiate(original) as GameObject;
			table[i] = item;
			item.gameObject.SetActive(false);
		}
	}
	//쉬고 있는 객체를 반납
	public GameObject NewItem()
	{
		if (table == null) return null;

		int count = table.Length;
		for(int i = 0; i < count; ++i)
		{
			Item item = table[i];
			if (item.active == false)
			{
				item.active = true;
				item.gameObject.SetActive(true);
				return item.gameObject;
			}
		}
		return null; 
	}
	// (오버라이딩)아이템 셋시 포지션를 할당해 줌
	public GameObject NewItem(Vector3 P)
	{
		if (table == null) return null;

		int count = table.Length;
		for(int i = 0; i < count; ++i)
		{
			Item item = table[i];
			if (item.active == false)
			{
				item.gameObject.transform.position = P; 
				item.active = true;
				item.gameObject.SetActive(true);
				return item.gameObject;
			}
		}
		return null; 
	}
	//아이템 종료- 쉬게한다.
	//gameObject- NewItem으로 얻었던 객체

	public void RemoveItem(GameObject gameObject)
	{
		if (table == null || gameObject == null)
			return;

		int count = table.Length;
		for(int i = 0; i < count; ++i)
		{
			Item item = table[i];
			if (item.gameObject == gameObject)
			{
				item.active = false;
				item.gameObject.SetActive(false);
				break;
			}
		}
	}
	//모든 아이템 사용 종료
	public void ClearItem()
	{
		if (table == null) return;

		int count = table.Length;
		for(int i = 0; i < count; ++i)
		{
			Item item = table[i];
			if (item != null && item.active)
			{
				item.active = false;
				item.gameObject.SetActive(false);
			}
		}
	}
	//메모리 풀 삭제
	public void Dispose()
	{
		if (table == null) return;
		int count = table.Length;

		for(int i = 0; i < count; ++i)
		{
			Item item = table[i];
			GameObject.Destroy(item.gameObject);

		}
		table = null;
	}
	public bool AllDie()
	{
		bool check = false;
		for (int i = 0; i < table.Length; ++i)
		{
			Item item = table[i];
			if (item.gameObject.activeInHierarchy == true)
			{
				check = true;
				break;
			}
		}
		return check;
	}
}
