using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Laboratory":
                GameData.Instance.setGetlastRoom = GameData.LastRoom.Lab;
                break;
            case "Spaceship":
                GameData.Instance.setGetlastRoom = GameData.LastRoom.Spaceship;
                break;
            case "Church":
                GameData.Instance.setGetlastRoom = GameData.LastRoom.Church;
                break;
        }
        SceneManager.LoadScene("City");
    }
    
}
