using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Datapad : Interactable
{
    [SerializeField] private MessageBox box;
    
    [SerializeField] private Image datapadImage;
    protected override void SpecificAction()
    {
        datapadImage.enabled = true;
    }

    protected override void UndoSpecificAction()
    {
        datapadImage.enabled = false;
        LinkedList<string> speakers = new LinkedList<string>();
        LinkedList<string> messages = new LinkedList<string>();
        if (GameData.Instance.CanTranslate)
        {
            speakers.AddLast("Translator");
            messages.AddLast(" ...Spezies scheint durch Bahnen mit roter Flüssigkeit versorgt zu werden...");
            speakers.AddLast("Translator");
            messages.AddLast(
                "... oberer Teil enthält Hauptsteuerzentrale...\n ...benötigen gleiche Umgebung zum leben...");
            speakers.AddLast("Translator");
            messages.AddLast("... zeigen Empfindlichkeit zu ...");
            speakers.AddLast("Jordan");
            messages.AddLast(
                "Dieser Bericht meint bestimmt uns Menschen. Aber wie sind sie an all diese Daten gekommen?");
        }
        else
        {
            speakers.AddLast("Jordan");
            messages.AddLast(
                "Hmm.. diese Tablet zeigt eine Skizze eines Menschen, aber ich kann den Text daneben nicht verstehen.");
            speakers.AddLast("Jordan");
            messages.AddLast("Wir haben doch einen Translator bekommen. Vielleicht hilft der mir weiter.");
        }
        box.ShowMessages(speakers, messages);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
