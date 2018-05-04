using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterAI : MonoBehaviour {

	bool state = false;	//false = peace
						//true = battle


	//이 오브젝트의 동작이 끝났는가?
	bool motioning = false;
	bool movestart = false;
	                               
	//	peace motion 	//	비율
	//	0 정지				49%		70% * 70%
	//	1 정지모션			21%		70% * 30%
	//	2 이동				30%		30%
	//	3				
	//	4				
	//	5	

//	battle motion		//	
	//	0 이동			//	사거리안에 들어오는 것이 선행조건
//	1 기본공격			//	
//	2 스킬1				//
//	3 스킬2				//
//	4 특수스킬			//	특정 상황시 다음 패턴은 반드시 특수스킬
//	5
	public int[] pattern; //1~3// 예시
	int pattern_num = 0;
	//1 2 1 3 -> 기본공격 스킬1 기본공격 스킬 2(반복)

	float Stop_Time = 3.0f;
	float Stop_Motion_Time = 2.0f;

	float time = 0.0f;
	public float Speed = 2.5f;
	public float MobRange = 3.0f;

	public float Delay_Nomal = 2.5f;
	public float Delay_Skill1 = 10.0f;
	public float Delay_Skill2 = 10.0f;
	public float Delay_SpecialSkill = 10.0f;
	public float Skill_HPLimit = 40.0f;//(%)
	bool special = false;//특수스킬 사용 여부

	int num;
	Vector3 PosPoint;

	public GameObject taget;
	public GameObject prefab;
	CharacterStatus status;
	public MobSearch mobSearch;

	void Start () {
		mobSearch = taget.GetComponent<MobSearch> ();
		status = GetComponent<CharacterStatus> ();	


	}


	// Update is called once per frame
	void Update () {
		if (mobSearch.Search) {
			state = true;
		} else {
			state = false;
		}

		if (state == false) {
			if (!motioning) {
				num = getRandom (1, 100);
				motioning = true;
			} else {
				time += Time.deltaTime;
				if (0 < num && num < 70) {
					if (num < 49) {
						if (time >= Stop_Time) {
							motioning = false;
							time = 0;
						}
					} else {
						if (time >= Stop_Motion_Time) {
							motioning = false;
							time = 0;
						} else {
							if (time < Stop_Motion_Time / 2)
								this.transform.Translate (Vector3.up * Time.deltaTime * Speed);
							else
								this.transform.Translate (-Vector3.up * Time.deltaTime * Speed);
						}
					}
				} else {
					if (!movestart) {
						float x = this.transform.position.x + getRandom (0, 25) - 12.5f;
						float z = this.transform.position.z + getRandom (0, 25) - 12.5f;
						PosPoint = new Vector3 (x, 2.5f, z);
						this.transform.LookAt (PosPoint);
						movestart = true;
					} else {
						this.transform.Translate (Vector3.forward * Time.deltaTime * Speed);
						if (Vector3.Distance (this.transform.position, PosPoint) <= 1.0f) {
							motioning = false;
							movestart = false;
							time = 0;
						}
					}
				}
			}
		} 
		else {
			time += Time.deltaTime;
			//이동
			if (Vector3.Distance (this.transform.position, mobSearch.PlayerPos) > MobRange) {
				this.transform.LookAt (mobSearch.PlayerPos);
				this.transform.Translate (Vector3.forward * Time.deltaTime * Speed);
			} 
			//공격
			else {
				if(special == false && status.HP / status.MaxHP * 100 < Skill_HPLimit) {
					if (time >= Delay_SpecialSkill) {
						//특수 스킬 들어갈 위치
						special = true;
						//Instantiate (prefab, this.transform.position, this.transform.rotation);
						time = 0.0f;
						Debug.Log ("특수스킬");
					}
				}
				else{
					if (pattern [pattern_num] == 1) {
						if (time >= Delay_Nomal) {
							Instantiate (prefab, this.transform.position, this.transform.rotation);
							time = 0.0f;
							pattern_num++;
							Debug.Log ("기본공격");

						}
					} else if (pattern [pattern_num] == 2) {
						if (time >= Delay_Skill1) {
							//스킬 1 들어갈 위치
							//Instantiate (prefab, this.transform.position, this.transform.rotation);
							time = 0.0f;
							pattern_num++;
							Debug.Log ("스킬1");
						}
					} else if (pattern [pattern_num] == 3) {
						if (time >= Delay_Skill2) {
							//스킬 2 들어갈 위치
							//Instantiate (prefab, this.transform.position, this.transform.rotation);
							time = 0.0f;
							pattern_num++;

							Debug.Log ("스킬2");
						}
					}
					if(pattern_num == pattern.Length)
						//반복
						pattern_num=0;
				}

				
			}
		}
			
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}
