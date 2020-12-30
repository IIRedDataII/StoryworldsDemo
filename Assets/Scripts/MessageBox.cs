/* Documentation
 * 
 * in-game: press space to go to the next message
 * 
 * Add this to your global variables:
 * private MessageBox messageBox;
 *
 * Set the variable in Unity
 *
 * Show one message by calling:
 * messageBox.ShowMessage("speaker", "message");
 * 
 * Show mutiple messages one after another by calling:
 * messageBox.ShowMessages(speakers, messages);
 * where speakers & messages are LinkedLists of strings. They can't be empty and have to be of the same size (speaker i is shown for message i).
 * 
 * To check wether there's a message box showing at the moment (for example to turn of player movement in that case), use the fuction
 * public bool GetMessageActive();
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
    
    private Image box;
    private Text text;
    
    private bool messageBusy;
    private bool messageDone;

    private int messagesLeft;
    private bool messagesFollowing;

    private LinkedList<string> messages;
    private LinkedList<string> speakers;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        box = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
        box.enabled = false;
        text.enabled = false;
        messagesLeft = 0;
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Message Queueing
        
        // there are messages left
        if (messagesFollowing)
        {
            
            // the last message has been fully formulated
            if (messageDone)
            {
                
                // press space to show the next message in the next frame
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    messageDone = false;
                    if (messagesLeft < 1)
                    {
                        messagesFollowing = false;
                        box.enabled = false;
                        text.enabled = false;
                    }

                }

            }
            
            // the next message can be shown
            else if (!messageBusy)
            {
                messageBusy = true;
                text.text = speakers.First.Value + ": ";
                speakers.RemoveFirst();
                StartCoroutine(ShowMessage(messages.First.Value));
                messages.RemoveFirst();
                messagesLeft--;
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
            box.enabled = true;
            text.enabled = true;
            this.speakers = speakers;
            this.messages = messages;
            messagesLeft = messages.Count;
            messagesFollowing = true;
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
            text.text += character;
            yield return new WaitForSeconds(Speed);
        }
        messageBusy = false;
        messageDone = true;
    }
    
    #endregion
    
    #region Setter & Getter
    
    public bool GetMessageActive()
    {
        return messageDone || messageBusy;
    }

    #endregion
    
}
