using UnityEngine;

public abstract class DetectRun : DetectPlayer
{

    protected bool Run;
    protected float Speed;
    protected Vector3 Direction;
    
    protected override void SpecificDetectAction()
    {
        Debug.Log("Enemy spotted! Running (" + Direction + ")...");
        Run = true;

        MoreSpecificDetectAction();
    }

    protected abstract void MoreSpecificDetectAction();

    
    private void FixedUpdate()
    {
        if (Run)
            transform.position += Direction * Speed;
    }
    

    // nessecary to test for relevant collision with the tilemap, see TilemapCollision script
    public bool GetRun()
    {
        return Run;
    }
    
}
