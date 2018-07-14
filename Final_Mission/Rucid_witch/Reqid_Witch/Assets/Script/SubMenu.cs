using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour {
	public GameObject submenu;
	public GameObject menuClick;
    private PlayerState State;
	bool mystate = false;
	bool once = false;
	// Update is called once per frame
    void Awake()
    {
        State = GetComponentInParent<PlayerState>();
    }
	void Update () {
		if (InputManager_JHW.MenuButton() && !once)
		{
			Debug.Log("menu버튼");
			if (mystate)
			{
				once = true;
				Invoke("OffSubMenu", 0.2f);
			}
			else
			{
				once = true;
				Invoke("OnSubMenu", 0.2f);
			}
		}
      
	}
	public void OffSubMenu()
	{
        submenu.SetActive(false);
        State.SetMyState(PlayerState.State.Nomal);
		once = false;
		mystate = false;
		menuClick.SetActive(false);
	}
	private void OnSubMenu()
	{
        menuClick.SetActive(true);
        State.SetMyState(PlayerState.State.Pause);
		submenu.SetActive(true);
		once = false;
		mystate = true;
	}
}
