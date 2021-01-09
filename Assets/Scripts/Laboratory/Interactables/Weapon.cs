using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable
{

    protected override void SpecificAction()
    {
        PlayerShoot.canShoot = true;
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
