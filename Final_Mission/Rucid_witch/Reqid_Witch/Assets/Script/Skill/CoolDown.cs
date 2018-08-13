using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour {

    public float[] Azu_CoolTime = { 0, 3, 5, 10, 20 };
    public float[] Sei_CoolTime = { 0, 3, 5, 10, 20 };
	public float[] Bee_CoolTime = { 0, 3, 5, 10, 20 };
	public float[] Ver_CoolTime = { 0, 3, 5, 10, 20 };
	public float[] Dell_CoolTime = { 0, 3, 5, 10, 20 };

	public int[] Azu_UseMp = {4,8,20,30,50};
    public int[] Sei_UseMp = {4,8,12,15,50};
	public int[] Bee_UseMp = { 4, 30, 15, 30, 50 };
	public int[] Ver_UseMp = { 4, 30, 15, 30, 50 };
	public int[] Dell_UseMp = { 4, 30, 15, 30, 50 };

	public bool[] Azu_Cool = { false, false, false, false, false };
    public bool[] Sei_Cool = { false, false, false, false, false };
	public bool[] Bee_Cool = { false, false, false, false, false };
	public bool[] Ver_Cool = { false, false, false, false, false };
	public bool[] Dell_Cool = { false, false, false, false, false };
	public GameObject Mpless;
	private Viberation PlayerViberation;
	private LinePointChecker[] PointCheckers;
	private PlayerState player;
    /*
        Azu = 1
        Sei = 2
        Bee = 3
        Ver = 4
        Del = 5
    */
    void Awake()
    {
		PointCheckers = GetComponentsInChildren<LinePointChecker>();
		PlayerViberation = GetComponent<Viberation>();
		   player = GetComponent<PlayerState>();
        for (int i = 0; i < 5; ++i)
        {
            Azu_Cool[i] = false;
            Sei_Cool[i] = false;
			Bee_Cool[i] = false;
			Ver_Cool[i] = false;
			Dell_Cool[i] = false;
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
			case 4:
				if (player.Mp < Ver_UseMp[n])
					send = true;
				break;
			case 5:
				if (player.Mp < Dell_UseMp[n])
					send = true;
				break;
		}
        if (send)
            MpLessOn();
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
			case 4:
				return Ver_Cool[n];
			case 5:
				return Dell_Cool[n];
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
             
                break;
            case 2:
                Sei_Cool[n] = true;
				break;
			case 3:
				Bee_Cool[n] = true;
				break; 
			case 4:
				Ver_Cool[n] = true;
				break;
			case 5:
				Dell_Cool[n] = true;
				break;
		}
		StartCoroutine(StartCoolTime(cha, n));
	}
	public void MpDown(int cha, int n)
	{
		n = n - 1;
		switch (cha)
		{
			case 1:
				player.Mp -= Azu_UseMp[n];
				break;
			case 2:
				player.Mp -= Sei_UseMp[n];
				break;
			case 3:
				player.Mp -= Bee_UseMp[n];
				break;
			case 4:
				player.Mp -= Ver_UseMp[n];
				break;
			case 5:
				player.Mp -= Dell_UseMp[n];
				break;
		}
	}
	IEnumerator StartCoolTime(int cha,int n)
    {
		CoolTimeSaver coolTimeSaver = GetComponentInChildren<CoolTimeSaver>();
        switch (cha)
        {
            case 1:
				coolTimeSaver.startCool(cha, n, Azu_CoolTime[n]);
				yield return new WaitForSeconds(Azu_CoolTime[n]);
                Azu_Cool[n] = false;
                break;
			case 2:
				coolTimeSaver.startCool(cha, n, Sei_CoolTime[n]);
				yield return new WaitForSeconds(Sei_CoolTime[n]);
				Sei_Cool[n] = false;
				break;
			case 3:
				coolTimeSaver.startCool(cha, n, Bee_CoolTime[n]);
				yield return new WaitForSeconds(Bee_CoolTime[n]);
				Bee_Cool[n] = false;
				break;
			case 4:
				coolTimeSaver.startCool(cha, n, Ver_CoolTime[n]);
				yield return new WaitForSeconds(Ver_CoolTime[n]);
				Ver_Cool[n] = false;
				break;
			case 5:
				coolTimeSaver.startCool(cha, n, Dell_CoolTime[n]);
				yield return new WaitForSeconds(Dell_CoolTime[n]);
				Dell_Cool[n] = false;
				break;
		}
    }
	public float getCollTime(int cha, int n)
	{
		switch (cha)
		{
			case 1:
				return Azu_CoolTime[n];
			case 2:
				return Sei_CoolTime[n];
			case 3:
				return Bee_CoolTime[n];
			case 4:
				return Ver_CoolTime[n];
			case 5:
				return Dell_CoolTime[n];
			default:
				return 0;
		}
	}
	public void MpLessOn()
	{
        Debug.Log("Mp부족 UI 출력");
		Mpless.SetActive(true);
		PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(0.3f, 0.5f, OVRInput.Controller.RTouch));
		PointCheckers[LineDraw.curType].resetSkill();
	}
}
