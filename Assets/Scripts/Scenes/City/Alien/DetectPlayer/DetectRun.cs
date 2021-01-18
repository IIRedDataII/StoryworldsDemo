using UnityEngine;

public abstract class DetectRun : DetectPlayer
{

    #region Variables
    
    // protected variables
    protected bool Run;
    protected float Speed;
    protected float RecognizeDelay;
    protected Vector3 Direction;
    
    #endregion
    
    private void FixedUpdate()
    {
        
        #region Move
        
        if (Run)
            transform.position += Direction * Speed;
    
        #endregion
        
    }
    
    #region Public Functions
    
    public bool GetRun()
    {
        return Run;
    }
    
    #endregion
    
}
