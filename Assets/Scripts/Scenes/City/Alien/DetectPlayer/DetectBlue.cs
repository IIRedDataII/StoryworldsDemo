public class DetectBlue : DetectAlert
{

    private const float DelayBlue = 5f;
    
    protected override void SpecificStart()
    {
        Delay = DelayBlue;
    }
    
}
