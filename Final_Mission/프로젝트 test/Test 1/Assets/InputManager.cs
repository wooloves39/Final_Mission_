
using UnityEngine;
using System.Collections;
public struct Pointtype
{
  public  Vector3 point;
   public int type;
   public bool touch;
    //public Vector3 v3point;
    //public void pointbypoint()
    //{
    //    v3point.x = point.x;
    //    v3point.y = point.y;
    //    v3point.z = 0;
    //}
}
public class InputManager : MonoBehaviour
{
    Vector2 slideStartPosition;
    Vector2 prevPosition;
    Vector2 delta = Vector2.zero;
    public bool moved = false;
    private GameObject copy;
    private GameObject AreaPoint;
    int cnt = 0;
    private Pointtype[,] Area = new Pointtype[100,100];
    private Vector2 startArea;
    public GameObject Arealine;
    public GameObject testmove;
    bool touch = false;
    void Start()
    {
        copy = Resources.Load("sphere") as GameObject;
        AreaPoint = Resources.Load("AreaPoint") as GameObject;
    }
    void Update()
    {

        // 슬라이드 시작 지점.
        if (Input.GetButtonDown("Fire1"))
        {
            touch = true;
            slideStartPosition = GetCursorPosition();
            startArea.x = slideStartPosition.x - 200;
            startArea.y = slideStartPosition.y - 200;
            GameObject cube;
            for (int i = 0; i < 50; ++i)
            {
                for (int j = 0; j < 50; ++j)
                {
                    Area[i,j].point.x = startArea.x + i*8;
                    Area[i, j].point.y = startArea.y + j*8;
                    Area[i, j].point.z = 0 ;
                    Area[i, j].type = 0;
                    AreaPoint.transform.position = Area[i, j].point;
                    cube=Instantiate(AreaPoint, Area[i,j].point, Quaternion.identity,Arealine.transform);
                    cube.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                }
            }
        }
       
        // 화면 너비의 2% 이상 커서를 이동시키면 슬라이드 시작으로 판단한다.
        if (Input.GetButton("Fire1"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.SphereCastAll(ray, 500.5f);
            for (int i = 0; i < hit.Length; ++i)
            {
                if (hit[i].collider.tag=="check")
                {
                    Debug.Log("터치터치팡팡");
                    hit[i].collider.gameObject.GetComponent<ckeck_collision>().checkon();
                }
            }
            if (Vector2.Distance(slideStartPosition, GetCursorPosition()) >= (Screen.width * 0.02f))
            {
                print("is Click Ture");
                copy.transform.position = GetCursorPosition();
                cnt++;
                if (cnt % 5 == 0)
                {
                
                }
                moved = true;
            }
        }
        //잘못된 영역에 닿았는지 판별한다!
        if (touch == true)
        {
            //for (int i = 0; i < Arealine.gameObject.transform.childCount; ++i)
            //{
            //    if (Arealine.gameObject.transform.GetChild(i).GetComponent<Collider>() != null) {
            //        Debug.Log("dd");
            //        Destroy(testmove.gameObject);
            //        touch = false;
            //    }
            //}
            testmove.SetActive(true);
            testmove.transform.Translate(0, 0, 1);
            if (testmove.transform.position.z == 1)
            {
                Destroy(testmove.gameObject);
                touch = false;
            }
        }

        // 슬라이드가 끝났는가.
        if (!Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
        {
        }
        //해당 스킬 발동!!
       
        prevPosition = GetCursorPosition();
    }

    // 클릭되었는가.
    public bool Clicked()
    {
        if (!moved && Input.GetButtonUp("Fire1"))
        {
            return true;
        }
        else
            return false;
    }

    // 슬라이드할 때 커서 이동량.
    public Vector2 GetDeltaPosition()
    {
        return delta;
    }

    // 슬라이드 중인가.
    public bool Moved()
    {
        return moved;
    }

    public Vector2 GetCursorPosition()
    {
        return Input.mousePosition;
    }
}