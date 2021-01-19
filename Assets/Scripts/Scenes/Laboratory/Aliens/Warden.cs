using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warden : DetectPlayer
{
    [SerializeField] private int index;
    protected override void SpecificStart()
    {
        if (!GameData.Instance.GetWardenAliveByIndex(index))
        {
            //Show dead sprite
        }
    }

    protected override void SpecificUpdate()
    {
        
    }

    protected override void SpecificDetectAction()
    {
        throw new System.NotImplementedException();
    }
}
