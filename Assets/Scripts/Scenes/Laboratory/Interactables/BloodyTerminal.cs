using UnityEngine;

public class BloodyTerminal : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        messageBox.ShowMonologue("Jordan", Texts.BloodyTerminalMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
