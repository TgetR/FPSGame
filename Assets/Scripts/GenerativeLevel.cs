using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GenerativeLevel : MonoBehaviour
{
public Object[] Chunks;
public GameObject[] SpawnPoints;
public bool[] generated;
public int CountOfGenerations;
private void Start() {
	Chunks = Resources.LoadAll("Chunks");
	generated = new bool[Chunks.Length];
	SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
	if(CountOfGenerations>6) Generation(false,true);
	else Generation(false,false);
	
	
}
public void Generation(bool arena,bool arenaInNormal)
{
	CountOfGenerations++;
	for(int i = 0; i < SpawnPoints.Length; i++)
	{	
		int rnd = RandomChunkNumber(arenaInNormal);
		while(generated[rnd])
		{
		  rnd = RandomChunkNumber(arenaInNormal);
		}
		
		if(arena) Instantiate(Chunks[0], SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation);
		else
		{ 
		Instantiate(Chunks[rnd], SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation); 
		generated[rnd] = true;
		}

	}
	for(int i = 0; i < generated.Length; i++) generated[i] = false;
}
public int RandomChunkNumber(bool arenaInNormal)
{
	if(!arenaInNormal) return Random.Range(1, Chunks.Length);
	else return Random.Range(0, Chunks.Length);
}
}
