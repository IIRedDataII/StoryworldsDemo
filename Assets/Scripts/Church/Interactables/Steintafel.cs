using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steintafel : Interactable
{
    public MessageBox messageBox;
    [SerializeField] private Image zweiteVision;
    [SerializeField] private Image dritteVision;
    [SerializeField] private Image ersteVision;
    [SerializeField] private int number;
    protected override void SpecificAction()
    {
        switch (number)
        {
            case 0: zweiteVision.enabled = true;
                break;
            case 1: dritteVision.enabled = true;
                break;
            case 2: ersteVision.enabled = true;
                break;
            default: throw new NullReferenceException();  
        }
    }

    protected override void UndoSpecificAction()
    {
        LinkedList<string> messages = new LinkedList<string>();
        switch (number)
        {
            case 0: zweiteVision.enabled = false;
                messages.AddLast("Sieht aus als wären alle tot!");
                messageBox.ShowMonologue("Jordan", messages);
                break;
            case 1: dritteVision.enabled = false;
                messages.AddLast("jo des bin ja ich auf dem bild");
                messageBox.ShowMonologue("Jordan", messages);
                break;
            case 2: ersteVision.enabled = false;
                messages.AddLast("Erlösung!");
                messageBox.ShowMonologue("Jordan", messages);
                break;
            default: throw new NullReferenceException();  
        }
    }

    protected override void SpecificUpdate()
    {
        if (Active && !messageBox.GetMessageActive() && !ersteVision.enabled && !zweiteVision.enabled && !dritteVision.enabled)
        {
            UndoAction();
        }
    }

    

    
}
