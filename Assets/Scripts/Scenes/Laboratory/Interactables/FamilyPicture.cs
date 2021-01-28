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
        GameData.Instance.SeenFamilyPicture = true;
    }

    protected override void UndoSpecificAction()
    {
        familyImage.enabled = false;
        box.ShowMonologue("Jordan", GameData.Instance.CanTranslate ? Texts.FamilyPictureFullMonologue : Texts.FamilyPictureHalfMonologue);
    }
    
    protected override void SpecificUpdate()
    {
        
    }
}
