using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] InputField field; 
	[SerializeField] GameObject MainMenuCanvas;
	[SerializeField] GameObject MultiPlayerMenuCanvas;
	[SerializeField] GameObject SinglePlayerMenuCanvas;
	public string roomName;
	public GameObject player;
	private void Start() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		MainMenuCanvas.SetActive(true);
		MultiPlayerMenuCanvas.SetActive(false);
		SinglePlayerMenuCanvas.SetActive(false);
	}
	//Main menu	

	public void MultiPlayer()
	{
		MainMenuCanvas.SetActive(false);
		MultiPlayerMenuCanvas.SetActive(true);
	}
	public void SinglePlayer()
	{
		MainMenuCanvas.SetActive(false);
		SinglePlayerMenuCanvas.SetActive(true);
	}
	public void Inventory()
	{
		SceneManager.LoadScene("Inventory");
	}
	//MultiPlayer menu
	public void CreateRoom()
	{
		RoomOptions roomOptions= new RoomOptions();
		roomOptions.MaxPlayers =2;
		roomName="" + Random.Range(1000,9999);
		PlayerPrefs.SetString("Code",roomName);
		Debug.LogWarning(roomName);
		PhotonNetwork.CreateRoom(roomName,roomOptions);
		PhotonNetwork.JoinRoom(roomName);
		PhotonNetwork.LoadLevel("Game");
	}
	public void JoinRoom()
	{
		PhotonNetwork.JoinRoom(field.text);
		PhotonNetwork.LoadLevel("Game");
	}
}
