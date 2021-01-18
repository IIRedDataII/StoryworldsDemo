using System.Collections;
using UnityEngine;

public class PoliticianSpawnJunction : MonoBehaviour
{
    
    #region Constants
    
    private const float GroupSpawnDelay = 10f;
    private const float SpawnDelay = 0.5f;
    
    #endregion

    #region Variables

    public GameObject alienSoldier;
    public GameObject alienPolitician;

    #endregion

    private void Start()
    {
        
        #region Initial Calls
        
        StartCoroutine(SpawnPolitician());
        
        #endregion
        
    }

    #region Coroutines
    
    private IEnumerator SpawnPolitician()
    {
        Vector3 position = transform.position;
        while (true)
        {
            Instantiate(alienPolitician, position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            yield return new WaitForSeconds(SpawnDelay);
            Instantiate(alienSoldier, position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            yield return new WaitForSeconds(SpawnDelay);
            Instantiate(alienSoldier, position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            yield return new WaitForSeconds(GroupSpawnDelay);
        }
    }
    
    #endregion
    
}
