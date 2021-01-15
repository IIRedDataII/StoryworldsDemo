using System.Collections;
using UnityEngine;

public class WorkerSpawnJunction : MonoBehaviour
{
    
    #region Constants
    
    private const float SpawnDelay = 6.5f;
    
    #endregion

    #region Variables
    
    public GameObject alienWorker;

    #endregion
    
    private void Start()
    {
        
        #region Initial Calls
        
        StartCoroutine(SpawnWorker());
        
        #endregion
        
    }

    #region Coroutines
    
    private IEnumerator SpawnWorker()
    {
        Vector3 position = transform.position;
        while (true)
        {
            Instantiate(alienWorker, position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
    
    #endregion
    
}
