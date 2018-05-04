using UnityEngine;
using System.Collections;

public class DemoOrc : MonoBehaviour {

	public Animation anim;
	public float size = 1;
	public Material[] Mat;
	public Renderer mesh;


	void Start(){
		transform.localScale = new Vector3(size,size,size);
	}

	public void Idle(){
		anim.CrossFade("idle",0.3f);
	}

	public void Walk(){
		anim.CrossFade("walk",0.3f);
	}

	public void Run(){
		anim.CrossFade("run",0.3f);
	}

	public void attack01(){
		anim.CrossFade("attack01",0.1f);
		anim.CrossFadeQueued("idle",0.3f,QueueMode.CompleteOthers);
	}

	public void attack02(){
		anim.CrossFade("attack02",0.1f);
		anim.CrossFadeQueued("idle",0.3f,QueueMode.CompleteOthers);
	}

	public void hit(){
		anim.CrossFade("hit",0.1f);
		anim.CrossFadeQueued("idle",0.3f,QueueMode.CompleteOthers);
	}

	public void taunt(){
		anim.CrossFade("taunt",0.3f);
		anim.CrossFadeQueued("idle",0.3f,QueueMode.CompleteOthers);
	}

	public void Die(){
		anim.CrossFade("die",0.3f);
	}
}
