using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 10;
    
    #endregion
    
    #region Variables
    
    private Rigidbody2D rigidBody;
    private Vector2 direction;
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
        rigidBody = GetComponent<Rigidbody2D>();
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Direction
        
        if (CanMove)
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
            direction = Vector2.zero;
        
        #endregion
        
    }

    private void FixedUpdate()
    {
        
        #region Rigidbody 
        
        rigidBody.velocity = direction * Speed;
        
        #endregion
        
    }
    
}
