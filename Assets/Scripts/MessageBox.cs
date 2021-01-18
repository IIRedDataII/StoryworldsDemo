/* Documentation
 * 
 * in-game: press space to go to the next message
 * 
 * Add this to your global variables:
 * [SerializeField] private MessageBox messageBox;
 * Copy the UI Element "MessageBox" from the Spaceship scene into your scene and use it to set the variable in the editor
 *
 * Show a monologue with only one person speaking by calling:
 * messageBox.ShowMonologue("speaker", messages);
 * where messages is a LinkedList of strings
 *
 * Show a dialogue with two persons speaking by calling:
 * messageBox.ShowDialogue("speakerFirst", "speakerSecond", messages);
 * where messages is a LinkedList of strings. speakerFirst and speakerSecond alternate in the MessageBoxes with speakerFirst beginning.
 *
 * Show one message by calling:
 * messageBox.ShowMessage("speaker", "message");
 * 
 * Show mutiple messages one after another by calling:
 * messageBox.ShowMessages(speakers, messages);
 * where speakers & messages are LinkedLists of strings. They cannot be empty and must be of the same size (speaker i is shown for message i).
 * 
 * In any case, use strings to initialize LinkedLists inside the function parameter brackets:
 * string[] messages = {"Message 1", "Message 2", ..., "Message n"};
 * string[] speakers = {"Speaker 1", "Speaker 2", ..., "Speaker n"};
 * messageBox.showMessages(new LinkedList<string>(speakers), new LinkedList<string>(messages));
 * 
 * To check wether there's a message box showing at the moment, use the fuction
 * messageBox.GetMessageActive();
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    
    #region Constants
    
    private const float Speed = 40f;
    
    #endregion
    
    #region Variables
    
    private Image _box;
    private Text _text;

    private LinkedList<string> _messages;
    private LinkedList<string> _speakers;
    
    private int _messagesLeft;
    
    private bool _messageBusy;
    private bool _messageDone;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        _box = GetComponentInChildren<Image>();
        _text = GetComponentInChildren<Text>();
        _box.enabled = false;
        _text.enabled = false;
        _messagesLeft = 0;
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Message Queueing

        if (_messageDone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_messagesLeft > 0)
                {
                    ShowNextMessage();
                }
                else
                {
                    _box.enabled = false;
                    _text.enabled = false;
                    _messageDone = false;
                    SetPlayerControls(true);
                }
            }
        }
        
        #endregion

    }
    
    #region Public Functions
    
    public bool GetMessageActive()
    {
        return _messageBusy || _messageDone;
    }
    
    public void ShowMonologue(string speaker, LinkedList<string> messages)
    {
        LinkedList<string> speakers = new LinkedList<string>();
        for (int i = 0; i < messages.Count; i++)
            speakers.AddLast(speaker);
        ShowMessages(speakers, messages);
    }
    
    public void ShowDialogue(string speakerFirst, string speakerSecond, LinkedList<string> messages)
    {
        LinkedList<string> speakers = new LinkedList<string>();
        for (int i = 0; i < messages.Count; i++)
            speakers.AddLast(i % 2 == 0 ? speakerFirst : speakerSecond);
        ShowMessages(speakers, messages);
    }

    public void ShowMessage(string speaker, string message)
    {
        LinkedList<string> speakers = new LinkedList<string>();
        speakers.AddLast(speaker);
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast(message);
        ShowMessages(speakers, messages);
    }
    
    public void ShowMessages(LinkedList<string> speakers, LinkedList<string> messages)
    {
        
        if (speakers.Count < 1 || messages.Count < 1)
        {
            throw new ArgumentException("@speakers and @messages cannot be zero");
        }
        if (speakers.Count != messages.Count)
        {
            throw new ArgumentException("@speakers and @messages cannot be of different size");
        }

        if (!GetMessageActive())
        {
            SetPlayerControls(false);
            _box.enabled = true;
            _text.enabled = true;
            _speakers = speakers;
            _messages = messages;
            _messagesLeft = messages.Count;
            ShowNextMessage();
        }
        else
        {
            // TODO NTH: queue multiple message calls
            Debug.Log("There is another message active at the moment. This message was ignored.");
        }
        
    }
    
    #endregion
    
    #region Helper Functions

    private void ShowNextMessage()
    {
        string speaker = _speakers.First.Value;
        _speakers.RemoveFirst();
        string message = _messages.First.Value;
        _messages.RemoveFirst();

        _messageBusy = true;
        _messageDone = false;
        _messagesLeft--;
        
        _text.text = speaker + ": ";
        StartCoroutine(ShowMessage(message));
    }
    
    private void SetPlayerControls(bool active)
    {
        PlayerMovement.CanMove = active;
        PlayerInteract.CanInteract = active;
        PlayerShoot.AllowInput = active;
    }
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator ShowMessage(string message)
    {
        foreach (char character in message)
        { 
            _text.text += character;
            yield return new WaitForSeconds(1 / Speed);
        }
        
        _messageDone = true;
        _messageBusy = false;
    }
    
    #endregion
    
}
