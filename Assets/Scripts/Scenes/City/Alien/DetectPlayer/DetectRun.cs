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
        Debug.Log("Enemy spotted! Running (" + Direction + ")...");
        Run = true;

        MoreSpecificDetectAction();
    }
    
    #endregion

    #region Abstract Functions
    
    protected abstract void MoreSpecificDetectAction();
    
    #endregion

    #region Public Functions
    
    // nessecary to test for relevant collision with the tilemap, see TilemapCollision script
    public bool GetRun()
    {
        return Run;
    }
    
    #endregion
    
}
