using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpaceship : MonoBehaviour
{
    
    #region Enums, Structs, Classes, ...

    public enum At {
        Nothing,
        Button,
        ComputerNav,
        ComputerCom,
    }

    #endregion
    
    #region Variables

    // Unity variables
    [SerializeField] private Image earthMessageLog;
    [SerializeField] private Image familyMessageLog;
    [SerializeField] private MessageBox messageBox;

    // public variables
    public At at;
    
    // private variables
    private bool readEnd;

    #endregion
    
    private void Start()
    {
        
        #region Initialization

        at = At.Nothing;
        
        GameData.Instance.SetGetlastRoom = GameData.LastRoom.Spaceship;
        
        #endregion

    }

    private void Update()
    {
        
        #region Interaction

        if (Input.GetButtonDown("Interact"))
        {
            
            switch (at)
            {
                
                case At.Nothing:
                    
                    Debug.Log("[Spaceship]: Nothing to interact with.");
                    break;
                
                case At.Button:
                    
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
                    break;
                
                case At.ComputerNav:
                    
                    if (earthMessageLog.enabled)
                    {
                        earthMessageLog.enabled = false;
                        
                        PlayerMovement.CanMove = true;
                        DialogueNavigations();
                    }
                    else
                    {
                        earthMessageLog.enabled = true;
                        PlayerMovement.CanMove = false;
                    }
                    break;
                
                case At.ComputerCom:
                    
                    if (familyMessageLog.enabled)
                    {
                        familyMessageLog.enabled = false;
                        
                        PlayerMovement.CanMove = true;
                        DialogueCommunications();
                    }
                    else
                    {
                        familyMessageLog.enabled = true;
                        PlayerMovement.CanMove = false;
                    }
                    break;

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
    
    #region Helper Functions

    private void DialogueCommunications()
    {
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja supi."
        };
        messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
    }
    
    private void DialogueNavigations()
    {
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja blöd."
        };
        messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
    }
    
    #endregion
    
}
