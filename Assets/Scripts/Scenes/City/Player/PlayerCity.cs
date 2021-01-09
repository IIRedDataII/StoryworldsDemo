using UnityEngine;

public class PlayerCity : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 10f;
    
    #endregion
    
    #region Variables
    
    // unity variables
    [SerializeField] private MessageBox messageBox;
    
    // variables
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Movement

        if (!messageBox.GetMessageActive())
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
            moveDirection = _rigidbody.velocity = Vector2.zero;

        #endregion

    }

    private void FixedUpdate()
    {
        
        #region Movement
        
        _rigidbody.velocity = moveDirection * Speed;
        
        #endregion
        
    }
    
}
