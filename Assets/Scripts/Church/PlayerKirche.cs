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

    // variables
    private Rigidbody2D _rigidbody;
    private bool canMove;
    private bool blockEForThisFrame;
    private bool readzweiteVision;
    private bool readdritteVision;
    private bool readErsteVision;

    #endregion

    private void Start()
    {
        
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
        
        #region Movement

        if (canMove)
        {
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Speed;
        }
        
        #endregion
        
        //#region Leave Scene

        //if (transform.position.x >= -7.62 && transform.position.x <= -5.39 && transform.position.y <= -13.3)
       // {
         //   // TODO
         //   Debug.Log("Change Scene");
       //     transform.position = new Vector3(-6.4f, -12f, 0f);
       // }

        //#endregion

       // #region End Sequence
        
        // initiate end sequence
       // if (readzweiteVision && readdritteVision && !zweiteVision.enabled && !dritteVision.enabled)
       // {
       //     StartCoroutine(EndSequence());
       // }
        
      //  #endregion

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
    
   // #region Coroutines

  /// private IEnumerator EndSequence()
  //  {
       // yield return new WaitForSeconds(3);
        // TODO
     //   Debug.Log("*end sequence starts*");
  //  }
    
   // #endregion
    
}
