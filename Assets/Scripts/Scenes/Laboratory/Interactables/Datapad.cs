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
        if (GameData.Instance.CanTranslate)
        {
            string[] messages =
            {
                " ...Spezies scheint durch Bahnen mit roter Flüssigkeit versorgt zu werden...",
                "... oberer Teil enthält Hauptsteuerzentrale...\n...benötigen gleiche Umgebung zum leben...",
                "... zeigen Empfindlichkeit zu ...,",
                "Dieser Bericht meint bestimmt uns Menschen. Aber wie sind sie an all diese Daten gekommen?"
            };
            box.ShowMonologue("Translator", messages);
        }
        else
        {
            string[] messages =
            {
                "Hmm.. dieses Tablet zeigt eine Skizze eines Menschen, aber ich kann den Text daneben nicht verstehen.",
                "Wir haben doch einen Translator bekommen. Vielleicht hilft der mir weiter."
            };
            box.ShowMonologue("Jordan", messages);
        }
        
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
