public class ExploreCityNode : MonologueNode
{
    
    private const int ID = 0;
    
    protected override void SpecificStart()
    {
        if (GameData.Instance.TriggeredMonologueNodes.Contains(ID))
            Destroy(gameObject);
        GameData.Instance.TriggeredMonologueNodes.Add(ID);
        Messages = Texts.ExploreCityMonologue;
    }
    
}
