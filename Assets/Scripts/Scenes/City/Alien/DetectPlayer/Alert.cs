using UnityEngine;

public class Alert : DetectPlayer
{
    
    protected override void DetectAction()
    {
        Debug.Log("Enemy spotted! Preferred action: Alert! (Gold, Blue & Green)");
    }
    
}
