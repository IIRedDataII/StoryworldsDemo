using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorTerminal : Interactable
{

    [SerializeField] private MessageBox box;
    [SerializeField] private Font aurebesh;
    [SerializeField] private Font numbers;
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
            box.ShowMonologue("Jordan", Texts.DoorTerminalFailureMonologue);
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
            text.font = aurebesh;
            text.fontSize = 20;
            text.text = "*Insert Code*";
        }
        else if (_input < 0)
        {
            text.font = aurebesh;
            text.fontSize = 20;
            text.text = "*Sucess*";
        }
        else
        {
            text.font = numbers;
            text.fontSize = 30;
            text.text = _input.ToString();
        }
    }

    #endregion

    public void Reset()
    {
        _input = 0;
        _open = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

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
        text.font = aurebesh;
        text.fontSize = 20;
        StartCoroutine(Error());
    }

    IEnumerator Error()
    {
        text.text = "Error";
        yield return new WaitForSeconds(WaitTime);
        PostCodeInTextbox();
    }
}