using UnityEngine;

public class TilemapCollision : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien")) {
            DetectRun detectRun = other.GetComponent<DetectRun>();
            if (other.GetComponent<AlienBehaviour>().CompareInnerCollider(other) && detectRun && detectRun.GetRun())
            {
                Destroy(other.gameObject);
            }
        }
    }
    
}
