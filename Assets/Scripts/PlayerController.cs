using System;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	#region Data
	public float HP = 100;
	public int Holder_current = 45;
	public int Holder_max = 45;
	public int Bullets = 100;
	public int Level;
	
	private bool _FireDelayEnd = true;
	private bool _ReloadEnd = true;
	#endregion
	
	#region Movement
	public float movementspeed = 5.0f;
	public float mouseSensitivity = 2.0f;
	public float verticalAngleLimit = 60.0f;
	public float jumpSpeed = 5f;

	float verticalRotation = 0;
	float verticalVelocity = 0;
	
	CharacterController characterController;
	Camera firstPersonCamera;
	#endregion Movement
	
	#region Objects
	public GameObject bullet;
	public GameObject ShootPoint;
	public Image HPBar;
	public Animator MagAnim;
	public Animator UpgradeAnim;
	public TMP_Text bulletCount;
	public TMP_Text damageCount;
	[SerializeField] private GameObject DRWL;
	#endregion
	void Start()
	{
		characterController = gameObject.GetComponent<CharacterController>();
		firstPersonCamera = Camera.main.GetComponent<Camera>();
	}
	private void Update() {
		//Movement
		//*******************************************************************************************************************
		Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			//Rotation
			float rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotationLeftRight, 0);

			verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
			verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
			firstPersonCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

			//Movement
			float forwardSpeed = Input.GetAxis("Vertical") * movementspeed;
			float sideSpeed = Input.GetAxis("Horizontal") * movementspeed;

			verticalVelocity += Physics.gravity.y * Time.deltaTime;

			if (Input.GetButtonDown("Jump") && characterController.isGrounded)
			{
				verticalVelocity = jumpSpeed;
			}

			Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

			speed = transform.rotation * speed;

			characterController.Move(speed * Time.deltaTime);
		//*******************************************************************************************************************
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
		//RELOAD
		if(Holder_current <= 0 || Input.GetKey(KeyCode.R) && Bullets> Holder_max && _ReloadEnd)
		{
			Holder_current = Holder_max;
			Bullets = Bullets - Holder_max;
			StartCoroutine("Reload");
		}
		//HP CHECK
		if(HP <=0)
		{
			Destroy(gameObject);
			Debug.Log("Player Death");
			SceneManager.LoadScene("Menu");
		}
		//HP BAR
		HPBar.fillAmount = HP / 100;
		
		//Canvas update
		bulletCount.text = Holder_current + "/" + Holder_max + "/" + Bullets;
		int dmg = 5 * Level;
		damageCount.text = "Damage: " + dmg;
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
	private void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Upgrader")
		{
			Level++;
			UpgradeAnim.SetTrigger("Upgrade");
			Destroy(other.gameObject);
		}
		if(other.tag == "HpAdder")
		{
			HP += 20;
			Destroy(other.gameObject);
		}
	}
}
