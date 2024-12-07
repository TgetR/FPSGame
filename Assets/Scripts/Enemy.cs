using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	 public int HP = 100;
	public int Holder_current = 45;
	public int Holder_max = 45;
	public Animator MagAnim;
	public GameObject bullet;
	public GameObject Player;
	public GameObject ShootPoint;
	public bool shooting = true;
	private bool _FireDelayEnd = true;
	private bool _ReloadEnd = true;
	// Положение точки назначения
	public Transform goal;
	UnityEngine.AI.NavMeshAgent agent;
	void Start()
	{		Player = GameObject.FindWithTag("Player");
		// Получение компонента агента
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		goal = Player.transform;
		// Указание точки назначения
		agent.destination = goal.position;
	}
	
	/************************************************************/
	private void Update() {
		NavMesh.CalculatePath(transform.position, goal.position, agent.areaMask, agent.path);
		agent.destination = Player.transform.position;
		//Holder check and reload
		if(Holder_current <= 0)
		{
			Holder_current = Holder_max;
			StartCoroutine("Reload");
		}
		
		//Fire
		if(shooting && _FireDelayEnd && _ReloadEnd)
		{
			Instantiate(bullet,ShootPoint.transform.position,ShootPoint.transform.rotation);
			Holder_current -= 1;
			_FireDelayEnd = false;
			StartCoroutine("FireDelay");
		}
		
		//HP check
		if(HP <=0)
		{
		Destroy(gameObject);
		}
		
	}
	/************************************************************/
	private void OnCollisionEnter(Collision other) {

	if(other.transform.tag == "Bullet")
		{
			Destroy(other.gameObject);
			int dmg = Player.GetComponent<PlayerController>().Level * 5;
			HP -= dmg;
		}
	}
	
	/************************************************************/
	IEnumerator Reload()
	{
		MagAnim.SetTrigger("Reload");
		Debug.Log("Reload");
		_ReloadEnd = false;
		yield return new WaitForSeconds(Holder_max * 0.2f);
		_ReloadEnd = true;
		Debug.Log("Reload end");
	}

	/************************************************************/
	IEnumerator FireDelay()
	{
		yield return new WaitForSeconds(0.2f);
		_FireDelayEnd = true;
	}
	
}
