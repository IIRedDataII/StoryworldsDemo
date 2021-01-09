using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    
    public Image interactPrompt;
    
    private bool _canInteract;
    private Interactable _interactable;
    
    private void Start()
    {
        interactPrompt.enabled = false;
    }
    
    private void Update()
    {
        if (_canInteract && _interactable && Input.GetButtonDown("Interact") )
        {
            Input.ResetInputAxes();
            _canInteract = false;
            interactPrompt.enabled = false;
            _interactable.Action(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactPrompt.enabled = true;
            _interactable = other.GetComponent<Interactable>();
            _interactable.highlight.SetActive(true);
            _canInteract = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactPrompt.enabled = false;
            _interactable.highlight.SetActive(false);
            _interactable = null;
            _canInteract = false;
        }
    }
}