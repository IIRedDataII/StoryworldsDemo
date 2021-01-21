using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FamilyPicture : Interactable
{
    [SerializeField] private MessageBox box;
    [SerializeField] private Image familyImage;
    protected override void SpecificAction()
    {
        familyImage.enabled = true;
    }

    protected override void UndoSpecificAction()
    {
        familyImage.enabled = false;
        box.ShowMonologue("Jordan", Texts.FamilyPictureMonologue);
    }
    
    protected override void SpecificUpdate()
    {
        
    }
}
