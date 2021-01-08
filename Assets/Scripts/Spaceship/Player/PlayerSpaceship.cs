using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpaceship : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 7f;
    
    #endregion
    
    #region Variables

    // static variables
    public bool atComputerNav;
    public bool atComputerCom;
    public bool atButton;
    
    // Unity variables
    [SerializeField] private Image earthMessageLog;
    [SerializeField] private Image familyMessageLog;
    [SerializeField] private MessageBox messageBox;

    // variables
    private Rigidbody2D _rigidbody;
    private bool imageActive;
    private bool readEnd;

    #endregion

    private void Start()
    {
        
        #region Initialization

        atComputerNav = false;
        atComputerCom = false;
        atButton = false;
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
        GameData.Instance.setGetlastRoom = GameData.LastRoom.Spaceship;
        
        #endregion

    }

    private void Update()
    {
        
        #region Movement

        if (!imageActive && !messageBox.GetMessageActive())
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (Speed * Time.deltaTime * 1000f);
        else
            _rigidbody.velocity = Vector2.zero;

        #endregion

        #region Interaction

        if (Input.GetButtonDown("Interact"))
        {
            
            if (atButton)
            {
                if (GameData.Instance.wasInChurch)
                {
                    string[] messages = {
                        "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
                        "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
                        "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?",
                        "Oder soll ich hierbleiben? Ich verdanke den Rebellen mein Leben. Vielleicht kann ich ihnen wirklich helfen...",
                        "Vielleicht finde ich in ihnen sogar eine neue Familie? Ein neues Leben? Wer weiß, ob ich je wieder einen so bewohnbaren Planeten finde?"
                    };
                    messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));

                    readEnd = true;
                }
                else
                {
                    messageBox.ShowMessage("Jordan", "Ich möchte mich hier lieber noch etwas umsehen, bevor ich das Schiff starte.");
                }
            }
            
            else if (atComputerNav)
            {
                if (earthMessageLog.enabled)
                {
                    earthMessageLog.enabled = false;
                    imageActive = false;
            
                    DialogueNavigations();
                }
                else
                {
                    earthMessageLog.enabled = true;
                    imageActive = true;
                }
            }
            
            else if (atComputerCom)
            {
                if (familyMessageLog.enabled)
                {
                    familyMessageLog.enabled = false;
                    imageActive = false;

                    DialogueCommunications();
                }
                else
                {
                    familyMessageLog.enabled = true;
                    imageActive = true;
                }
            }
            
            
        }
        
        #endregion
        
        #region End
        
        if (readEnd && !messageBox.GetMessageActive())
        {
            readEnd = false;
            // TODO: Add decision & end to demo
            Debug.Log("End: Decision");
        }

        #endregion
        
    }

    #region Helper Functions

    private void DialogueCommunications()
    {
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja supi."
        };
        messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
    }
    
    private void DialogueNavigations()
    {
        string[] messages = {
            "Ach Mensch!",
            "Desch' ja blöd."
        };
        messageBox.ShowMonologue("Jordan", new LinkedList<string>(messages));
    }
    
    #endregion
    
}
