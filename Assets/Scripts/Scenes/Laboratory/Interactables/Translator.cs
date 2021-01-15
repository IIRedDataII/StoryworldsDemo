using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : Interactable
{
    [SerializeField] private MessageBox box;
    protected override void SpecificAction()
    {
        PlayerInteract.CanTranslate = true;
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Moment, ist das...? Nein, das kann ich nicht glauben!");
        messages.AddLast("Doch, das ist unser Translator. Vieleicht kann ich ihn benutzen um hier raus zu kommen.");
        messages.AddLast("Es sollte auf jeden Fall einfacher sein, wenn ich einen Teil dieser Texte verstehen kann.");
        box.ShowMonologue("Jordan",messages);
        Destroy(gameObject);
    }

    protected override void SpecificUpdate()
    {
        if (!box.GetMessageActive() && Active)
        {
            UndoAction();
        }
    }
}
