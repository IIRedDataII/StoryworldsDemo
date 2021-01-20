using System.Collections;
using UnityEngine;

public class DetectWarden : DetectPlayer
{

    #region Constants
    
    private const float DelayShoot = 3f;
    
    #endregion
    
    #region Variables
    
    // Unity variables
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
        if (GameData.Instance.CanShoot)
        {
            _trackPlayer = true;
            StartCoroutine(Shoot());
        }
        else
        {
            Utils.SetPlayerControls(false);
            SpawnProjectile();
        }
    }
    
    #endregion
    
    #region HelperFunctions

    private void SpawnProjectile()
    {
        Transform thisTransform = transform;
        Vector3 position = thisTransform.position;
        Vector3 projectileOffset = new Vector3(thisTransform.rotation.y == 0 ? 0.75f : -0.75f, 0.215f, 0f);
        Vector3 shootDirection = Player.transform.position - (position + projectileOffset);
        Instantiate(projectile, position + projectileOffset, Quaternion.Euler(0, 0, (float) Utils.VectorToAngle(shootDirection)));
    }
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(DelayShoot / 3, DelayShoot));
        while (true)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(DelayShoot);
        }
    }

    #endregion
    
}
