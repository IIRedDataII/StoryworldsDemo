public class AtSpaceshipNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.AtSpaceship;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.AtSpaceshipMonologue;
    }
    
}