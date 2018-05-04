using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTower1 : towerSC {
	LineRenderer line;

	public GameObject LinePrefab;
	public GameObject elecPrefab;

	public List <Vector3>myarr;
	public List <float> distanse;
	public float ElecRange = 5.0f;
	public int elecCount =2;

	public float ElecHigh= 4.0f;
	Vector3 High;

	float time = 0.0f;
	int num = 0;
	//LineRenderer line;
	// Use this for initialization
	void Start () {
		
		High = new Vector3 (0.0f, ElecHigh, 0.0f);
		range = (int)ElecRange;

		line = LinePrefab.GetComponent<LineRenderer> ();

		Global.ElecArr.Add (this.transform.position + High);

		foreach(var i in Global.ElecArr)
		{
			if(Vector3.Distance(this.transform.position+  High,i) < range && this.transform.position+new Vector3(0,4,0) != i){
				
				line.SetPosition (0,i);
				myarr.Add (i);
				distanse.Add (Vector3.Distance(this.transform.position+  High,i));
				num++;

				line.SetPosition (1,this.transform.position+ High);
				Instantiate (LinePrefab,this.transform);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time>=0.2f)
		{
			for(int j=0;j<elecCount;++j){
				for(int i=0;i<num;++i){
					Instantiate (elecPrefab, ((this.transform.position +  High - myarr [i]) / 10.0f * getRandom (3, 8) + myarr [i]), this.transform.rotation).transform.SetParent(this.transform);
				}
			}
			time = 0;
		}



	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}
