using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FamilyPicture : Interactable
{
    [SerializeField] private Image familyImage;
    protected override void SpecificAction()
    {
        familyImage.enabled = true;
    }

    protected override void UndoSpecificAction()
    {
        familyImage.enabled = false;
    }
    
    private void Update()
    {
        if (Active && (Input.GetButtonDown("UndoInteract")))
        {
            UndoAction();
        }
    }
}
