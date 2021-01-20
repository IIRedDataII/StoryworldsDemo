using System.Collections;
using UnityEngine;

public class Idle : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(LookAround());
    }

    public IEnumerator LookAround()
    {
        bool looksRight = transform.rotation.y == 0; 
        while (true)
        {
            looksRight = !looksRight;
            transform.rotation = Quaternion.Euler(0, looksRight ? 0 : 180, 0);
            yield return new WaitForSeconds(Random.Range(4f, 8f));
        }
    }
    
}
