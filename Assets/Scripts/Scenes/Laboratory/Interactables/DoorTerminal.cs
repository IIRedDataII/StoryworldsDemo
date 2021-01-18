using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class DoorTerminal : Interactable
{

    [SerializeField] private MessageBox box;
     
    [SerializeField] private Door door;
    [SerializeField] private Text text;
    [SerializeField] private GameObject keypad;

    [SerializeField][Range(0.5f, 2.0f)] private float WaitTime;
    
    private bool _open;
    
    //KeyCode
    [SerializeField] private int code = 1234;
    [SerializeField] private int _input;


    private void Awake()
    {
        keypad.SetActive(false);
        PostCodeInTextbox();
    }

    protected override void SpecificAction()
    {
        //Open Code Terminal View
        keypad.SetActive(true);
    }

    protected override void UndoSpecificAction()
    {
        //Close Terminal View, Reset Input, Give Hint to Player
        _input = 0;
        keypad.SetActive(false);
        if (!_open)
        {
            LinkedList<string> messages = new LinkedList<string>();
            messages.AddLast("Verdammt, irgendwas stimmt nicht. Ich sollte mich mal umschauen.");
            messages.AddLast("Vielleicht finde ich etwas, das wie der Code aussieht?");
            box.ShowMonologue("Jordan", messages);
        }

    }

    protected override void SpecificUpdate()
    {
        
    }

    #region Keypad

    public void EnterNumber(int num)
    {
        //Concatenate Numbers to check code;
        _input = _input * 10 + num;
        PostCodeInTextbox();
    }

    public void SubmitInput()
    {
        if (_input == code)
        {
            Sucess();
        }
        else
        {
            WrongInput();
        }
    }

    public void UndoInput()
    {
        _input /= 10;
        PostCodeInTextbox();
    }

    public void PostCodeInTextbox()
    {
        if (_input == 0)
        {
            text.text = "*Insert Code*";
        }
        else if (_input < 0)
        {
            text.text = "*Sucess*";
        }
        else
        {
            text.text = _input.ToString();
        }
    }

    #endregion

    private void Sucess()
    {
        door.Open();
        _open = true;
        _input = -1;
        PostCodeInTextbox();
        UndoAction();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


    private void WrongInput()
    {
        _input = 0;
        StartCoroutine(Error());
    }

    IEnumerator Error()
    {
        text.text = "Error";
        yield return new WaitForSeconds(WaitTime);
        PostCodeInTextbox();
    }
}