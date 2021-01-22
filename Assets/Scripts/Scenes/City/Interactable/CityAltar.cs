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
        messageBox.ShowMonologue("Jordan", Texts.AtCityAltarMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
