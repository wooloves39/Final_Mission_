using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager_JHW
{

    //--Axis
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("LThumbstickX");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("LThumbstickY");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

	public static bool LThumbstickTouch()
	{
		return Input.GetButtonDown("LThumbstickTouch");
	}

	public static float SubHorizontal()
	{
		float r = 0.0f;
		r += Input.GetAxis("RThumbstickX");
		return Mathf.Clamp(r, -1.0f, 1.0f);
	}
	public static float SubVertical()
	{
		float r = 0.0f;
		r += Input.GetAxis("RThumbstickY");
		return Mathf.Clamp(r, -1.0f, 1.0f);
	}
	public static Vector3 SubJoystick()
	{
		return new Vector3(SubHorizontal(), 0, SubVertical());
	}

	public static bool RThumbstickTouch()
	{
		return Input.GetButtonDown("RThumbstickTouch");
	}
	public static bool LTriggerOn()
	{
		if (Input.GetAxis("LTrigger") >= 0.5f) return true;
		else return false;
	}
	public static bool RTriggerOn()
	{
		if (Input.GetAxis("RTrigger") >= 0.5f) return true;
		else return false;
	}
	public static bool LTouchHandleOn()
	{
		if (Input.GetAxis("LTouchHandle") >= 0.5f) return true;
		else return false;
	}
	public static bool RTouchHandleOn()
	{
		if (Input.GetAxis("RTouchHandle") >= 0.5f) return true;
		else return false;
	}
	//--Buttons
	public static bool AButton()
    {
		return Input.GetButton("AButton");
    }
    public static bool BButton()
    {
        return Input.GetButton("BButton");
    }
    public static bool XButton()
    {
        return Input.GetButton("XButton");
    }
    public static bool YButton()
    {
        return Input.GetButton("YButton");
    }
	public static bool AButtonDown()
	{
		return Input.GetButtonDown("AButton");
	}
	public static bool BButtonDown()
	{
		return Input.GetButtonDown("BButton");
	}
	public static bool XButtonDown()
	{
		return Input.GetButtonDown("XButton");
	}
	public static bool YButtonDown()
	{
		return Input.GetButtonDown("YButton");
	}
	public static bool MenuButton()
    {
        return Input.GetButtonDown("Menu");
    }
	public static bool LTouchButton()
	{
		return Input.GetButtonDown("LTouchButton");
	}
	public static bool RTouchButton()
	{
		return Input.GetButtonDown("RTouchButton");
	}
	private static bool mainLeftInUse = false;
    public static bool MainLeft()
    {
        if (MainHorizontal() > 0)
        {
            if (!mainLeftInUse)
            {
                mainLeftInUse = true;
                return true;
            }
        }
        else
            mainLeftInUse = false;
        return false;
    }
}
