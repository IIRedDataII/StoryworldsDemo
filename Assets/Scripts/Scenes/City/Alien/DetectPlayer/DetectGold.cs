public class DetectGold : DetectAlert
{

    private const float DelayGold = 2.5f;
    
    protected override void SpecificStart()
    {
        Delay = DelayGold;
    }
    
}
