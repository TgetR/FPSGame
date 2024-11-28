using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenalPlayer : MonoBehaviour
{       
	public Camera camera2;

private void Update() 
{
	RaycastHit hit;
	Ray ray = camera2.ScreenPointToRay(Input.mousePosition);
	if (Physics.Raycast(ray, out hit)) 
	{
	Debug.DrawLine (transform.position, hit.point, Color.cyan);
	Debug.Log(hit.transform.name);
	}		
}
}
