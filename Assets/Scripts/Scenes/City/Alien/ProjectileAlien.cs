using System;
using UnityEngine;

public class ProjectileAlien : MonoBehaviour
{

    private const float Speed = 0.1f;
    private Vector2 _direction;

    private void Start()
    {
        _direction = AngleToVector(transform.rotation.eulerAngles.z);
    }

    private void Update()
    {
        transform.position += new Vector3(_direction.x, _direction.y, 0f) * Speed;
    }
    
    private Vector2 AngleToVector(double angleDeg)
    {
        double angleRad = angleDeg * Math.PI / 180;
        return new Vector2((float) Math.Cos(angleRad), (float) Math.Sin(angleRad)).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // friendly fire
        if (other.CompareTag("Alien"))
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
}
