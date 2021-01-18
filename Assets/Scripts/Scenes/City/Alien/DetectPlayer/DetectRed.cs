using UnityEngine;

public class DetectRed : DetectRun
{

    #region Constants
    
    private const float SpeedRed = 0.3f;
    
    #endregion
    
    #region Variables
    
    // Unity variables
    [SerializeField] private Sprite runningSprite;
    
    #endregion

    #region Override Functions
    
    protected override void SpecificStart()
    {
        Speed = SpeedRed;
        Direction = Vector3.right;
    }
    
    protected override void SpecificUpdate()
    {
        
    }

    protected override void MoreSpecificDetectAction()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<SpriteRenderer>().sprite = runningSprite;
    }
    
    #endregion
    
}
