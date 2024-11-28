using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
public GenerativeLevel GL;
private void OnTriggerEnter(Collider other) {
	if(other.tag == "Player")
	{
		ReGen();
		other.transform.position = new Vector3(-77.94f,5.8f,65.5f);
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
