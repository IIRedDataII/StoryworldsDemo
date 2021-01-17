using UnityEngine;

public class LeftJunction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien") && other.GetComponent<AlienBehaviour>().CompareInnerCollider(other))
        {
            other.gameObject.GetComponent<Pathing>().direction = Vector3.left;
            other.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
}
