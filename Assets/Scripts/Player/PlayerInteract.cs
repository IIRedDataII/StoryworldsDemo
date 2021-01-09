using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    
    #region Variables
    
    public Image interactPrompt;
    
    private bool _canInteract;
    private Interactable _interactable;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        interactPrompt.enabled = false;
        
        #endregion
        
    }
    
    private void Update()
    {
        
        #region Interaction
        
        if (Input.GetButtonDown("Interact") && _canInteract && _interactable)
        {
            Input.ResetInputAxes();
            interactPrompt.enabled = false;
            _canInteract = false;
            _interactable.Action(gameObject);
        }
        
        #endregion
        
    }

    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactPrompt.enabled = true;
            _canInteract = true;
            _interactable = other.GetComponent<Interactable>();
            _interactable.highlight.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactPrompt.enabled = false;
            _canInteract = false;
            _interactable.highlight.SetActive(false);
            _interactable = null;
        }
    }
    
    #endregion
    
}
