using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : DetectPlayer
{
    
    protected override void DetectAction()
    {
        Debug.Log("Alert! (Gold, Blue & Green)");
    }
    
}
