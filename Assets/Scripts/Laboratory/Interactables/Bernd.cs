using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernd : Interactable
{
    
    public MessageBox messageBox;
    
    protected override void SpecificAction()
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

    protected override void UndoSpecificAction()
    {
        
    }

    protected override void UpdateSpecific()
    {
        if (Active && !messageBox.GetMessageActive())
        {
            UndoAction();
        }
    }
    
}
