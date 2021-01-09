using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 10;
    
    #endregion
    
    #region Variables
    
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    public static bool CanMove
    {
        set;
        get;
    }
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        CanMove = true;
        _rigidBody = GetComponent<Rigidbody2D>();
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Direction
        
        if (CanMove)
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
            _direction = Vector2.zero;
        
        #endregion
        
    }

    private void FixedUpdate()
    {
        
        #region Rigidbody 
        
        _rigidBody.velocity = _direction * Speed;
        
        #endregion
        
    }
    
}
