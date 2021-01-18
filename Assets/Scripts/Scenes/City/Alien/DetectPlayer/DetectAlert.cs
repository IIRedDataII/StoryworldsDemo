using System.Collections;
using UnityEngine;

public abstract class DetectAlert : DetectPlayer
{
    
    private bool _trackPlayer;
    
    protected float Delay;

    protected override void SpecificUpdate()
    {
        if (_trackPlayer)
            transform.rotation = Quaternion.Euler(0, Player.transform.position.x < transform.position.x ? 180 : 0, 0);
    }

    protected override void SpecificDetectAction()
    {
        Debug.Log("Enemy spotted! Alerting (" + Delay + "s)...");
        _trackPlayer = true;
        StartCoroutine(Alert());
    }

    private IEnumerator Alert()
    {
        yield return new WaitForSeconds(Delay);
        Surround();
    }

    private void Surround()
    {
        Debug.Log("You were spotted and the Laboratory Security was alerted. They surrounded you. You lost.");
        PlayerMovement.CanMove = false;
        PlayerInteract.CanInteract = false;
        PlayerShoot.AllowInput = false;
    }
    
}
