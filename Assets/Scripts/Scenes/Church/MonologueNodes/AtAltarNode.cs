public class AtAltarNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.AtAltar;
    }

    protected override void SetMessage()
    {
        Messages = Texts.AtChurchAltarMonologue;
    }
    
}
