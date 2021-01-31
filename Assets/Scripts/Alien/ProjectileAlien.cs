using UnityEngine;

public class ProjectileAlien : MonoBehaviour
{

    #region Consatants
    
    private const float Speed = 0.2f;
    
    #endregion
    
    #region Variables

    // private variables
    private Vector2 _direction;
    
    #endregion

    private void Start()
    {
        
        #region Initialization
        
        _direction = Utils.AngleToVector(transform.rotation.eulerAngles.z);
    
        #endregion
        
    }

    private void FixedUpdate()
    {
        
        #region Move
        
        transform.position += new Vector3(_direction.x, _direction.y, 0f) * Speed;
    
        #endregion
        
    }
    
    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // ignore aliens, warden aliens, junctions in city, scene changers, interactables & "objects"
        if (other.CompareTag("Alien") ||
            other.CompareTag("Warden") ||
            other.CompareTag("Projectile") ||
            other.CompareTag("Junction") ||
            other.CompareTag("SceneChange") ||
            other.CompareTag("Interactable") ||
            other.CompareTag("Box") ||
            other.CompareTag("Object"))
            return;
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerDeath>().Die(Texts.AlienDeathMessages);
        }
        
        else
        {
            Debug.Log("Alien shot and hit \"" + other + "\"!");
            Destroy(gameObject);
        }
        
    }
    
    #endregion
    
}
