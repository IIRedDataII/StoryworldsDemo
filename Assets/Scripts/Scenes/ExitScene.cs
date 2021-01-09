using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("City");
    }
    
}
