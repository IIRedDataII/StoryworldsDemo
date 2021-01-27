public class AtExperimentTableNode : MonologueNode
{
    
    protected override void SpecificStart()
    {
        ID = GameData.MonologueNodeID.AtExperimentTable;
    }
    
    protected override void SetMessage()
    {
        Messages = Texts.ExperimentTableMonologue;
    }
    
}