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
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Wie kommt das denn hier her?");
        messages.AddLast("Das letzte mal das wir uns in den Armen halten konnten. Ava war so traurig das ich weg musste.");
        messages.AddLast("Alice, babe, ich hoffe es geht euch gut. * Visible Sadness *");
        box.ShowMonologue("Jordan",messages);
    }
    
    protected override void SpecificUpdate()
    {
        
    }
}
