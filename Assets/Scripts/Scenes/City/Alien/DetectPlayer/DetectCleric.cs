public class DetectCleric : DetectAlert
{

    #region Constants
    
    private const float DelayGold = 2.5f;
    
    #endregion
    
    #region Override Functions
    
    protected override void SpecificStart()
    {
        Delay = DelayGold;
    }
    
    #endregion
    
}
