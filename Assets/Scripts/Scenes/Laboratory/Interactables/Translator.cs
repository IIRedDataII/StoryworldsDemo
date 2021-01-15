using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : Interactable
{
    [SerializeField] private MessageBox _box;
    protected override void SpecificAction()
    {
        PlayerInteract.CanTranslate = true;
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Moment, ist das...? Nein, das kann ich nicht glauben!");
        messages.AddLast("Doch, das ist unser Translator. Vieleicht kann ich benutzen um hier raus zu kommen.");
        messages.AddLast("Es sollte mir auf jeden Fall einfacher Fallen wenn ich einen Teil dieser Texte verstehen kann.");
        _box.ShowMonologue("Jordan",messages);
        Destroy(gameObject);
    }

    protected override void SpecificUpdate()
    {
        //TODO: Fix MessageBox Stuff
        if (!_box.GetMessageActive() && Active)
        {
            UndoAction();
        }
    }
}
