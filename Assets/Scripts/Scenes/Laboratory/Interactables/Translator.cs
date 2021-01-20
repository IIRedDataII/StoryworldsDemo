using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : Interactable
{
    [SerializeField] private MessageBox box;

    public void Start()
    {
        if (GameData.Instance.CanTranslate)
        {
            gameObject.SetActive(false);
        }
    }
    
    protected override void SpecificAction()
    {
        GameData.Instance.CanTranslate = true;
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        string[] messages =
        {
            "Moment, ist das...? Nein, das kann ich nicht glauben!",
            "Doch, das ist unser Translator. Vielleicht kann ich ihn benutzen um hier raus zu kommen.",
            "Es sollte auf jeden Fall einfacher sein, wenn ich einen Teil dieser Texte verstehen kann.",
        };
        box.ShowMonologue("Jordan", messages);
        gameObject.SetActive(false);
    }

    protected override void SpecificUpdate()
    {
        if (!box.GetMessageActive() && Active)
        {
            UndoAction();
        }
    }
}
