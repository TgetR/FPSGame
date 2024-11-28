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
	Generation();
}
public void Generation()
{
	for(int i = 0; i < SpawnPoints.Length; i++)
	{
		int j = Random.Range(0, Chunks.Length);
		Instantiate(Chunks[j], SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation);
	}
}
}
