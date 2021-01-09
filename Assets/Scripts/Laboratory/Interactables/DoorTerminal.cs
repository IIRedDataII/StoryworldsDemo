using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class DoorTerminal : Interactable
{
    [SerializeField] private Door door;
    [SerializeField] private Text text;
    [SerializeField] private GameObject keypad;

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
        //Close Terminal View
        _input = 0;
        keypad.SetActive(false);
    }

    protected override void UpdateSpecific()
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
        else
        {
            text.text = _input.ToString();
        }
    }

    #endregion

    private void Sucess()
    {
        door.Open();
        _input = 0;
        PostCodeInTextbox();
        UndoAction();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


    private void WrongInput()
    {
        _input = 0;
        PostCodeInTextbox();
    }
}