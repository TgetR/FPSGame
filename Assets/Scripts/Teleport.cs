using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
public GenerativeLevel GL;
public Transform point;
public int CountOfGeneration;
private void OnTriggerEnter(Collider collision) {
	Debug.Log("Player");
	if(collision.gameObject.tag == "Player")   // перед этим стоит задать тэг игроку в юнити
	{
		collision.transform.position = point.transform.position;
		ReGen();
		CountOfGeneration++;
	}
}
void ReGen()
{
	GameObject[] objs = GameObject.FindGameObjectsWithTag("Chunck");
	for(int i = 0; i < objs.Length; i++)
	{
		Destroy(objs[i]);
	}
	if(CountOfGeneration < 5) GL.Generation(false);
	else if(CountOfGeneration >= 5)
	{
		CountOfGeneration = 0;
		GL.Generation(true);
	}
}
}
