using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCity : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        switch (name)
        {
            case "SceneChangeLab":
                SceneManager.LoadScene("Laboratory");
                break;
            case "SceneChangeShip":
                SceneManager.LoadScene("Spaceship");
                break;
            case "SceneChangeChurch":
                SceneManager.LoadScene("Church");
                break;
        }
        
    }
    
}
