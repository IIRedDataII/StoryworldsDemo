using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    
    [SerializeField] private Image interactPrompt;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            interactPrompt.enabled = true;
            other.gameObject.GetComponent<PlayerSpaceship>().atButton = true;
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            interactPrompt.enabled = false;
            other.gameObject.GetComponent<PlayerSpaceship>().atButton = false;
            
        }
    }
    
}
