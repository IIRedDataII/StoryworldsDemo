using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DoorTerminal : Interactable
{
    [SerializeField] private Door door;

    [SerializeField] private GameObject keypad;
    //KeyCode
    [SerializeField] private int code = 1234;
    [SerializeField] private int _input = 0;

    private void Start()
    {
        keypad.SetActive(false);
    }

    protected override void SpecificAction()
    {
        //Open Code Terminal View
        keypad.SetActive(true);
    }

    protected override void UndoSpecificAction()
    {
        //Close Terminal View
        WrongInput();
        keypad.SetActive(false);
    }

    private void Update()
    {
        if (Active && (Input.GetButtonDown("UndoInteract") || Input.GetMouseButtonDown(0))) 
        { 
            UndoAction();
        }
    }

    #region Keypad

    public void EnterNumber(int num)
    {
        //Concatenate Numbers to check code;
        _input = _input * 10 + num;
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
    }
    
    #endregion

    private void Sucess()
    {
        door.Open();
        UndoAction();
    }
    
    
    
    private void WrongInput()
    {
        //TO DO: Show Error somehow,
        _input = 0;
    }
}
