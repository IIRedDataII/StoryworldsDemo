using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : Interactable
{
    [SerializeField] private MessageBox box;

    public void Awake()
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
        box.ShowMonologue("Jordan", GameData.Instance.SeenFamilyPicture ? Texts.TranslatorFullMonologue : Texts.TranslatorHalfMonologue);
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
