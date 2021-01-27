using UnityEngine;

public class CityAltar : Interactable
{

    [SerializeField] private MessageBox messageBox;
    
    protected override void SpecificAction()
    {
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        messageBox.ShowMonologue("Jordan", GameData.Instance.RebelConversationHappened ? Texts.AtCityAltarFullMonologue : Texts.AtCityAltarHalfMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
