using UnityEngine;

public class LeftJunction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Alien"))
        {
            Pathing pathingScript = other.GetComponent<Pathing>();
            if (pathingScript && other == other.GetComponent<Pathing>().innerCollider)
            {
                other.gameObject.GetComponent<Pathing>().direction = Vector3.left;
                other.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
    
}
