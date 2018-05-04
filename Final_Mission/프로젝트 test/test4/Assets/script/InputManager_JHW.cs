using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager_JHW
{

    //--Axis
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }


    //--Buttons
    public static bool AButton()
    {
        Debug.Log("AButton");
        return Input.GetButtonDown("Fire1");
    }
    public static bool BButton()
    {
        Debug.Log("BButton");
        return Input.GetButtonDown("Fire2");
    }
    public static bool XButton()
    {
        Debug.Log("XButton");
        return Input.GetButtonDown("Fire3");
    }
    public static bool YButton()
    {
        Debug.Log("YButton");
        return Input.GetButtonDown("Jump");
    }
    public static bool MenuButton()
    {
        Debug.Log("MenuButton");
        return Input.GetButtonDown("Menu");
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
