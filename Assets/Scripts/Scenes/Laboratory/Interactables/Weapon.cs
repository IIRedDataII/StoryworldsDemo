using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable
{
    public void Start()
    {
        if (GameData.Instance.CanShoot)
        {
            Destroy(gameObject);
        }
    }
    
    protected override void SpecificAction()
    {
        GameData.Instance.CanShoot = true;
        UndoAction();
        //Enter TextBox Stuff for weapon, Maybe enable Weapon GUI Stuff
        Destroy(gameObject);
    }

    protected override void UndoSpecificAction()
    {
        //Not necessary, but it has to be there, cause abstract class n stuff
    }

    protected override void SpecificUpdate()
    {
        //Not necessary, but it has to be there, cause abstract class n stuff
    }
    
}
