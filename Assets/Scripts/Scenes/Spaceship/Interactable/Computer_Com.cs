﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Com : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private Image familyMessageLog;
    
    protected override void SpecificAction()
    {
        familyMessageLog.enabled = true;
        PlayerMovement.CanMove = false;
    }

    protected override void UndoSpecificAction()
    {
        familyMessageLog.enabled = false;
                        
        PlayerMovement.CanMove = true;
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja blöd."
        };
        messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}