using System;
using System.Collections;
using UnityEngine;

public class DetectGray : DetectPlayer
{

    #region Constants
    
    private const float DelayShoot = 3f;
    
    #endregion
    
    #region Variables
    
    // Unity variables
    [SerializeField] private Sprite shootingSprite;
    [SerializeField] private GameObject projectile;
    
    // private variables
    private bool _trackPlayer;
    
    #endregion
    
    #region Override Functions
    
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
        _trackPlayer = true;
        GetComponent<SpriteRenderer>().sprite = shootingSprite;
        StartCoroutine(Shoot());
    }
    
    #endregion
    
    #region Helper Functions
    
    private double VectorToAngle(Vector2 vector)
    {
        double angleDeg = 180 / Math.PI * Math.Asin(Math.Abs(vector.y) / vector.magnitude);
        
        if (vector.x < 0)
            angleDeg = 180 - angleDeg;
        if (vector.y < 0)
            angleDeg *= -1;

        return angleDeg;
    }
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(DelayShoot);
            Transform thisTransform = transform;
            Vector3 position = thisTransform.position;
            Vector3 shootDirection = Player.transform.position - position;
            Vector3 projectileOffset = new Vector3(thisTransform.rotation.y == 0 ? 0.75f : -0.75f, 0.215f, 0f);
            Instantiate(projectile, position + projectileOffset, Quaternion.Euler(0, 0, (float) VectorToAngle(shootDirection)));
        }
    }
    
    #endregion
    
    

}
