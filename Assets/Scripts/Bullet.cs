using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	public void Start() {
		rb = GetComponent<Rigidbody>();
		StartCoroutine("LifeTime");
	}
	public void Update() {
		transform.Translate(Vector3.forward * Time.deltaTime * 25);
	}
	private void OnCollisionEnter(Collision other) 
	{
		if(other.gameObject.tag== "Wall")
		{
		Destroy(gameObject);
		}
	} 
	IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(6);
		Destroy(gameObject);
	}
	}
