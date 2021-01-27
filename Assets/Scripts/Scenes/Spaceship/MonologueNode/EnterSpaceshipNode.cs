public class EnterSpaceshipNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.EnterSpaceship;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.EnterSpaceshipMonologue;
        GameData.Instance.TriggeredMonologueNodes.Add(GameData.MonologueNodeID.AtSpaceship);
    }
    
}