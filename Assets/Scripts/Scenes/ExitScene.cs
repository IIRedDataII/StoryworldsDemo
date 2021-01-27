using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Laboratory":
                    GameData.Instance.SetGetlastRoom = GameData.LastRoom.Lab;
                    break;
                case "Spaceship":
                    GameData.Instance.SetGetlastRoom = GameData.LastRoom.Spaceship;
                    break;
                case "Church":
                    GameData.Instance.SetGetlastRoom = GameData.LastRoom.Church;
                    break;
            }

            SceneManager.LoadScene("City");
        }
    }
    
}
