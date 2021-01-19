using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private Image stayButton;
    [SerializeField] private Image leaveButton;
    [SerializeField] private Image deferButton;
    private bool _readEnd;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        
        if (GameData.Instance.ReadEarthLog && GameData.Instance.ReadFamilyLog)
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
                messageBox.ShowMonologue("Jordan", messages);
            }
            else
            {
                string[] messages = {
                    "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
                    "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
                    "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?"
                };
                messageBox.ShowMonologue("Jordan", messages);
            }
            
            _readEnd = true;
            
        }
        else
        {
            messageBox.ShowMessage("Jordan", "Ich möchte mich lieber noch etwas hier umsehen, bevor ich das Schiff starte.");
        }
        
    }

    protected override void SpecificUpdate()
    {
        if (_readEnd && !messageBox.GetMessageActive())
        {
            SetPlayerControls(false);
            SetButtons(true);
            _readEnd = false;
        }
    }

    #region Helper Functions
    
    private void SetButtons(bool active)
    {
        leaveButton.gameObject.SetActive(active);
        stayButton.gameObject.SetActive(active && GameData.Instance.WasInChurch);
        deferButton.gameObject.SetActive(active);
    }
    
    private void SetPlayerControls(bool active)
    {
        PlayerMovement.CanMove = active;
        PlayerInteract.CanInteract = active;
        PlayerShoot.AllowInput = active;
    }
    
    #endregion

    #region Button Functions
    
    public void Stay()
    {
        Debug.Log("End: Stay");
        SetPlayerControls(true);
        SetButtons(false);
    }
    
    public void Leave()
    {
        Debug.Log("End: Leave");
        SetPlayerControls(true);
        SetButtons(false);
    }

    public void Defer()
    {
        SetPlayerControls(true);
        SetButtons(false);
    }
    
    #endregion
    
}
