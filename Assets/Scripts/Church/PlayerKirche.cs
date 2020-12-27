using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//Julians skript koopiert
public class PlayerKirche : MonoBehaviour
{
    
    #region Variables
    
    // Constants
    private const float Speed = 10f;
    private const float Range = 5f;

    // Unity variables
    public Image interact;
    public Image zweiteVision;
    public Image dritteVision;
    public Image ersteVision;
    public GameObject steinTafel2;
    public GameObject steinTafel3;
    public GameObject steinTafel1;
    public GameObject Rebell;
    
    // variables
    private Rigidbody2D _rigidbody;
    private bool letztesBildWasEnabled = false;
    public bool moveRebell = false;
    private bool rebellTriggered = false;
    private bool canMove;
    private bool blockEForThisFrame;
    private bool readzweiteVision;
    private bool readdritteVision;
    private bool readErsteVision;

    #endregion

    private void Start()
    {
        Debug.Log("Trigger");
        #region Initialization

        canMove = true;
        zweiteVision.enabled = false;
        dritteVision.enabled = false;
        ersteVision.enabled = false;
        _rigidbody = GetComponent<Rigidbody2D>();

        #endregion

    }

    private void Update()
    {
    
        #region Rebell

        if (moveRebell)
        {
            Rebell.transform.Translate(Vector3.up);
        }
        
        #endregion
        
        #region Movement

        if (canMove)
        {
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Speed;
        }
        
        #endregion
        


        #region Interaction
        
        // disable interact overlay
        if (interact.enabled)
            interact.enabled = false;
        
        
        // player at steintafel3
        if (IsCloseTo(steinTafel3))
        {
            
            if (!interact.enabled)
                interact.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E) && !zweiteVision.enabled)
            {
                zweiteVision.enabled = true;
                canMove = false;
                if (!readzweiteVision)
                    readzweiteVision = true;
                blockEForThisFrame = true;
            }
        }
        
        // player at steintafel1
        if (IsCloseTo(steinTafel1))
        {
            
            if (!interact.enabled)
                interact.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E) && !ersteVision.enabled)
            {
                ersteVision.enabled = true;
                canMove = false;
                if (!readErsteVision)
                    readErsteVision = true;
                blockEForThisFrame = true;
                letztesBildWasEnabled = true;
            }
        }
        
        // player at steintafel2
        if (IsCloseTo(steinTafel2))
        {
            
            if (!interact.enabled)
                interact.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E) && !dritteVision.enabled)
            {
                dritteVision.enabled = true;
                canMove = false;
                if (!readdritteVision)
                    readdritteVision = true;
                blockEForThisFrame = true;
            }
            
        }
        
        
        // disabled earth message log overlay
        if (Input.GetKeyDown(KeyCode.E) && zweiteVision.enabled && !blockEForThisFrame)
        {
            zweiteVision.enabled = false;
            canMove = true;
        }
        
        // disabled family message log overlay
        if (Input.GetKeyDown(KeyCode.E) && dritteVision.enabled && !blockEForThisFrame)
        {
            dritteVision.enabled = false;
            canMove = true;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && ersteVision.enabled && !blockEForThisFrame)
        {
            ersteVision.enabled = false;
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
     private IEnumerator rebellenSequence()
    {
        
        yield return new WaitWhile(()=>Rebell.transform.position.y < 21);
        moveRebell = false;
        yield return new WaitForSeconds(10);
        canMove = true;
        Debug.Log("rebellensequenz");
    }
    
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag.Equals("RebellenTrigger") && letztesBildWasEnabled && !rebellTriggered)
        {
            rebellTriggered = true;
            moveRebell = true;
            canMove = false;
            Rebell.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(rebellenSequence());
            
        }
    }
}
