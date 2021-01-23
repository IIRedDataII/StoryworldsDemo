using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // ignore the player, outer colliders of aliens, warden aliens, junctions in city, scene changers, interactables (except Bernd) & "objects"
        if (other.CompareTag("Player") ||
            other.CompareTag("Alien") && !other.GetComponent<AlienBehaviour>().CompareInnerCollider(other) ||
            other.CompareTag("Warden") && !other.GetComponent<WardenBehaviour>().CompareInnerCollider(other) ||
            other.CompareTag("Projectile") ||
            other.CompareTag("Junction") ||
            other.CompareTag("RebellenTrigger") ||
            other.CompareTag("SceneChange") ||
            other.CompareTag("Interactable") && !other.name.Equals("Bernd") ||
            other.CompareTag("Object"))
            return;
            
        
        if (other.name.Equals("Bernd") && !GameData.Instance.BerndDead)
        {
            Destroy(gameObject);
            other.GetComponent<Bernd>().Kill();
        }
        
        else if (other.CompareTag("Rebel"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Alien"))
        {
            Destroy(gameObject);
            other.GetComponent<AlienBehaviour>().Die();
        }
        
        else if (other.CompareTag("Warden"))
        {
            Destroy(gameObject);
            other.GetComponent<WardenBehaviour>().Die();
        }
        
        else 
        {
            Debug.Log("You shot and hit \"" + other + "\"!");
            Destroy(gameObject);
        }
        
    }
    
}
