using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    private bool _readEnd;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        if (GameData.Instance.WasInChurch)
        {
            string[] messages = {
                "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
                "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
                "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?",
                "Oder soll ich hierbleiben? Ich verdanke den Rebellen mein Leben. Möglicherweise kann ich ihnen wirklich helfen...",
                "Vielleicht finde ich in ihnen sogar eine neue Familie? Ein neues Leben? Wer weiß, ob ich je wieder einen so bewohnbaren Planeten finde?"
            };
            messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
            _readEnd = true;
        }
        else
        {
            messageBox.ShowMessage("Jordan", "Ich möchte mich hier lieber noch etwas umsehen, bevor ich das Schiff starte.");
        }
    }

    protected override void SpecificUpdate()
    {
        if (_readEnd && !messageBox.GetMessageActive())
        {
            Ending();
            _readEnd = false;
        }
    }

    private void Ending()
    {
        // TODO: add decision & end to demo
        Debug.Log("End: Decision");
    }
    
}
