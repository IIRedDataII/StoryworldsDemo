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
        PlayerMovement.CanMove = false;
    }

    protected override void UndoSpecificAction()
    {
        earthMessageLog.enabled = false;
                        
        PlayerMovement.CanMove = true;
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja supi."
        };
        messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
    }

    protected override void SpecificUpdate()
    {
        
    }

}
