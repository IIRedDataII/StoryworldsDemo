using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 10f;
    private const float Range = 2f;
    
    #endregion
    
    #region Variables
    
    // Unity variables
    public Image interact;
    public Image earthMessageLog;
    public Image familyMessageLog;
    public GameObject computerCom;
    public GameObject computerNav;

    // variables
    private Rigidbody2D _rigidbody;
    public MessageBox messageBox;
    private bool canMove;
    private bool blockEForThisFrame;
    private bool readEarthLog;
    private bool readFamilyLog;

    private bool end;   // probably temporary.

    #endregion

    private void Start()
    {
        
        #region Initialization

        _rigidbody = GetComponent<Rigidbody2D>();
        canMove = true;
        earthMessageLog.enabled = false;
        familyMessageLog.enabled = false;
        
        GameData.Instance.setGetlastRoom = GameData.LastRoom.Spaceship;
        
        #endregion

    }

    private void Update()
    {
        
        #region Movement

        if (canMove && !messageBox.GetMessageActive())
        {
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Speed;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }

        #endregion
        
        #region End Sequence
        
        // initiate end sequence
        if (!end && readEarthLog && readFamilyLog && !earthMessageLog.enabled && !familyMessageLog.enabled && !messageBox.GetMessageActive())
        {
            end = true;
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
            
            DialogueNavigations();
        }
        
        // disabled family message log overlay
        if (Input.GetKeyDown(KeyCode.E) && familyMessageLog.enabled && !blockEForThisFrame)
        {
            familyMessageLog.enabled = false;
            canMove = true;

            DialogueCommunications();
        }
        
        
        // unblock E
        blockEForThisFrame = false;
        
        #endregion
        
    }

    #region Helper Functions

    private void DialogueCommunications()
    {
        LinkedList<string> authors = new LinkedList<string>();
        authors.AddLast("Jordan");
        authors.AddLast("Jordan");
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Ach Mensch!");
        messages.AddLast("Desch' ja supi.");
        messageBox.ShowMessages(authors, messages);
    }
    
    private void DialogueNavigations()
    {
        LinkedList<string> authors = new LinkedList<string>();
        authors.AddLast("Jordan");
        authors.AddLast("Jordan");
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Ach Mensch!");
        messages.AddLast("Desch' ja blöd.");
        messageBox.ShowMessages(authors, messages);
    }
    
    private bool IsCloseTo(GameObject other)
    {
        return Vector3.Magnitude((Vector2) transform.position - (Vector2) other.transform.position) < Range;
    }
    
    #endregion
    
    #region Coroutines

    private IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(5);
        
        messageBox.ShowMessage("Jordan", "Was soll ich tun? Meine Familie suchen? Oder mich den Chia-Rebellen anschließen und hierbleiben?");
        
        // TODO: Knöpfe für Entscheidung einfügen
        Debug.Log("*end*");
    }
    
    #endregion

    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ScenenWechsel"))
        {
            SceneManager.LoadScene("City");
        }
    }
    
    #endregion
    
}
