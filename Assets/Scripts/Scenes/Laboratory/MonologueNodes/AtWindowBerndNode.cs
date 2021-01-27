public class AtWindowBerndNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.AtWindowBernd;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.WindowBerndMonologue;
        GameData.Instance.SeenBernd = true;
    }
    
}