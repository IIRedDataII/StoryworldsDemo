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
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?");
        messages.AddLast("Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...");
        messages.AddLast("Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?");
        if (GameData.Instance.WasInChurch)
        {
            messages.AddLast("Oder soll ich hierbleiben? Ich verdanke den Rebellen mein Leben. Möglicherweise kann ich ihnen wirklich helfen...");
            messages.AddLast("Vielleicht finde ich in ihnen sogar eine neue Familie? Ein neues Leben? Wer weiß, ob ich je wieder einen so bewohnbaren Planeten finde?");
        }
        messageBox.ShowMonologue("Jordan", messages);
        
        _readEnd = true;
    }

    protected override void SpecificUpdate()
    {
        if (_readEnd && !messageBox.GetMessageActive())
        {
            SetPlayerControls(false);
            SetButtons(true, GameData.Instance.WasInChurch);
            _readEnd = false;
        }
    }

    #region Helper Functions
    
    private void SetButtons(bool active, bool includeStayButton)
    {
        leaveButton.gameObject.SetActive(active);
        if (includeStayButton)
            stayButton.gameObject.SetActive(active);
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
        SetButtons(false, true);
    }
    
    public void Leave()
    {
        Debug.Log("End: Leave");
        SetPlayerControls(true);
        SetButtons(false, true);
    }

    public void Defer()
    {
        SetPlayerControls(true);
        SetButtons(false, true);
    }
    
    #endregion
    
}
