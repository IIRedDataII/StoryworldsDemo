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
        LinkedList<string> authors = new LinkedList<string>();
        authors.AddLast("Jordan");
        authors.AddLast("Bernd");
        authors.AddLast("Jordan");
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("jo du wichser wegen dir bin ich hier");
        messages.AddLast("halts maul wir haben größere Probleme, wir kommen hier nie wieder weg deswegen bring ich dich jetzt um");
        messages.AddLast("oh nein jetzt bin ich gezwungen dich zu erschießen");
        messageBox.ShowMessages(authors, messages);
       
    }

    protected override void SpecificUpdate()
    {
        
    }


    public void kill()
    {
        GameData.Instance.BerndDead = true;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
    }
}
