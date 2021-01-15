/* Documentation
 * 
 * in-game: press space to go to the next message
 * 
 * Add this to your global variables:
 * [SerializeField] private MessageBox messageBox;
 * Copy the UI GameObject "MessageBox" from the Spaceship scene into your scene and use it to set the variable in the editor
 *
 * Show one message by calling:
 * messageBox.ShowMessage("speaker", "message");
 * 
 * Show mutiple messages one after another by calling:
 * messageBox.ShowMessages(speakers, messages);
 * where speakers & messages are LinkedLists of strings. They cannot be empty and must be of the same size (speaker i is shown for message i).
 *
 * Show a monologue with only one person speaking by calling:
 * messageBox.ShowMonologue("speaker", messages);
 * where messages is a LinkedList of strings
 *
 * Show a dialogue with two persons speaking by calling:
 * messageBox.ShowDialogue("speakerFirst", "speakerSecond", messages);
 * where messages is a LinkedList of strings. speakerFirst and speakerSecond alternate in the MessageBoxes with speakerFirst beginning.
 * 
 * To check wether there's a message box showing at the moment (for example to turn off player movement in that case), use the fuction
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
    
    private const float Speed = 0.025f;
    
    #endregion
    
    #region Variables
    
    private Image _box;
    private Text _text;
    
    private bool _messageBusy;
    private bool _messageDone;

    private int _messagesLeft;
    private bool _messagesFollowing;

    private LinkedList<string> _messages;
    private LinkedList<string> _speakers;
    
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
        
        // there are messages left
        if (_messagesFollowing)
        {
            
            // the last message has been fully formulated
            if (_messageDone)
            {
                
                // press space to show the next message in the next frame
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _messageDone = false;
                    if (_messagesLeft < 1)
                    {
                        _messagesFollowing = false;
                        _box.enabled = false;
                        _text.enabled = false;
                        PlayerMovement.CanMove = true;
                        PlayerInteract.CanInteract = true;
                    }

                }

            }
            
            // the next message can be shown
            else if (!_messageBusy)
            {
                _messageBusy = true;
                _text.text = _speakers.First.Value + ": ";
                _speakers.RemoveFirst();
                StartCoroutine(ShowMessage(_messages.First.Value));
                _messages.RemoveFirst();
                _messagesLeft--;
            }
            
        }

        #endregion

    }
    
    #region Helper Functions
    
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
            _box.enabled = true;
            _text.enabled = true;
            this._speakers = speakers;
            this._messages = messages;
            _messagesLeft = messages.Count;
            _messagesFollowing = true;
            PlayerMovement.CanMove = false;
            PlayerInteract.CanInteract = false;
            Update();
        }
        else
        {
            Debug.Log("There is another message active at the moment. This message was ignored.");
        }
        
    }
    
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator ShowMessage(string message)
    {
        foreach (char character in message)
        { 
            _text.text += character;
            yield return new WaitForSeconds(Speed);
        }
        _messageBusy = false;
        _messageDone = true;
    }
    
    #endregion
    
    #region Setter & Getter
    
    public bool GetMessageActive()
    {
        return _messageDone || _messageBusy;
    }

    #endregion
    
}
