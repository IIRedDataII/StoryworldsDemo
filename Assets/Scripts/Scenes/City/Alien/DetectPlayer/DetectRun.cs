using UnityEngine;

public abstract class DetectRun : DetectPlayer
{

    #region Variables
    
    // protected variables
    protected bool Run;
    protected float Speed;
    protected Vector3 Direction;
    
    #endregion
    
    private void FixedUpdate()
    {
        
        #region Move
        
        if (Run)
            transform.position += Direction * Speed;
    
        #endregion
        
    }
    
    #region Override Functions
    protected override void SpecificDetectAction()
    {
        Run = true;

        MoreSpecificDetectAction();
    }
    
    #endregion

    #region Abstract Functions
    
    protected abstract void MoreSpecificDetectAction();
    
    #endregion

    #region Public Functions
    
    public bool GetRun()
    {
        return Run;
    }
    
    #endregion
    
}
