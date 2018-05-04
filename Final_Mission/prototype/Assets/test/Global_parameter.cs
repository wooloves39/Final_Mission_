using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class TerrainState
//{
//    public bool isOn = false;
//    public float h = 0;     // 출구까지 예상이동 비용
//    public float h2 = 0;    // 캐릭터까지 예상 이동 비용
//}

public static class Global
{

	public static List<Vector3> ElecArr =  new List<Vector3> ();

    //public static int GreenParts;
    //public static int GrayParts;
	//
    //public static int JaneState;
    //// 0 : 터레인 입장 전, 1 : 터레인 입장 후 , 2 : 출구 도착 // ?? : 입장했다가 다시 나오면 - 추후에
	//
    //public static Vector3 JanePosition;
    //public static int JaneNodePositionX;
    //public static int JaneNodePositionY;
    //public static int ExitNodePositionX;
    //public static int ExitNodePositionY;
	//
    //public static int HeightRatio;
	//
    //public static TerrainState[,] TerrainNode;
    //public static float[] TerrainEntrance;
}

public class Global_parameter : MonoBehaviour
{
  //  public GameObject Jane;
  //  public int maxNodeNum = 0;
  //
  //  // Use this for initialization
  //  void Start()
  //  {
  //      maxNodeNum = 1;
  //
  //      Global.GreenParts = 0;
  //      Global.GrayParts = 0;
  //      Global.JaneState = 0;
  //      Global.TerrainNode = new TerrainState[256,256];
  //      
  //      for (int i = 0; i < 256; i++)
  //      {
  //          for(int j = 0; j < 256; j++)
  //          {
  //              Global.TerrainNode[j, i] = new TerrainState();
  //          }
  //      }
  //      //Debug.Log(Global.TerrainNode[0, 0].isOn);
  //
  //      Global.TerrainEntrance = new float[5];
  //
  //
  //      for (int i = 0; i < 256; i++)
  //      {
  //          for (int j = 0; j < 256; j++)
  //          {
  //              Global.TerrainNode[j, i].h = Vector2.Distance(new Vector2(j, i), new Vector2(Global.ExitNodePositionX, Global.ExitNodePositionY));
  //          }
  //      }
  //  }
  //
  //  // Update is called once per frame
  //  void Update()
  //  {
  //      if(Global.JaneState == 0)
  //          Global.JanePosition = Jane.transform.position;
  //
  //
  //      for (int i = 0; i < 256; i++)
  //      {
  //          for (int j = 0; j < 256; j++)
  //          {
  //              Global.TerrainNode[j, i].h2 = Vector2.Distance(new Vector2(j, i), new Vector2(Global.JaneNodePositionX, Global.JaneNodePositionY));
  //          }
  //      }
  //
  //
  //  }
}
