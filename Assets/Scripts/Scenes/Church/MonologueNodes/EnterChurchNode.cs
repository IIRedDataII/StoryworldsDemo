public class EnterChurchNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.EnterChurch;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.EnterChurchMonologue;
    }
    
}