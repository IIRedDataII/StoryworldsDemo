using UnityEngine;
using UnityEngine.UI;

public class Computer_Com : MonoBehaviour
{

    [SerializeField] private Image interactPrompt;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        interactPrompt.enabled = true;
        other.gameObject.GetComponent<PlayerSpaceship>().at = PlayerSpaceship.At.ComputerCom;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        interactPrompt.enabled = false;
        other.gameObject.GetComponent<PlayerSpaceship>().at = PlayerSpaceship.At.Nothing;
    }
    
}
