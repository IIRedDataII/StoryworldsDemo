public class DetectAcademic : DetectAlert
{

    #region Constants
    
    private const float DelayGreen = 7.5f;
    
    #endregion
    
    #region Override Functions
    
    protected override void SpecificStart()
    {
        Delay = DelayGreen;
    }
    
    #endregion

}
