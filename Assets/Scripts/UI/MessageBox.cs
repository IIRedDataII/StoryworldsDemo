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
 * where messages is an Array of strings
 *
 * Show a dialogue with two persons speaking by calling:
 * messageBox.ShowDialogue("speakerFirst", "speakerSecond", messages);
 * where messages is an Array of strings. speakerFirst and speakerSecond alternate in the MessageBoxes with speakerFirst beginning.
 *
 * Show one message by calling:
 * messageBox.ShowMessage("speaker", "message");
 * 
 * Show mutiple messages one after another by calling:
 * messageBox.ShowMessages(speakers, messages);
 * where speakers & messages are Arrays of strings. They cannot be empty and must be of the same size (speaker i is shown for message i).
 * 
 * To check wether there's a message box showing at the moment, use the fuction
 * messageBox.GetMessageActive();
 * 
 */

using System;
using System.Collections;
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

    private IEnumerator _spellMessage;

    private string[] _messages;
    private string[] _speakers;

    private string _activeMessage;
    private string _activeSpeaker;
    
    private int _messageCounter;
    private int _messageCount;
    
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
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Message Queueing

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_messageBusy)
            {
                StopCoroutine(_spellMessage);
                _text.text = _activeSpeaker + ": " + _activeMessage;
        
                _messageDone = true;
                _messageBusy = false;
            }
            else if (_messageDone)
            {
                if (_messageCounter < _messageCount)
                {
                    ShowNextMessage();
                }
                else
                {
                    _box.enabled = false;
                    _text.enabled = false;
                    _messageDone = false;
                    Utils.SetPlayerControls(true);
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
    
    public void ShowMonologue(string speaker, string[] messages)
    {
        string[] speakers = new string[messages.Length];
        for (int i = 0; i < speakers.Length; i++)
            speakers[i] = speaker;
        ShowMessages(speakers, messages);
    }
    
    public void ShowDialogue(string speakerFirst, string speakerSecond, string[] messages)
    {
        string[] speakers = new string[messages.Length];
        for (int i = 0; i < speakers.Length; i++)
            speakers[i] = (i % 2 == 0 ? speakerFirst : speakerSecond);
        ShowMessages(speakers, messages);
    }

    public void ShowMessage(string speaker, string message)
    {
        string[] speakers = {speaker};
        string[] messages = {message};
        ShowMessages(speakers, messages);
    }
    
    public void ShowMessages(string[] speakers, string[] messages)
    {
        
        if (speakers.Length < 1 || messages.Length < 1)
        {
            throw new ArgumentException("@speakers and @messages cannot be zero");
        }
        if (speakers.Length != messages.Length)
        {
            throw new ArgumentException("@speakers and @messages cannot be of different size");
        }

        if (!GetMessageActive())
        {
            Utils.SetPlayerControls(false);
            _box.enabled = true;
            _text.enabled = true;
            _speakers = speakers;
            _messages = messages;
            _messageCount = messages.Length;
            _messageCounter = 0;
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
        _messageBusy = true;
        _messageDone = false;

        _activeMessage = _messages[_messageCounter];
        _activeSpeaker = _speakers[_messageCounter];
        _messageCounter++;
        
        _spellMessage = SpellMessage();
        StartCoroutine(_spellMessage);
    }
  
    #endregion
    
    #region Coroutines
    
    private IEnumerator SpellMessage()
    {
        _text.text = _activeSpeaker + ": ";
        foreach (char character in _activeMessage)
        {
            _text.text += character;
            yield return new WaitForSeconds(1 / Speed);
        }
        
        _messageDone = true;
        _messageBusy = false;
    }
    
    #endregion
    
}
