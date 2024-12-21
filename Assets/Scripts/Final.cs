using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
void Start(){
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
public void Exit(){
    SceneManager.LoadScene("Menu");
}
}
