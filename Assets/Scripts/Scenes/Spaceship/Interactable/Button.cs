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
                messageBox.ShowMonologue("Jordan", Texts.StartButtonFullMonologue);
            }
            else
            {
                messageBox.ShowMonologue("Jordan", Texts.StartButtonHalfMonologue);
            }
            
            _readEnd = true;
            
        }
        else
        {
            messageBox.ShowMonologue("Jordan", Texts.StartButtonPreMonologue);
        }
        
    }

    protected override void SpecificUpdate()
    {
        if (_readEnd && !messageBox.GetMessageActive())
        {
            Utils.SetPlayerControls(false);
            SetButtons(true);
            _readEnd = false;
        }
    }

    #region Helper Functions
    
    private void SetButtons(bool active)
    {
        leaveButton.gameObject.SetActive(active);
        if (GameData.Instance.WasInChurch)
            stayButton.gameObject.GetComponentInChildren<Text>().text = "stay on this planet and help the rebels";
        stayButton.gameObject.SetActive(active);
        deferButton.gameObject.SetActive(active);
    }
  
    #endregion

    #region Button Functions
    
    public void Stay()
    {
        Debug.Log("End: Stay");
        Utils.SetPlayerControls(true);
        SetButtons(false);
    }
    
    public void Leave()
    {
        Debug.Log("End: Leave");
        Utils.SetPlayerControls(true);
        SetButtons(false);
    }

    public void Defer()
    {
        Utils.SetPlayerControls(true);
        SetButtons(false);
    }
    
    #endregion
    
}
