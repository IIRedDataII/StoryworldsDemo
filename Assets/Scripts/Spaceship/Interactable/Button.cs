using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    
    [SerializeField] private Image interactPrompt;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        interactPrompt.enabled = true;
        Player.AtButton = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        interactPrompt.enabled = false;
        Player.AtButton = false;
    }
    
}
