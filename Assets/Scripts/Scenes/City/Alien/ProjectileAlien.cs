using System;
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
        
        _direction = AngleToVector(transform.rotation.eulerAngles.z);
    
        #endregion
        
    }

    private void FixedUpdate()
    {
        
        #region Move
        
        transform.position += new Vector3(_direction.x, _direction.y, 0f) * Speed;
    
        #endregion
        
    }
    
    #region Helper Functions
    
    private Vector2 AngleToVector(double angleDeg)
    {
        double angleRad = angleDeg * Math.PI / 180;
        return new Vector2((float) Math.Cos(angleRad), (float) Math.Sin(angleRad)).normalized;
    }
    
    #endregion

    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // friendly fire
        if (other.CompareTag("Alien") ||
            other.CompareTag("Projectile") ||
            other.CompareTag("Junction") ||
            other.CompareTag("SceneChange") ||
            other.CompareTag("Interactable"))
            return;
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("You were shot! You lost!");
            PlayerMovement.CanMove = false;
            PlayerInteract.CanInteract = false;
            PlayerShoot.AllowInput = false;
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("Alien hit " + other + "!");
            Destroy(gameObject);
        }
        
    }
    
    #endregion
    
}
