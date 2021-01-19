using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Com : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private Image familyMessageLog;
    
    protected override void SpecificAction()
    {
        familyMessageLog.enabled = true;
        
        GameData.Instance.ReadFamilyLog = true;
    }

    protected override void UndoSpecificAction()
    {
        familyMessageLog.enabled = false;
                        
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja supi."
        };
        messageBox.ShowMonologue("Jordan", messages);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
