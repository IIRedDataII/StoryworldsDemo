using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected PlayerMovement PlayerMovement;
    protected PlayerInteract PlayerInteract;
    protected CapsuleCollider2D PlayerCollider;
    protected PlayerShoot PlayerShoot;
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
        PlayerCollider = other.GetComponent<CapsuleCollider2D>();
        PlayerShoot = other.GetComponent<PlayerShoot>();
        if (PlayerMovement && PlayerInteract && PlayerCollider && PlayerShoot)
        {
            Active = true;
            PlayerMovement.CanMove = false;
            PlayerInteract.enabled = false;
            PlayerCollider.enabled = false;
            PlayerShoot.allowInput = false;
            SpecificAction();
        }
    }

    protected void UndoAction()
    {
        //Undo Action
        PlayerMovement.CanMove = true;
        PlayerCollider.enabled = true;
        PlayerInteract.enabled = true;
        PlayerShoot.allowInput = true;
        PlayerShoot = null;
        PlayerCollider = null;
        PlayerInteract = null;
        PlayerMovement = null;
        Active = false;
        UndoSpecificAction();
    }
    
    private void Update()
    {
        if (Active && Input.GetButtonDown("UndoInteract"))
        {
            UndoAction();
        }
    }

    protected abstract void SpecificAction();
    
    protected abstract void UndoSpecificAction();
    
}