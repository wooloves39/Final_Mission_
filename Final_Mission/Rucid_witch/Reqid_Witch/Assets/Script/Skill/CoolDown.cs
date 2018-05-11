using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour {

    public float[] Azu_CoolTime = { 0, 3, 5, 10, 20 };
    public float[] Sei_CoolTime = { 0, 3, 5, 10, 20 };
    public float[] Bee_CoolTime = { 0, 3, 5, 10, 20 };

    public int[] Azu_UseMp = {4,8,20,30,50};
    public int[] Sei_UseMp = {4,8,12,15,50};
    public int[] Bee_UseMp = {4,30,15,30,50};

    public bool[] Azu_Cool = { false, false, false, false, false };
    public bool[] Sei_Cool = { false, false, false, false, false };
    public bool[] Bee_Cool = { false, false, false, false, false };


    private PlayerState player;
    /*
        Azu = 1
        Sei = 2
        Bee = 3
        Ber = 4
        Del = 5
    */
    void Awake()
    {
        player = GetComponent<PlayerState>();
        for (int i = 0; i < 5; ++i)
        {
            Azu_Cool[i] = false;
            Sei_Cool[i] = false;
	        Bee_Cool[i] = false;
        }
    }
    public bool CheckMp(int cha, int n)
    {
        bool send = false;
        n = n - 1;
        switch (cha)
        {
            case 1:
                if (player.Mp < Azu_UseMp[n])
                    send = true;
                break;
            case 2: 
                if (player.Mp < Sei_UseMp[n])
                    send = true;
                break;
            case 3:
                if (player.Mp < Bee_UseMp[n])
                    send = true;
                break;
        }
        return send;
    }
    public bool CheckCool(int cha, int n)
    {
        n = n - 1;
        switch (cha)
        {
            case 1:
                return Azu_Cool[n];
            case 2:
                return Sei_Cool[n];
            case 3:
                return Bee_Cool[n];
        }
        return true;
    }
    public void SetCool(int cha, int n)
    {
        n = n - 1;
        switch (cha)
        {
            case 1:
                Azu_Cool[n] = true;
                StartCoroutine(StartCoolTime(cha, n));
                break;
            case 2:
                Sei_Cool[n] = true;
                StartCoroutine(StartCoolTime(cha, n));
                break;
            case 3:
                Bee_Cool[n] = true;
                StartCoroutine(StartCoolTime(cha, n));
                break;
        }
    }
    IEnumerator StartCoolTime(int cha,int n)
    {
        switch (cha)
        {
            case 1:
                yield return new WaitForSeconds(Azu_CoolTime[n]);
                Azu_Cool[n] = false;
                break;
            case 2:
                yield return new WaitForSeconds(Sei_CoolTime[n]);
                Sei_Cool[n] = false;
                break;
            case 3:
                yield return new WaitForSeconds(Bee_CoolTime[n]);
                Bee_Cool[n] = false;
                break;
        }
    }
}
