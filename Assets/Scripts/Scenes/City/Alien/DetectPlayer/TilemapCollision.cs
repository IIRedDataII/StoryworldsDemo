using UnityEngine;

public class TilemapCollision : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien") && other.GetComponent<AlienBehaviour>().CompareInnerCollider(other) ) {
            DetectRun detectRun = other.GetComponent<DetectRun>();
            if (detectRun && detectRun.GetRun())
            {
                Destroy(other.gameObject);
            }
        }
    }
    
}
