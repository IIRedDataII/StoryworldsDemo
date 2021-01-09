using UnityEngine;

public class PlayerCity : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 10f;
    
    #endregion
    
    #region Variables
    
    // unity variables
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private GameObject laboratoryJunction;
    [SerializeField] private GameObject spaceshipJunction;
    [SerializeField] private GameObject curchJunction;
    
    // variables
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
        #endregion
        
        #region Player Placement
        
        switch (GameData.Instance.setGetlastRoom)
        {
            case GameData.LastRoom.Spaceship:
                gameObject.transform.position = spaceshipJunction.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
                break;
            case GameData.LastRoom.Lab:
                gameObject.transform.position = laboratoryJunction.transform.position + new Vector3(2.0f, 0.0f, 0.0f);
                break;
            case GameData.LastRoom.Church:
                gameObject.transform.position = curchJunction.transform.position + new Vector3(-2.0f, 0.0f, 0.0f);
                break;
            default:
                gameObject.transform.position = laboratoryJunction.transform.position + new Vector3(2.0f, 0.0f, 0.0f);
                break;
        }
        GameData.Instance.setGetlastRoom = GameData.LastRoom.City;
        
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
