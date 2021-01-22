using UnityEngine;

public class AlienPod : Interactable
{
    
    [SerializeField] private MessageBox messageBox;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        messageBox.ShowMonologue("Jordan", Texts.MainRoomCapsulesMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
