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

        if (!messageBox.GetMessageActive())
        {
            switch (number)
            {
                case 0:
                    zweiteVision.enabled = true;
                    break;
                case 1:
                    dritteVision.enabled = true;
                    break;
                case 2:
                    ersteVision.enabled = true;
                    PlayerKirche.letztesBildWasEnabled = true;
                    break;
                default: throw new NullReferenceException("no number");
            }
        }
    }

    protected override void UndoSpecificAction()
    {
        string[] messages;
        switch (number)
        {
            case 0: zweiteVision.enabled = false;
                messages = new string[1];
                messages[0] = "Sieht aus als wären alle tot!";
                messageBox.ShowMonologue("Jordan", messages);
                break;
            case 1: dritteVision.enabled = false;
                messages = new string[1];
                messages[0] = "jo des bin ja ich auf dem bild";
                messageBox.ShowMonologue("Jordan", messages);
                break;
            case 2: ersteVision.enabled = false;
                messages = new string[1];
                messages[0] = "Erlösung!";
                messageBox.ShowMonologue("Jordan", messages);
                break;
            default: throw new NullReferenceException("no number");  
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
