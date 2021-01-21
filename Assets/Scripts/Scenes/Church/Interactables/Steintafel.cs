using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
                    PlayerKirche.LetztesBildWasEnabled = true;
                    break;
                default: throw new NullReferenceException("no number");
            }
        }
    }

    protected override void UndoSpecificAction()
    {
        switch (number)
        {
            case 0: zweiteVision.enabled = false;
                messageBox.ShowMonologue("Jordan", Texts.VisionTwoMonologue);
                break;
            case 1: dritteVision.enabled = false;
                messageBox.ShowMonologue("Jordan", Texts.VisionThreeMonologue);
                break;
            case 2: ersteVision.enabled = false;
                messageBox.ShowMonologue("Jordan", Texts.VisionOneMonologue);
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
