using System.Collections;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    
    public GameObject highlight;
    protected PlayerMovement PlayerMovement;
    protected PlayerInteract PlayerInteract;
    protected PlayerShoot PlayerShoot;
    protected CapsuleCollider2D PlayerCollider;
    protected bool Active;
    
    private void Start()
    {
        highlight.SetActive(false);
    }

    public void Action(GameObject other)
    {
        
        // Disable Players abilities and collider
        PlayerMovement = other.GetComponent<PlayerMovement>();
        PlayerInteract = other.GetComponent<PlayerInteract>();
        PlayerShoot = other.GetComponent<PlayerShoot>();
        PlayerCollider = other.GetComponent<CapsuleCollider2D>();
        if (PlayerMovement && PlayerInteract && PlayerShoot && PlayerCollider)
        {
            Active = true;
            PlayerMovement.CanMove = false;
            PlayerInteract.enabled = false;
            PlayerShoot.AllowInput = false;
            PlayerCollider.enabled = false;
            SpecificAction();
        }
        
    }

    protected void UndoAction()
    {
        
        PlayerMovement.CanMove = true;
        PlayerInteract.enabled = true;
        PlayerCollider.enabled = true;
        PlayerShoot.AllowInput = true;
        PlayerMovement = null;
        PlayerInteract = null;
        PlayerShoot = null;
        PlayerCollider = null;
        Active = false;
        UndoSpecificAction();
        
    }
    
    private void Update()
    {
        SpecificUpdate();
        
        if (Active && (Input.GetButtonDown("UndoInteract")))
        {
            UndoAction();
        }
    }

    protected abstract void SpecificAction();
    
    protected abstract void UndoSpecificAction();

    protected abstract void SpecificUpdate();
    
    private IEnumerable Wait()
    {
        yield return new WaitForFixedUpdate();
    }
    
}
