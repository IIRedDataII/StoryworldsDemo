using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected PlayerMovement Player;
    protected bool Active = false;
    public GameObject highlight;

    private void Awake()
    {
        highlight.SetActive(false);
    }

    public void Action(GameObject other)
    {
        Player = other.GetComponent<PlayerMovement>();
        if (Player)
        {
            SpecificAction();
            Active = true;
            Player.gameObject.SetActive(false);
            
        }

    }

    public void UndoAction()
    {
        //Surprise tool that will help us later
        Player.gameObject.SetActive(true);
        Player = null;
        Active = false;
        UndoSpecificAction();
    }

    protected abstract void SpecificAction();
    
    protected abstract void UndoSpecificAction();

    private IEnumerable Wait()
    {
        yield return new WaitForFixedUpdate();
    }
}