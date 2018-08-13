using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BattleCommand : MonoBehaviour {

	float TimeLimit;
	float time = 0.0f;
	int skill_index = 0;
	public float MAttdelay = 0.0f;
	public float AttackFrame = 0.4f;
	public float[] SkillFrame;
	private NavMeshAgent agent;
	private PlayerState Player;
	private ObjectLife MobInfo;
	private Animator ani;
	MonsterSoundSetting MobSound;

	public GameObject MobObj;
	private float DMG;


	void Awake()
	{
		MobSound = GetComponentInChildren<MonsterSoundSetting>();
		Player = FindObjectOfType<PlayerState>();
		MobInfo = GetComponent<ObjectLife>();
		ani = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}
	public void BattleMove(MoveMsg msg)
	{
		if (this.gameObject.activeInHierarchy)
		{
            if (msg.Speed > 10.0f)
                agent.angularSpeed = 0;
            else
                agent.angularSpeed = 360;
                
			agent.destination = msg.destination;
			agent.speed = msg.Speed;
			TimeLimit = msg.time;
            time = 0.0f;
			StartCoroutine("BMove");
		}
	}
	public void Attack(float T, bool b)
	{
		if (this.gameObject.activeInHierarchy)
		{
			this.transform.LookAt(Player.transform.position);
			DMG = MobInfo.Attack;
			agent.speed = 0;
			TimeLimit = T;
			time = 0.0f;
            if(MobSound != null)
			    MobSound.PlaySound(2);
			if (b)
				StartCoroutine("RangeAtt");
			else
				StartCoroutine("MeleeAtt");
		}
	}
	public void Skill(float T,int n)
	{
		if (this.gameObject.activeInHierarchy)
		{
			this.transform.LookAt(Player.transform.position);
			agent.speed = 0;
			TimeLimit = T;
			time = 0.0f;
			skill_index = n;
			//DMG = MobInfo.SkillDMG[skill_index];
			StartCoroutine("SkillCoroutine");
		}
	}
	IEnumerator SkillCoroutine()
	{
		float temp = Time.deltaTime;
        switch (skill_index)
        {
            case 0:
                    ani.SetBool("Skill1", true);
                break;
            case 1:
                if (time >= SkillFrame[1])
                    ani.SetBool("Skill2", true);
                break;
            case 2:
                if (time >= SkillFrame[2])
                    ani.SetBool("Skill3", true);
                break;
            case 3:
                if (time >= SkillFrame[3])
                    ani.SetBool("Skill4", true);
                break;
            case 4:
                if (time >= SkillFrame[4])
                    ani.SetBool("Skill5", false);
                break;

            case 5:
                if (time >= SkillFrame[5])
                    ani.SetBool("Skill6", false);
                break;

            case 6:
                if (time >= SkillFrame[6])
                    ani.SetBool("Skill7", true);
                break;

            case 7:
                if (time >= SkillFrame[7])
                    ani.SetBool("Skill8", true);
                break;

            case 8:
                if (time >= SkillFrame[8])
                    ani.SetBool("Skill9", true);
                break;

        }
		while (true)
		{
            if (Player.GetMyState() == PlayerState.State.Pause)
            {
                ani.speed = 0;
            }
            if (Player.GetMyState() == PlayerState.State.Nomal)
            {
                ani.speed = 1;
			switch (skill_index)
			{
				case 0:
					if (time >= SkillFrame[0])
						ani.SetBool("Skill1", false);
					break;
				case 1:
					if (time >= SkillFrame[1])
						ani.SetBool("Skill2", false);
					break;
				case 2:
					if (time >= SkillFrame[2])
						ani.SetBool("Skill3", false);
					break;
				case 3:
					if (time >= SkillFrame[3])
						ani.SetBool("Skill4", false);
					break;
				case 4:
					if (time >= SkillFrame[4])
						ani.SetBool("Skill5", false);
					break;

                case 5:
                    if (time >= SkillFrame[5])
                        ani.SetBool("Skill6", false);
                    break;

                case 6:
                    if (time >= SkillFrame[6])
                        ani.SetBool("Skill7", false);
                    break;

                case 7:
                    if (time >= SkillFrame[7])
                        ani.SetBool("Skill8", false);
                    break;

                case 8:
                    if (time >= SkillFrame[8])
                        ani.SetBool("Skill9", false);
                    break;
				
                }
            }
			if (time >= TimeLimit)
			{
				break;
			}
			else
            { 
                if (Player.GetMyState() == PlayerState.State.Nomal)
                {
                    time += temp;
                }
			}
			yield return new WaitForSeconds(temp);

		}
	}
		
	IEnumerator MeleeAtt()
	{
		yield return new WaitForSeconds(MAttdelay);
		float temp = Time.deltaTime;
		bool once = false;
		while (true)
		{
			if (time >= AttackFrame && !once)
			{
				once = true;
				Player.DamageHp(DMG);
				ani.SetBool("IsAttack", false);
			}
			if (time >= TimeLimit)
			{
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
	IEnumerator RangeAtt()
	{
		this.transform.LookAt(Player.transform.position);
		float temp = Time.deltaTime;

		RangedAttack Ranged = MobObj.GetComponent<RangedAttack>();
		Ranged.damage = DMG;
		Ranged.PlayerPos = Player.transform.position;
		MobObj.SetActive(true);

		while (true)
		{
			if(time >= AttackFrame)
				ani.SetBool("IsAttack", false);
			if (time >= TimeLimit)
			{
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
	IEnumerator BMove()
	{
        
		while (true)
        {
			float temp = Time.deltaTime;
			if (time >= TimeLimit)
			{
				agent.speed = 0.0f;
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
	public GameObject getTarget() { return Player.gameObject; }
}
