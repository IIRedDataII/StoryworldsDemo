using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    
    [SerializeField] private Image interactPrompt;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        interactPrompt.enabled = true;
        other.gameObject.GetComponent<PlayerSpaceship>().at = PlayerSpaceship.At.Button;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        interactPrompt.enabled = false;
        other.gameObject.GetComponent<PlayerSpaceship>().at = PlayerSpaceship.At.Nothing;
    }
    
}
