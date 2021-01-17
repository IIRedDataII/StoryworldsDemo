using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernd : Interactable
{
    
    public MessageBox messageBox;
    public Sprite dead;

    private void Awake()
    {
        if (GameData.Instance.BerndDead)
        {
            gameObject.tag = "Untagged";
            gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        }
    }

    protected override void SpecificAction()
    {
       UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        string[] messages = {
            "jo du wichser wegen dir bin ich hier",
            "halts maul wir haben größere Probleme, wir kommen hier nie wieder weg deswegen bring ich dich jetzt um",
            "oh nein jetzt bin ich gezwungen dich zu erschießen"
        };
        messageBox.ShowDialogue("Jordan", "Bernd", new LinkedList<string>(messages));
    }

    protected override void SpecificUpdate()
    {
        
    }
    
    public void Kill()
    {
        GameData.Instance.BerndDead = true;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
    }
    
}
