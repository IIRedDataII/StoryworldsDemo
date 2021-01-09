using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpaceship : MonoBehaviour
{
    
    #region Variables

    // Unity variables
    [SerializeField] private MessageBox messageBox;

    // public variables
    public bool atButton;
    
    // private variables
    private bool readEnd;

    #endregion
    
    private void Update()
    {
        
        #region Button

        if (Input.GetButtonDown("Interact") && atButton)
        {
            
            if (GameData.Instance.WasInChurch)
            {
                string[] messages = {
                    "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
                    "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
                    "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?",
                    "Oder soll ich hierbleiben? Ich verdanke den Rebellen mein Leben. Vielleicht kann ich ihnen wirklich helfen...",
                    "Vielleicht finde ich in ihnen sogar eine neue Familie? Ein neues Leben? Wer weiß, ob ich je wieder einen so bewohnbaren Planeten finde?"
                };
                messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
                        
                readEnd = true;
            }
            else
            {
                messageBox.ShowMessage("Jordan", "Ich möchte mich hier lieber noch etwas umsehen, bevor ich das Schiff starte.");
            }

        }
        
        #endregion
        
        #region End
        
        if (readEnd && !messageBox.GetMessageActive())
        {
            readEnd = false;
            // TODO: Add decision & end to demo
            Debug.Log("End: Decision");
        }

        #endregion
        
    }
 
}
