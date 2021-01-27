using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Steintafel : Interactable
{
    
    public MessageBox messageBox;
    [SerializeField] private Image visionOne;
    [SerializeField] private Image visionTwo;
    [SerializeField] private Image visionThree;
    [SerializeField] private int number;
    
    protected override void SpecificAction()
    {

        if (!messageBox.GetMessageActive())
        {
            switch (number)
            {
                case 0:
                    visionOne.enabled = true;
                    PlayerKirche.LetztesBildWasEnabled = true;
                    break;
                case 1:
                    visionTwo.enabled = true;
                    break;
                case 2:
                    visionThree.enabled = true;
                    break;
            }
        }
        
    }

    protected override void UndoSpecificAction()
    {

        string[] preMonologue = GameData.Instance.CanTranslate ? Texts.VisionTranslatorPreMonologue : Texts.VisionRawPreMonologue;
        string[] visionMonologue;
        string[] monologue;
        
        switch (number)
        {
            case 0:
                visionOne.enabled = false;
                visionMonologue = GameData.Instance.RebelConversationHappened ? Texts.VisionOneFullMonologue : Texts.VisionOneHalfMonologue;
                break;
            case 1:
                visionTwo.enabled = false;
                visionMonologue = GameData.Instance.RebelConversationHappened ? Texts.VisionTwoFullMonologue : Texts.VisionTwoHalfMonologue;
                break;
            case 2:
                visionThree.enabled = false;
                visionMonologue = GameData.Instance.RebelConversationHappened ? Texts.VisionThreeFullMonologue : Texts.VisionThreeHalfMonologue;
                break;
            default:
                throw new IndexOutOfRangeException("This is impossible to occur. Good Job.");
        }
        
        if (Utils.CheckOneTimeMessage(GameData.OneTimeMessageID.PreStoneplate))
        {
            monologue = new string[preMonologue.Length + visionMonologue.Length];
            preMonologue.CopyTo(monologue, 0);
            visionMonologue.CopyTo(monologue, preMonologue.Length);
        }
        else
        {
            monologue = visionMonologue;
        }
        messageBox.ShowMonologue("Jordan", monologue);
        
    }

    protected override void SpecificUpdate()
    { 
        
        if (Active && !messageBox.GetMessageActive() && !visionOne.enabled && !visionTwo.enabled && !visionThree.enabled)
        {
            UndoAction();
        }
        
    }

    
}
