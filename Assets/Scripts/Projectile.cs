using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // ignore outer collider of aliens, junctions in city & scene changers
        if (other.CompareTag("Alien") && !other.GetComponent<AlienBehaviour>().CompareInnerCollider(other) ||
            other.CompareTag("Junction") ||
            other.CompareTag("SceneChange"))
            return;
        
        if (other.gameObject.name.Equals("Bernd") && !GameData.Instance.BerndDead)
        {
            Destroy(gameObject);
            other.GetComponent<Bernd>().Kill();
        }
        
        else if (other.CompareTag("Alien"))
        {
            Destroy(gameObject);
            other.GetComponent<AlienBehaviour>().Die();
        }

        else if (!other.CompareTag("Player") && !other.CompareTag("Interactable") && !other.CompareTag("Object"))
        {
            Debug.Log("Shot! \"" + other + "\" got hit!");
            Destroy(gameObject);
        }
        
    }
}
