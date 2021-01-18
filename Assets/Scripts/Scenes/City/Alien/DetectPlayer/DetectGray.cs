using System;
using System.Collections;
using UnityEngine;

public class DetectGray : DetectPlayer
{

    private const float DelayShoot = 3f;
    
    [SerializeField] private Sprite shootingSprite;
    [SerializeField] private GameObject projectile;
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
        GetComponent<SpriteRenderer>().sprite = shootingSprite;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(DelayShoot);
            Vector3 position = transform.position;
            Vector3 shootDirection = Player.transform.position - position;
            Instantiate(projectile, position, Quaternion.Euler(0, 0, (float) VectorToAngle(shootDirection)));
        }
    }
    
    private double VectorToAngle(Vector2 vector)
    {
        double angleDeg = 180 / Math.PI * Math.Asin(Math.Abs(vector.y) / vector.magnitude);
        
        if (vector.x < 0)
            angleDeg = 180 - angleDeg;
        if (vector.y < 0)
            angleDeg *= -1;

        return angleDeg;
    }

}
