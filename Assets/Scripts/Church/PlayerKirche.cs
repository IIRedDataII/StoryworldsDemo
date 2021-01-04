using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Julians skript koopiert
public class PlayerKirche : MonoBehaviour
{
    
    #region Variables
    
    // Constants
    private const float Speed = 10f;
    private const float Range = 2f;

    // Unity variables
    public Image interact;
    public Image zweiteVision;
    public Image dritteVision;
    public Image ersteVision;
    public GameObject steinTafel2;
    public GameObject steinTafel3;
    public GameObject steinTafel1;
    public GameObject Rebell;
    public MessageBox messageBox;
    
    // variables
    private Rigidbody2D _rigidbody;
    private bool letztesBildWasEnabled = false;
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
        GameData.Instance.setGetlastRoom = GameData.LastRoom.Kirche;
        
        // example
        /*LinkedList<string> authors = new LinkedList<string>();
        authors.AddLast("Jordan");
        authors.AddLast("Bernd");
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Weg von mieeer!");
        messages.AddLast("Iech kiiihl diiiech!");
        messageBox.ShowMessages(authors, messages);
*/
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
                _rigidbody.velocity = Vector2.zero;
                if (!readzweiteVision)
                    readzweiteVision = true;
                blockEForThisFrame = true;
                LinkedList<string> messages = new LinkedList<string>();
                messages.AddLast("jo des bin ja ich auf dem bild");
                messageBox.ShowMonologue("Jordan", messages);
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
                _rigidbody.velocity = Vector2.zero;
                if (!readErsteVision)
                    readErsteVision = true;
                blockEForThisFrame = true;
                letztesBildWasEnabled = true;
                
                LinkedList<string> messages = new LinkedList<string>();
                messages.AddLast("Erlösung !");
                messageBox.ShowMonologue("Jordan", messages);
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
                _rigidbody.velocity = Vector2.zero;
                if (!readdritteVision)
                    readdritteVision = true;
                blockEForThisFrame = true;
                
                LinkedList<string> messages = new LinkedList<string>();
                messages.AddLast("Sieht aus als wären alle tot!");
                messageBox.ShowMonologue("Jordan", messages);
            }
        }
        // disabled earth message log overlay
        if (Input.GetKeyDown(KeyCode.E) && zweiteVision.enabled && !blockEForThisFrame && !messageBox.GetMessageActive())
        {
            zweiteVision.enabled = false;
            canMove = true;
        }
        // disabled family message log overlay
        if (Input.GetKeyDown(KeyCode.E) && dritteVision.enabled && !blockEForThisFrame && !messageBox.GetMessageActive())
        {
            dritteVision.enabled = false;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && ersteVision.enabled && !blockEForThisFrame && !messageBox.GetMessageActive())
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
        while (Rebell.transform.position.y < 12)
        {
            Rebell.transform.Translate(new Vector3(0,10,0)*Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }
        LinkedList<string> authors = new LinkedList<string>();
        authors.AddLast("Rebell");
        authors.AddLast("Jordan");
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("jo lass mal die Regierung stürzen");
        messages.AddLast("sPrICh DeUTsch dU HUso");
        yield return new WaitForSeconds(2);
        messageBox.ShowMessages(authors, messages);
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        yield return new WaitForSeconds(2);
        while (Rebell.transform.position.y > -5)
        {
            Rebell.transform.Translate(new Vector3(0,-10,0)*Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }
        Rebell.GetComponent<SpriteRenderer>().enabled = false;
        
        canMove = true;
    }
     #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("RebellenTrigger") && letztesBildWasEnabled && !GameData.Instance.rebelTriggered)
        {
            GameData.Instance.rebelTriggered = true;
            canMove = false;
            _rigidbody.velocity = Vector2.zero;
            Rebell.GetComponent<SpriteRenderer>().enabled = true;
            GameData.Instance.wasInChurch = true;
            StartCoroutine(rebellenSequence());
        }
        if (other.gameObject.tag.Equals("ScenenWechsel"))
        {
            SceneManager.LoadScene("City");
        }
    }
}
