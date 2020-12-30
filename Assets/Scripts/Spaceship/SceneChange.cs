using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("City");
    }
    
}
