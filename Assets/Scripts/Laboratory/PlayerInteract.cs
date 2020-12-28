using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Interactable _interactable;

    private bool _canInteract = false;

    /*
     * Script to be attached to player
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        _interactable = other.GetComponent<Interactable>();
        _interactable.highlight.SetActive(true);
        _canInteract = true;
    }

    private void Update()
    {
        if (_canInteract && _interactable && Input.GetButton("Interact") )
        {
            _interactable.Action(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactable.highlight.SetActive(false);
        _interactable = null;
        _canInteract = false;
    }
}