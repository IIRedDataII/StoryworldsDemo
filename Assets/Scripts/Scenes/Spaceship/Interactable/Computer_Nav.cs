using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Nav : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private Image earthMessageLog;
    
    protected override void SpecificAction()
    {
        earthMessageLog.enabled = true;
        
        GameData.Instance.ReadEarthLog = true;
    }

    protected override void UndoSpecificAction()
    {
        earthMessageLog.enabled = false;
        messageBox.ShowMonologue("Jordan", GameData.Instance.ReadFamilyLog ? Texts.EarthMessageLogFullMonologue : Texts.EarthMessageLogHalfMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }

}
