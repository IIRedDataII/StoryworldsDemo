
using UnityEngine;

public class BerndsProjectile : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerDeath>().kill();
        }
    }
}
