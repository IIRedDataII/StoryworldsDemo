public class DetectPolitician : DetectAlert
{

    #region Constants
    
    private const float DelayBlue = 5f;
    
    #endregion
    
    #region Override Functions
    
    protected override void SpecificStart()
    {
        Delay = DelayBlue;
    }
    
    #endregion
    
}
