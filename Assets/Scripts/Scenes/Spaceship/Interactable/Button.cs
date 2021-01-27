using UnityEngine;
using UnityEngine.UI;

public class Button : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private Image stayButton;
    [SerializeField] private Image leaveButton;
    [SerializeField] private Image deferButton;
    [SerializeField] private GameObject ending1;
    [SerializeField] private GameObject ending2;
    [SerializeField] private GameObject ending3;
    private bool _readEnd;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        
        if (GameData.Instance.ReadEarthLog && GameData.Instance.ReadFamilyLog)
        {
            
            messageBox.ShowMonologue("Jordan", GameData.Instance.RebelConversationHappened ? Texts.StartButtonFullMonologue : Texts.StartButtonHalfMonologue);

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
        if (GameData.Instance.RebelConversationHappened)
            stayButton.gameObject.GetComponentInChildren<Text>().text = "stay on this planet and help the rebels";
        stayButton.gameObject.SetActive(active);
        deferButton.gameObject.SetActive(active);
    }
  
    #endregion

    #region Button Functions
    
    public void Leave()
    {
        ending1.SetActive(true);
        SetButtons(false);
    }
    
    public void Stay()
    {
        if (GameData.Instance.RebelConversationHappened)
            ending3.SetActive(true);
        else
            ending2.SetActive(true);
        SetButtons(false);
    }

    public void Defer()
    {
        Utils.SetPlayerControls(true);
        SetButtons(false);
    }
    
    #endregion
    
}
