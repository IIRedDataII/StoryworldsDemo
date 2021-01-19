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
        string[] messages =
        {
            "Wie kommt das denn hier her?!",
            "Das letzte mal das wir uns in den Armen halten konnten. Ava war so traurig, dass ich weg musste.",
            "Alice, babe, ich hoffe es geht euch gut. *visible sadness*"
        };
        box.ShowMonologue("Jordan", messages);
    }
    
    protected override void SpecificUpdate()
    {
        
    }
}
