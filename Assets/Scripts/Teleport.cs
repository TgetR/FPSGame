using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
public GenerativeLevel GL;
public Transform point;
private void OnTriggerEnter(Collider collision) {
	Debug.Log("Player");
	if(collision.gameObject.tag == "Player")   // перед этим стоит задать тэг игроку в юнити
	{
		collision.transform.position = point.transform.position;
		ReGen();
	}
}
void ReGen()
{
	GameObject[] objs = GameObject.FindGameObjectsWithTag("Chunck");
	for(int i = 0; i < objs.Length; i++)
	{
		Destroy(objs[i]);
	}
	GL.Generation();
}
}
