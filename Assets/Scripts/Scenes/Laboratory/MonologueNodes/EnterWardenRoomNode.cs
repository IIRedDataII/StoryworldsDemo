public class EnterWardenRoomNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.EnterWardenRoom;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.EnterWardenRoomMonologue;
    }
    
}