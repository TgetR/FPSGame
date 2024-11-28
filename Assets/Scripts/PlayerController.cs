using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float HP = 100;
	public int Holder_current = 45;
	public int Holder_max = 45;
	public GameObject bullet;
	public GameObject ShootPoint;
	public Image HPBar;
	public Animator MagAnim;
	[SerializeField] private GameObject DRWL;
	private bool _FireDelayEnd = true;
	private bool _ReloadEnd = true;
	private void Update() {
		//FIRE
		if(Input.GetAxis("Fire1") == 1 && _FireDelayEnd && _ReloadEnd) 
		{
			Instantiate(bullet,ShootPoint.transform.position,ShootPoint.transform.rotation);
			Holder_current -= 1;
			_FireDelayEnd = false;
			StartCoroutine("FireDelay");
		}
		
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			{
				if(hit.transform.name== "WallDoor")
				{
					DRWL.SetActive(true);
					if(Input.GetKey(KeyCode.E))
					{
						Animator anim = hit.transform.GetComponent<Animator>();
						anim.SetTrigger("Open");
					}
				}
				else DRWL.SetActive(false);
			}
		//HOLDER CHECK
		if(Holder_current <= 0 )
		{
			Holder_current = Holder_max;
			StartCoroutine("Reload");
		}
		//HP CHECK
		if(HP <=0)
		{
			Destroy(gameObject);
			Debug.Log("Player Death");
		}
		//HP BAR
		HPBar.fillAmount = HP / 100;
		
	}
	private void OnCollisionEnter(Collision other) {
		if(other.transform.tag == "Bullet")
		{
			Destroy(other.gameObject);
			HP -= 5;
		}
	}
	IEnumerator Reload()
	{
		MagAnim.SetTrigger("Reload");
		Debug.Log("Reload");
		_ReloadEnd = false;
		yield return new WaitForSeconds(Holder_max * 0.2f);
		_ReloadEnd = true;
		Debug.Log("Reload end");
	}
	IEnumerator FireDelay()
	{
		yield return new WaitForSeconds(0.2f);
		_FireDelayEnd = true;
	}

}
