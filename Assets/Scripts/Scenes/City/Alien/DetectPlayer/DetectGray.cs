using System.Collections;
using UnityEngine;

public class DetectGray : DetectPlayer
{

    private const float DelayShoot = 3f;
    
    private bool _trackPlayer;
    
    protected override void SpecificStart()
    {
        
    }
    
    protected override void SpecificUpdate()
    {
        if (_trackPlayer)
            transform.rotation = Quaternion.Euler(0, Player.transform.position.x < transform.position.x ? 180 : 0, 0);
    }

    protected override void SpecificDetectAction()
    {
        Debug.Log("Enemy spotted! Preferred action: Shoot! (Gray)");
        _trackPlayer = true;
        // Change sprite
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Debug.Log("Shoot!");
            yield return new WaitForSeconds(DelayShoot);
        }
    }
    
}
