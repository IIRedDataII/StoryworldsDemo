using UnityEngine;

public class Run : DetectPlayer
{
    
    protected override void DetectAction()
    {
        Debug.Log("Enemy spotted! Preferred action: Run! (Red & Black)");
    }
    
}
