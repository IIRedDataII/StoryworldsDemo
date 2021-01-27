public class EnterCityNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.EnterCity;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.EnterCityMonologue;
    }
    
}