using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonControllerINV : MonoBehaviour
{

	public float movementspeed = 5.0f;
	public float mouseSensitivity = 2.0f;
	public float verticalAngleLimit = 60.0f;
	public float jumpSpeed = 5f;

	float verticalRotation = 0;
	public bool showInventory = false;
	float verticalVelocity = 0;
	CharacterController characterController;
	
	Camera firstPersonCamera;
	void Start()
	{
		characterController = gameObject.GetComponent<CharacterController>();
		firstPersonCamera = Camera.main.GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{

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

	}
}
