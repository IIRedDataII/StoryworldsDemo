using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Window : Interactable
{
    [SerializeField] private GameObject cityPicture;

    private GameObject _currView;

    protected override void SpecificAction()
    {
        if(!_currView) _currView = Instantiate(cityPicture, transform);
    }

    private void Update()
    {
        if (Active && (Input.GetButtonDown("UndoInteract") || Input.GetMouseButtonDown(0)))
        {
            UndoAction();
        }
    }
    protected override void UndoSpecificAction()
    {
        Destroy(_currView);
    }
    
}