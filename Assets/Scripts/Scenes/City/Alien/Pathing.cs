using UnityEngine;

public class Pathing : MonoBehaviour
{

    private const float Speed = 0.05f;

    public Vector3 direction;
    
    public Collider2D innerCollider;
    
    private void FixedUpdate()
    {
        transform.position += direction * Speed;
    }
    
}
