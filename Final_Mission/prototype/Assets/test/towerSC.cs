using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct dmgGiver
{
    public Transform who;
    public int dmg;
}

public class towerSC : MonoBehaviour
{
    
    public enum Type
    {
        basic,
        canon,
        iron,
		electric,
		Frame
    }
	//public MoveMob[] enemies;
	public Transform target;

    public Type towerType;
    public int range = 0;


    public int dmg = 0;
    public int dmgStack = 0;
	public int kill = 0;


    public void killEnem()
    {
        kill++;
    }

}
