using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager_JHW
{
    //--Axis
    public static float Hor;
    public static float Ver;
    public static float Hor_2;
    public static float Ver_2;
    public static float MainHorizontal()
    {
        Hor = 0.0f;
        Hor += Input.GetAxis("J_MainHorizontal");
        Singletone.Instance.Hor = Hor;
        Singletone.Instance.Ver = Ver;

        return Mathf.Clamp(Hor, -1.0f, 1.0f);

    }
    public static float MainVertical()
    {
        Ver = 0.0f;
        Ver += Input.GetAxis("J_MainVertical");

        Singletone.Instance.Hor = Hor;
        Singletone.Instance.Ver = Ver;

        return Mathf.Clamp(Ver, -1.0f, 1.0f);
    }
    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    public static float SubHorizontal()
    {
        Hor_2 = 0.0f;
        Hor_2 += Input.GetAxis("H_MainHorizontal");
        Singletone.Instance.Hor_2 = Hor_2;
        Singletone.Instance.Ver_2 = Ver_2;
        return Mathf.Clamp(Hor_2, -1.0f, 1.0f);

    }
    public static float SubVertical()
    {
        Ver_2 = 0.0f;
        Ver_2 += Input.GetAxis("H_MainVertical");

        Singletone.Instance.Hor_2 = Hor_2;
        Singletone.Instance.Ver_2 = Ver_2;

        return Mathf.Clamp(Ver_2, -1.0f, 1.0f);
    }
    public static Vector3 SubJoystick()
    {
        return new Vector3(SubHorizontal(), 0, SubVertical());
    }


    //--Buttons
    public static bool AButton()
    {
        if (Input.GetButtonDown("Fire1"))
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
