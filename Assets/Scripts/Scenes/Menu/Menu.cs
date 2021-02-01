using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject controls;

    public void ToggleControls()
    {
        controls.SetActive(!controls.activeSelf);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Laboratory");
    }
    
}
