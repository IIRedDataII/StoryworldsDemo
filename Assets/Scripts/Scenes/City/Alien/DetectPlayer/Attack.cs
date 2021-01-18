using UnityEngine;

public class Attack : DetectPlayer
{
    
    protected override void DetectAction()
    {
        Debug.Log("Enemy spotted! Preferred action: Attack! (Gray)");
    }
    
}
