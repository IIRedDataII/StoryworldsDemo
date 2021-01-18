using UnityEngine;

public class DetectBlack : DetectRun
{
    
    #region Constants
    
    private const float SpeedBlack = 0.2f;
    
    #endregion

    #region Variables
    
    // Unity variables
    [SerializeField] private Sprite runningSprite;
    
    #endregion
    
    #region Override Functions
    
    protected override void SpecificStart()
    {
        Speed = SpeedBlack;
        SpecificUpdate();
    }
    
    protected override void SpecificUpdate()
    {
        if (Run)
            Direction = Player.transform.position.y >= transform.position.y ? Vector3.down : Vector3.up;
    }

    protected override void MoreSpecificDetectAction()
    {
        GetComponent<SpriteRenderer>().sprite = runningSprite;
    }
    
    #endregion

}
