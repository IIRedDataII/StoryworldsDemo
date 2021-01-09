using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected PlayerMovement PlayerMovement;
    protected PlayerInteract PlayerInteract;
    protected BoxCollider2D PlayerCollider;
    protected bool Active = false;
    public GameObject highlight;

    private void Start()
    {
        highlight.SetActive(false);
    }

    public void Action(GameObject other)
    {
        //Disable Players abilities and collider
        PlayerMovement = other.GetComponent<PlayerMovement>();
        PlayerInteract = other.GetComponent<PlayerInteract>();
        PlayerCollider = other.GetComponent<BoxCollider2D>();
        if (PlayerMovement && PlayerInteract)
        {
            Active = true;
            PlayerMovement.CanMove = false;
            PlayerInteract.enabled = false;
            PlayerCollider.enabled = false;
            SpecificAction();
        }

    }

    public void UndoAction()
    {
        //Undo Action
        PlayerMovement.CanMove = true;
        PlayerCollider.enabled = true;
        PlayerInteract.enabled = true;
        PlayerCollider = null;
        PlayerInteract = null;
        PlayerMovement = null;
        Active = false;
        UndoSpecificAction();
    }
    
    private void Update()
    {
        UpdateSpecific();
        
        if (Active && (Input.GetButtonDown("UndoInteract")))
        {
            UndoAction();
        }
    }

    protected abstract void SpecificAction();
    
    protected abstract void UndoSpecificAction();

    protected abstract void UpdateSpecific();
    
    private IEnumerable Wait()
    {
        yield return new WaitForFixedUpdate();
    }
    
}
