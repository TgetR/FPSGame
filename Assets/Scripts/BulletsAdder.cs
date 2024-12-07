using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;

public class BulletsAdder : MonoBehaviour
{
	private PlayerController Player;
	private int i;
	private void Start() 
	{
	Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	
	i = Random.Range(0,2);
	if(i ==0) Destroy(gameObject);
	}
	private void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player" && i == 1)
		{	
			Player.Bullets += 20;
			Destroy(gameObject);
		}
	}
}
