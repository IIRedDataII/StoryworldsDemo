using UnityEngine;

public class RightJunction : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien") && other.GetComponent<AlienBehaviour>().CompareInnerCollider(other))
        {
            other.gameObject.GetComponent<Pathing>().direction = Vector3.right;
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
