﻿using UnityEngine;
using UnityEngine.UI;

public class Window : Interactable
{
    [SerializeField] private Image cityImage;

    private void Awake()
    {
        cityImage.enabled = false;
    }

    protected override void SpecificAction()
    {
        cityImage.enabled = true;
    }

    protected override void SpecificUpdate()
    {
        
    }
    protected override void UndoSpecificAction()
    {
        cityImage.enabled = false;
    }
    
}