public class DetectGreen : DetectAlert
{

    private const float DelayGreen = 7.5f;
    
    protected override void SpecificStart()
    {
        Delay = DelayGreen;
    }

}
