using UnityEngine;

public class BerndsProjectile : MonoBehaviour
{ 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerDeath>().Die("Bernd hat die Waffe vor dir erreicht und dich erschossen. Du startest das Spiel jetzt von Beginn.");
        }
    }
    
}
