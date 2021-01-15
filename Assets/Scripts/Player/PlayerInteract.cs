using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    
    #region Variables
    
    public Image interactPrompt;

    public static bool CanTranslate;
    public static bool CanInteract;
    private bool _canInteract;
    private Interactable _interactable;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        CanInteract = true;
        CanTranslate = false;
        interactPrompt.enabled = false;

        #endregion

    }
    
    private void Update()
    {
        
        #region Interaction

        if (CanInteract && _canInteract && !interactPrompt.enabled)
        {
            interactPrompt.enabled = true;
            _interactable.highlight.SetActive(true);
        }
        
        if (!CanInteract && interactPrompt.enabled)
        {
            interactPrompt.enabled = false;
            _interactable.highlight.SetActive(false);
        }

        if (Input.GetButtonDown("Interact") && CanInteract && _canInteract && _interactable)
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
    
    #region Setter & Getter

    /*
    {
        set
        {
            CanInteract = value;
            GameObject.Find("Interact").GetComponent<Image>().enabled = value;
        }
        get => CanInteract;
    }
    */
    
    #endregion
    
}
