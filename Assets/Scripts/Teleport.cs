using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
public GenerativeLevel GL;
private void OnTriggerEnter(Collider other) {
	Debug.Log("Player");
	if(other.tag == "Player")
	{
		Debug.Log("Player en");
		ReGen();
		other.transform.Translate(-77.94f,5.8f,65.5f);
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
