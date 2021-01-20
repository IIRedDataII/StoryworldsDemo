using System.Collections;
using UnityEngine;

public class Surround : MonoBehaviour
{
    
    #region Constants

    private const float StartingDistance = 13f;
    private const float EndingDistance = 2f;
    private const float NearingSpeed = 2f;
    
    #endregion

    #region Variables
    
    // static variables
    public static bool Trigger;
    
    // Unity variables
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector3 surroundPosition;

    // private variables
    private bool _triggerBlocked;
    
    #endregion
    
    private void Update()
    {
        
        #region Trigger

        if (Trigger && !_triggerBlocked)
        {
            transform.position = player.transform.position + (surroundPosition * StartingDistance);
            
            StartCoroutine(SurroundAnimation());
            _triggerBlocked = true;
        }

        #endregion
        
    }

    #region Coroutines
    
    private IEnumerator SurroundAnimation()
    {
        Vector3 position = transform.position;
        Vector3 playerPosition = player.transform.position;
        Vector3 endPosition = playerPosition + surroundPosition * EndingDistance;

        float smoothness = 100f;
        float iterationSegment = 1 / (NearingSpeed * smoothness);
        float iterationDelay = 1 / smoothness;
        
        float counter = 0;
        while (counter <= 1f)
        {
            transform.position = Vector3.Lerp(position, endPosition, counter);
            counter += iterationSegment;
            yield return new WaitForSeconds(iterationDelay);
        }
        yield return new WaitForSeconds(1f);

        Transform thisTransform = transform;
        Vector3 newPosition = thisTransform.position;
        
        Vector3 projectileOffset = new Vector3(thisTransform.rotation.y == 0 ? 0.75f : -0.75f, 0.215f, 0f);
        Vector3 shootDirection = (player.transform.position - (newPosition + projectileOffset)).normalized;
        Instantiate(projectile, newPosition + projectileOffset, Quaternion.Euler(0, 0, (float) Utils.VectorToAngle(shootDirection)));
    }

    #endregion
    
}
