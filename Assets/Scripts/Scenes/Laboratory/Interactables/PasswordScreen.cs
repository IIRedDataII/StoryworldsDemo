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
        messageBox.ShowMonologue(GameData.Instance.CanTranslate ? "Translator" : "Jordan", GameData.Instance.CanTranslate ? Texts.PasswordScreenTranslatorMonologue : Texts.PasswordScreenRawMonologue);
    }

    protected override void SpecificUpdate()
    {
        
    }
    
}
