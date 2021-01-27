public class AtHallwayCapsuleNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.AtHallwayCapsule;
    }
    
    protected override void SetMessage()
    {
        Messages = GameData.Instance.SeenBernd ? Texts.HallwayCapsulesFullMonologue : Texts.HallwayCapsulesHalfMonologue;
    }
    
}