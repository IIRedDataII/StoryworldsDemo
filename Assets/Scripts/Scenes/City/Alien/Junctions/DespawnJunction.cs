using UnityEngine;

public class DespawnJunction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien") && other.GetComponent<AlienBehaviour>().CompareInnerCollider(other))
        {
            Destroy(other.gameObject);
        }
    }
    
}
