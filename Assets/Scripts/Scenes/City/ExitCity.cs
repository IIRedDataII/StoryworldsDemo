using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCity : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            GameData.Instance.SetGetlastRoom = GameData.LastRoom.City;
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
    
}
