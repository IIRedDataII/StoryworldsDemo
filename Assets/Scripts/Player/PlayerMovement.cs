using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 7;
    
    #endregion
    
    #region Variables

    public static bool LookingRight;

    [SerializeField] private Sprite lookRight;
    [SerializeField] private Sprite lookLeft;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    
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
        _spriteRenderer = GetComponent<SpriteRenderer>();

        #endregion

    }

    private void Update()
    {
        
        #region Direction

        if (CanMove)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                LookingRight = false;
                _spriteRenderer.sprite = lookLeft;
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                LookingRight = true;
                _spriteRenderer.sprite = lookRight;
            }

            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

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
