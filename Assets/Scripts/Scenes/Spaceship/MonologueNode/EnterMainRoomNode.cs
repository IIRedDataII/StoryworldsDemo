public class EnterMainRoomNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.EnterMainRoom;
    }

    protected override void SetMessage()
    {
        Messages = Texts.EnterMainRoomMonologue;
    }
    
}