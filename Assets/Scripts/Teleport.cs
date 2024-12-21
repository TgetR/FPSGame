using UnityEngine;
using UnityEngine.SceneManagement;

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
		PlayerPrefs.SetInt("Generations", CountOfGeneration);
		PlayerPrefs.Save();
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
		SceneManager.LoadScene("Final");
	} 
	else if(ArenaGenerate)GL.Generation(true,false);
	else GL.Generation(false,true);
}
}
