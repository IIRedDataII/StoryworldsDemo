using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    #region Variables
    
    // Constants
    private const float Speed = 10f;
    private const float Range = 2f;

    // Unity variables
    public Image interact;
    public Image earthMessageLog;
    public Image familyMessageLog;
    public GameObject computerCom;
    public GameObject computerNav;

    // variables
    private Rigidbody2D _rigidbody;
    private bool canMove;
    private bool blockEForThisFrame;
    private bool readEarthLog;
    private bool readFamilyLog;

    #endregion

    private void Start()
    {
        
        #region Initialization

        canMove = true;
        earthMessageLog.enabled = false;
        familyMessageLog.enabled = false;
        _rigidbody = GetComponent<Rigidbody2D>();

        #endregion

    }

    private void Update()
    {
        
        #region Movement

        if (canMove)
        {
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Speed;
        }
        
        #endregion
        
        #region Leave Scene

        if (transform.position.x >= -7.62 && transform.position.x <= -5.39 && transform.position.y <= -13.3)
        {
            // TODO
            Debug.Log("Change Scene");
            transform.position = new Vector3(-6.4f, -12f, 0f);
        }

        #endregion

        #region End Sequence
        
        // initiate end sequence
        if (readEarthLog && readFamilyLog && !earthMessageLog.enabled && !familyMessageLog.enabled)
        {
            StartCoroutine(EndSequence());
        }
        
        #endregion

        #region Interaction
        
        // disable interact overlay
        if (interact.enabled)
            interact.enabled = false;
        
        
        // player at navigation
        if (IsCloseTo(computerNav))
        {
            
            if (!interact.enabled)
                interact.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E) && !earthMessageLog.enabled)
            {
                earthMessageLog.enabled = true;
                canMove = false;
                if (!readEarthLog)
                    readEarthLog = true;
                blockEForThisFrame = true;
            }
        }
        
        // player at communication
        if (IsCloseTo(computerCom))
        {
            
            if (!interact.enabled)
                interact.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E) && !familyMessageLog.enabled)
            {
                familyMessageLog.enabled = true;
                canMove = false;
                if (!readFamilyLog)
                    readFamilyLog = true;
                blockEForThisFrame = true;
            }
            
        }
        
        
        // disabled earth message log overlay
        if (Input.GetKeyDown(KeyCode.E) && earthMessageLog.enabled && !blockEForThisFrame)
        {
            earthMessageLog.enabled = false;
            canMove = true;
        }
        
        // disabled family message log overlay
        if (Input.GetKeyDown(KeyCode.E) && familyMessageLog.enabled && !blockEForThisFrame)
        {
            familyMessageLog.enabled = false;
            canMove = true;
        }
        
        
        // unblock E
        blockEForThisFrame = false;
        
        #endregion
        
    }

    #region Helper Functions
    
    private bool IsCloseTo(GameObject other)
    {
        return Vector3.Magnitude((Vector2) transform.position - (Vector2) other.transform.position) < Range;
    }
    
    #endregion
    
    #region Coroutines

    private IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(3);
        // TODO
        Debug.Log("*end sequence starts*");
    }
    
    #endregion
    
}
