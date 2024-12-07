using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
public GenerativeLevel GL;
public Transform point;
public int CountOfGeneration;
public bool ArenaGenerate = false;
private void OnTriggerEnter(Collider collision) {
	Debug.Log("Player");
	if(collision.gameObject.tag == "Player")
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
	if(CountOfGeneration >= 5)
	{
		GL.Generation(false,false);
		CountOfGeneration = 0;
		ArenaGenerate = true;
	} 
	else if(ArenaGenerate)GL.Generation(true,false);
	else GL.Generation(false,true);
}
}
