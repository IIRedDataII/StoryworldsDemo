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
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (Speed * Time.deltaTime * 1000f);
        else
            _rigidbody.velocity = Vector2.zero;

        #endregion

    }

}
