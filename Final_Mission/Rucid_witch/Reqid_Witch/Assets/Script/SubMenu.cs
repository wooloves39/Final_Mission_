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
		if(State.GetMyState() != PlayerState.State.Talk)
		if (InputManager_JHW.MenuButton() && !once)
		{
			Debug.Log("menu버튼");
			if (mystate)
			{
				once = true;
				OffSubMenu();
			}
			else
			{
				once = true;
				OnSubMenu();
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
		Time.timeScale = 1;
	}
	private void OnSubMenu()
	{
        menuClick.SetActive(true);
		State.SetMyState(PlayerState.State.Pause);
		submenu.SetActive(true);
		once = false;
		mystate = true;
		Time.timeScale = 0;
	}
}
