using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;
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

    protected override void UpdateSpecific()
    {
        
    }
    protected override void UndoSpecificAction()
    {
        cityImage.enabled = false;
    }
    
}