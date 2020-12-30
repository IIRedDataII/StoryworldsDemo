using UnityEngine;
using UnityEngine.UI;

public class Computer_Com : MonoBehaviour
{

    [SerializeField] private Image interactPrompt;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        interactPrompt.enabled = true;
        Player.AtComputerCom = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        interactPrompt.enabled = false;
        Player.AtComputerCom = false;
    }
    
}
