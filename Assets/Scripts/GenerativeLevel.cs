using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GenerativeLevel : MonoBehaviour
{
public Object[] Chunks;
public GameObject[] SpawnPoints;
private void Start() {
	Chunks = Resources.LoadAll("Chunks");
	SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
	Generation(false);
}
public void Generation(bool arena)
{
	
	for(int i = 0; i < SpawnPoints.Length; i++)
	{ 
		if(!arena)
		{
		int j = Random.Range(1, Chunks.Length);
		Instantiate(Chunks[j], SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation);
		}
		else if(arena)
		{
        Instantiate(Chunks[0], SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation);
		}
	}
}
}
