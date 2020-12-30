using UnityEngine;
using UnityEngine.UI;

public class Computer_Nav : MonoBehaviour
{
    
    [SerializeField] private Image interactPrompt;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        interactPrompt.enabled = true;
        Player.AtComputerNav = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        interactPrompt.enabled = false;
        Player.AtComputerNav = false;
    }
    
}
