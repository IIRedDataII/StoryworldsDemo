public class AtSoldierAreaNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.AtSoldierArea;
    }
    
    protected override void SetMessage()
    {
        Messages = GameData.Instance.RebelConversationHappened ? Texts.AtSoldierAreaFullMonologue : Texts.AtSoldierAreaHalfMonologue;
    }
    
}
