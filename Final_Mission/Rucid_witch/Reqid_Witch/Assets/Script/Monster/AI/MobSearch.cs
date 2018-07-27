using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSearch : MonoBehaviour {
	Stage5MobAI Mobai;
    Stage5Boss Bossai;
    KaliBoss KBossai;
    AzraAI AzraBoss;
    public bool azra = false;
    public bool kali = false;
	public bool Search = false;
	public Vector3 PlayerPos;
	// Use this for initialization
    void Start () {
        Bossai = GetComponentInParent<Stage5Boss>();
		Mobai = GetComponentInParent<Stage5MobAI>();
        if(kali)
            KBossai = GetComponentInParent<KaliBoss>();
        if(azra)
            AzraBoss = GetComponent<AzraAI>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			Search = true;
            if (KBossai == null && AzraBoss == null)
            {
                if (Bossai == null)
                    Mobai.Fight = true;
                else
                    Bossai.Fight = true;
            }
            else
            {
                if(kali)
                    KBossai.Fight = true;
                if (azra)
                    AzraBoss.Fight = true;
                    
            }
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			Search = false;
            if (KBossai == null && AzraBoss == null)
            {
                if (Bossai == null)
                    Mobai.Fight = false;
                else
                    Bossai.Fight = false;
            }
            else
            {
                if(kali)
                    KBossai.Fight = false;
                if (azra)
                    AzraBoss.Fight = false;
            }
		}
	}
}
