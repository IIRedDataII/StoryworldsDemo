using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // ignore the player, outer colliders of aliens, junctions in city, scene changers, interactables (except Bernd) & "objects"
        if (other.CompareTag("Player") ||
            other.CompareTag("Alien") && !other.GetComponent<AlienBehaviour>().CompareInnerCollider(other) ||
            other.CompareTag("Junction") ||
            other.CompareTag("SceneChange") ||
            other.CompareTag("Interactable") && !other.name.Equals("Bernd") ||
            other.CompareTag("Object") ||
            other.CompareTag("Warden") && !other.GetComponent<Warden>().CompareInnerCollider(other))
        {
            return;
        }
            
        
        if (other.name.Equals("Bernd") && !GameData.Instance.BerndDead)
        {
            Destroy(gameObject);
            other.GetComponent<Bernd>().Kill();
        }

        else if (other.CompareTag("Alien"))
        {
            Destroy(gameObject);
            other.GetComponent<AlienBehaviour>().Die();
        }
        
        else if (other.CompareTag("Warden"))
        {
            other.GetComponent<Warden>().Kill();
            Destroy(gameObject);
        }
        
        else 
        {
            Debug.Log("Shot! \"" + other + "\" got hit!");
            Destroy(gameObject);
        }
        
    }
}
