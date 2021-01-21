using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Datapad : Interactable
{
    [SerializeField] private MessageBox box;
    
    [SerializeField] private Image datapadImage;
    protected override void SpecificAction()
    {
        datapadImage.enabled = true;
    }

    protected override void UndoSpecificAction()
    {
        datapadImage.enabled = false;
        if (GameData.Instance.CanTranslate)
        {
            box.ShowMonologue("Translator", Texts.DatapadTranslated);
        }
        else
        {
            box.ShowMonologue("Jordan", Texts.DatapadRaw);
        }
        
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
