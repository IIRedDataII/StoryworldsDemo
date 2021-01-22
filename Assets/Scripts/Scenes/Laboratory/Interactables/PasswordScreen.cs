using UnityEngine;

public class PasswordScreen : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        messageBox.ShowMonologue("Jordan", Texts.PasswordScreenMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
