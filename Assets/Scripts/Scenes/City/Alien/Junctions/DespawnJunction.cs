using UnityEngine;

public class DespawnJunction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Alien"))
        {
            Pathing pathingScript = other.GetComponent<Pathing>();
            if (pathingScript && other == other.GetComponent<Pathing>().innerCollider)
            {
                Destroy(other.gameObject);
            }
        }

    }
    
}
